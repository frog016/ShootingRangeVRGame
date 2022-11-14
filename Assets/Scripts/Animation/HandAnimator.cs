using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class HandAnimator : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;

    private Animator _animator;
    private AnimationData _gripAnimationData;
    private AnimationData _triggerAnimationData;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _gripAnimationData = new AnimationData(0, 0, "Grip");
        _triggerAnimationData = new AnimationData(0, 0, "Trigger");
    }

    private void Update()
    {
        AnimateHand();
    }

    public void SetGripTargetValue(float value)
    {
        _gripAnimationData.TargetAnimationValue = value;
    }

    public void SetTriggerTargetValue(float value)
    {
        _triggerAnimationData.TargetAnimationValue = value;
    }

    private void AnimateHand()
    {
        TryAnimate(_gripAnimationData);
        TryAnimate(_triggerAnimationData);
    }

    private void TryAnimate(AnimationData data)
    {
        if (Math.Abs(data.CurrentAnimationValue - data.TargetAnimationValue) < 1e-6)
            return;

        data.CurrentAnimationValue = Mathf.MoveTowards(data.CurrentAnimationValue, data.TargetAnimationValue, Time.deltaTime * _animationSpeed);
        _animator.SetFloat(data.AnimationNameHash, data.CurrentAnimationValue);
    }
}
