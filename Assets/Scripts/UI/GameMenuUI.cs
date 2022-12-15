using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Transform _playerHead;
    [SerializeField] private float _distanceToHead = 2;
    [SerializeField] private InputActionProperty _menuButton;

    private void OnEnable()
    {
        _menuButton.action.started += ShowMenu;
        _menuButton.action.canceled += HideMenu;
    }

    private void Update()
    {
        _menu.transform.LookAt(new Vector3(_playerHead.position.x, _menu.transform.position.y, _playerHead.position.z));
    }

    private void ShowMenu(InputAction.CallbackContext context)
    {
        _menu.SetActive(true);
        _menu.transform.position = _playerHead.position + new Vector3(_playerHead.forward.x, 0, _playerHead.forward.z).normalized * _distanceToHead;
        _menu.transform.forward *= -1;
    }

    private void HideMenu(InputAction.CallbackContext context)
    {
        _menu.SetActive(false);
    }

    private void OnDisable()
    {
        _menuButton.action.started -= ShowMenu;
        _menuButton.action.canceled -= HideMenu;
    }
}
