using UnityEngine;
using UnityEngine.UI;

public class SelectedItem : MonoBehaviour
{
    [SerializeField] private WeaponShop _shop;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _descriptionText;
    [SerializeField] private Image _image;
    [SerializeField] private Button _buyButton;

    public void ConfigureItem(WeaponStoreData data)
    {
        _nameText.text = data.Name;
        _descriptionText.text = data.Description;
        _image.sprite = data.Sprite;

        _buyButton.interactable = !data.IsBought;
        _buyButton.onClick.RemoveAllListeners();
        _buyButton.onClick.AddListener(() => _shop.TryBuy(data.WeaponPrefab));
    }
}
