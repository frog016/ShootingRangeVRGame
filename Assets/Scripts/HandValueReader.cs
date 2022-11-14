using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]

public class HandValueReader : MonoBehaviour
{
    private HandAnimator _handAnimator;
    private ActionBasedController _controller;

    private void Awake()
    {
        _handAnimator = GetComponentInChildren<HandAnimator>();
        _controller = GetComponent<ActionBasedController>();
    }

    private void OnEnable()
    {
        _controller.selectAction.action.performed += ReadValue; //  Если не работает, вернуть в Update.
    }

    private void ReadValue(InputAction.CallbackContext context)
    {
        _handAnimator.SetGripTargetValue(context.ReadValue<float>());
        _handAnimator.SetTriggerTargetValue(context.ReadValue<float>());
    }

    private void OnDisable()
    {
        _controller.selectAction.action.performed -= ReadValue;
    }
}
