using UnityEngine;

[CreateAssetMenu(menuName = "Store/Data/Weapon", fileName = "WeaponStoreData")]
public class WeaponStoreData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private bool _isBought;

    public string Name => _name;
    public string Description => _description;
    public int Price => _price;
    public Sprite Sprite => _sprite;
    public GameObject WeaponPrefab => _weaponPrefab;
    public bool IsBought { get => _isBought; set => _isBought = value; }

    public bool Equals(GameObject other)
    {
        return other == _weaponPrefab;
    }
}
