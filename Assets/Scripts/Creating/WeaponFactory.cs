using System.Linq;
using UnityEngine;

public class WeaponFactory : MonoBehaviour
{
    [SerializeField] private bool _createOnStart;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Vector3 _delta;
    [SerializeField] private WeaponShop _weaponShop;

    private Vector3 _currentPoint;

    private void Start()
    {
        _currentPoint = _startPoint.position;

        if (!_createOnStart)
            return;

        foreach (var data in _weaponShop.GetAllData().Where(data => data.IsBought))
            CreateWeapon(data);
    }

    private void OnEnable() => _weaponShop.ItemBoughtEvent += CreateWeapon;

    private void OnDisable() => _weaponShop.ItemBoughtEvent -= CreateWeapon;

    public void CreateWeapon(WeaponStoreData data)
    {
        Instantiate(data.WeaponPrefab, _currentPoint, _startPoint.rotation);
        _currentPoint += _delta;
    }
}
