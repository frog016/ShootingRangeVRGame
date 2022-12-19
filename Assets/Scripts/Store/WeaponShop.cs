using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Store/Weapon", fileName = "WeaponShop")]
public class WeaponShop : ScriptableObject
{
    [SerializeField] private ScoreStorage _scoreStorage; 
    [SerializeField] private WeaponStoreData[] _weaponsData;

    public event Action<WeaponStoreData> ItemBoughtEvent; 

    public bool TryBuy(GameObject purchasedWeapon)
    {
        var weapon = _weaponsData.FirstOrDefault(weaponData => weaponData.Equals(purchasedWeapon));
        if (weapon == null || _scoreStorage.CurrentScore < weapon.Price)
            return false;

        weapon.IsBought = true;
        _scoreStorage.ChangeScore(-weapon.Price);
        ItemBoughtEvent?.Invoke(weapon);

        return true;
    }

    public WeaponStoreData[] GetAllData() => _weaponsData.ToArray();
}