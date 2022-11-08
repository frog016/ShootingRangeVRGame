using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(TeleportationProvider))]
public class Teleporter : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAssets;
    [SerializeField] private XRRayInteractor _rayInteractor;

    private bool _isActive;
    private InputAction _moveAction;
    private TeleportationProvider _teleportation;

    private void Awake()
    {
        _rayInteractor.enabled = false;
        _teleportation = GetComponent<TeleportationProvider>();
    }

    private void Start()
    {
        InitializeInputActions();
    }

    private void Update()
    {
        if (!_isActive || _moveAction.triggered || !_rayInteractor.TryGetCurrent3DRaycastHit(out var hit))
        {
            OnTeleportCancel(default);
            return;
        }

        var request = new TeleportRequest { destinationPosition = hit.point };
        _teleportation.QueueTeleportRequest(request);
    }

    private void InitializeInputActions()
    {
        const string actionMapName = "XRI LeftHand Locomotion";

        var activateTeleport = GetActionFromAssets(actionMapName, "Teleport Mode Activate");
        var cancelTeleport = GetActionFromAssets(actionMapName, "Teleport Mode Cancel");
        _moveAction = GetActionFromAssets(actionMapName, "Move");

        activateTeleport.performed += OnTeleportActivate;
        cancelTeleport.performed += OnTeleportCancel;
    }

    private InputAction GetActionFromAssets(string actionMapId, string actionName)
    {
        var action = _actionAssets
            .FindActionMap(actionMapId)
            .FindAction(actionName);

        action.Enable();
        return action;
    }

    private void OnTeleportActivate(InputAction.CallbackContext _)
    {
        _rayInteractor.enabled = true;
        _isActive = true;
    }
    private void OnTeleportCancel(InputAction.CallbackContext _)
    {
        _rayInteractor.enabled = false;
        _isActive = false;
    }
}
