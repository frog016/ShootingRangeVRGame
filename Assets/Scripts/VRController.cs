using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController), typeof(Collider))]
public class VRController : MonoBehaviour
{
    public Collider Collider { get; private set; }

    private ActionBasedController _controller;

    private void Awake()
    {
        Collider = GetComponent<Collider>();
        _controller = GetComponent<ActionBasedController>();
    }

    public void SendHapticImpulse(float amplitude, float duration)
    {
        _controller.SendHapticImpulse(amplitude, duration);
    }
}