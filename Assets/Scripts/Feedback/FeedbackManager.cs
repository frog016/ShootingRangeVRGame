using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] private VRController _leftController;
    [SerializeField] private VRController _rightController;

    [SerializeField] private float _sensitivity;
    [SerializeField] private int _framePerHapticCall;
    [SerializeField] private float _msBetweenHapticCall;
    [SerializeField] private float _discreteFunctionStep;

    private List<Vibration> _currentLeftVibrations;
    private List<Vibration> _currentRightVibrations;

    private int _framesSinceLastHapticCall;

    public static FeedbackManager Instance { get; private set; }
    public (float, float) CurrentVibrationAmplitudes { get; private set; }

    public float DiscreteFunctionStep => _discreteFunctionStep;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _currentLeftVibrations = new List<Vibration>();
        _currentRightVibrations = new List<Vibration>();
    }

    private void Update()
    {
        _framesSinceLastHapticCall++;
        if (_framesSinceLastHapticCall < _framePerHapticCall) return;

        RemoveEndedVibrations(_currentLeftVibrations);
        RemoveEndedVibrations(_currentRightVibrations);

        var duration = _msBetweenHapticCall < 0
            ? Time.deltaTime * _framePerHapticCall
            : _msBetweenHapticCall / 1000;
        var leftAmplitude = _currentLeftVibrations.Count != 0 ? _currentLeftVibrations.Max(vibration => vibration.Amplitude) : 0;
        var rightAmplitude = _currentRightVibrations.Count != 0 ? _currentRightVibrations.Max(vibration => vibration.Amplitude) : 0;
        leftAmplitude = Mathf.Min(leftAmplitude * _sensitivity, 1);
        rightAmplitude = Mathf.Min(rightAmplitude * _sensitivity, 1);

        CurrentVibrationAmplitudes = (leftAmplitude, rightAmplitude);
        _leftController.SendHapticImpulse(leftAmplitude, duration);
        _rightController.SendHapticImpulse(rightAmplitude, duration);

        _framesSinceLastHapticCall = 0;
    }

    public void SendHapticImpulse(Controllers controller, float amplitude, float duration)
    {
        var newVibration = new Vibration(amplitude, duration, Time.time);

        if (controller == Controllers.Left || controller == Controllers.Both)
        {
            _currentLeftVibrations.Add(newVibration);
        }

        if (controller == Controllers.Right || controller == Controllers.Both)
        {
            _currentRightVibrations.Add(newVibration);
        }

    }

    public bool TryGetController(Collider collider, out Controllers controller)
    {
        controller = collider == _leftController.Collider ? 
            Controllers.Left : collider == _rightController.Collider ?
                Controllers.Right : Controllers.None;
        return controller != Controllers.None;
    }

    public Vector3 GetPosition(Controllers controller)
    {
        return controller == Controllers.Left ? 
            _leftController.Collider.transform.position : _rightController.Collider.transform.position;
    }

    public void RemoveEndedVibrations(List<Vibration> vibrations)
    {
        for (var i = 0; i < vibrations.Count; i++)
        {
            if (Time.time - vibrations[i].StartTime > vibrations[i].Duration)
            {
                vibrations.Remove(vibrations[i]);
            }
        }
    }

    public struct Vibration
    {
        public float Amplitude;
        public float Duration;
        public float StartTime;

        public Vibration(float amplitude, float duration, float startTime)
        {
            Amplitude = amplitude;
            Duration = duration;
            StartTime = startTime;
        }
    }

    public enum Controllers
    {
        None,
        Left,
        Right,
        Both
    }
}