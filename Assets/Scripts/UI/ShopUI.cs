using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopItem _itemPrefab;
    [SerializeField] private WeaponShop _shop;
    [SerializeField] private Transform _shopTransform;
    [SerializeField] private SelectedItem _selectedItem;

    [Header("Item visual styles")]
    [SerializeField] private ShopItemStyle _unlockedStyle;
    [SerializeField] private ShopItemStyle _lockedStyle;

    public void FillShop()
    {
        var allItemsData = _shop.GetAllData();
        foreach (var data in allItemsData)
        {
            var item = Instantiate(_itemPrefab, _shopTransform);
            item.ChangeSprite(data.Sprite);
            item.ChangeItemStatus(data.IsBought ? _unlockedStyle : _lockedStyle);
            item.OnClickEvent.AddListener(() => DisplaySelectedItem(data));
        }
    }

    private void DisplaySelectedItem(WeaponStoreData data)
    {
        _selectedItem.ConfigureItem(data);
    }
}
