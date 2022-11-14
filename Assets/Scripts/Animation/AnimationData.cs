using UnityEngine;

public struct AnimationData
{
    public float CurrentAnimationValue { get; set; }
    public float TargetAnimationValue { get; set; }
    public readonly int AnimationNameHash;

    public AnimationData(float currentAnimationValue, float targetAnimationValue, string animationName)
    {
        CurrentAnimationValue = currentAnimationValue;
        TargetAnimationValue = targetAnimationValue;
        AnimationNameHash = Animator.StringToHash(animationName);
    }
}
