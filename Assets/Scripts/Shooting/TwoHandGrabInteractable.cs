using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[Serializable]
public class TwoHandGrabInteractable : XRGrabInteractable
{
    [SerializeField] private List<XRSimpleInteractable> _secondGrabPoints;

    private XRBaseInteractor _currentOtherInteractor;
    private Quaternion _attachRotation;

    private XRBaseInteractor SelectedInteractor => (XRBaseInteractor)interactorsSelecting[0];

    protected override void Awake()
    {
        base.Awake();
        foreach (var item in _secondGrabPoints)
        {
            item.selectEntered.AddListener(OnSecondHandGrab);
            item.selectExited.AddListener(OnSecondHandRelease);
        }
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (_currentOtherInteractor && SelectedInteractor)
            SelectedInteractor.attachTransform.rotation = GetRotation();

        base.ProcessInteractable(updatePhase);
    }

    public override bool IsSelectableBy(IXRSelectInteractor interactor)
    {
        var isGrabbed = SelectedInteractor && !interactor.Equals(SelectedInteractor);
        return base.IsSelectableBy(interactor) && !isGrabbed;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs eventArgs)
    {
        base.OnSelectEntered(eventArgs);
        _attachRotation = GetBaseInteractor(eventArgs).attachTransform.localRotation;
    }

    protected override void OnSelectExited(SelectExitEventArgs eventArgs)
    {
        base.OnSelectExited(eventArgs);
        _currentOtherInteractor = null;
        GetBaseInteractor(eventArgs).attachTransform.localRotation = _attachRotation;
    }

    private void OnSecondHandGrab(SelectEnterEventArgs eventArgs)
    {
        _currentOtherInteractor = GetBaseInteractor(eventArgs);
    }

    private void OnSecondHandRelease(SelectExitEventArgs eventArgs)
    {
        _currentOtherInteractor = null;
    }

    private XRBaseInteractor GetBaseInteractor(BaseInteractionEventArgs eventArgs)
    {
        return (XRBaseInteractor)eventArgs.interactorObject;
    }

    private Quaternion GetRotation()
    {
        return Quaternion.LookRotation(
            _currentOtherInteractor.attachTransform.position - SelectedInteractor.attachTransform.position,
            _currentOtherInteractor.attachTransform.up);
    }
}
