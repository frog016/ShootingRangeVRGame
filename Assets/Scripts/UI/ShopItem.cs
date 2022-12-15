using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    [SerializeField] private Text _statusText;
    [SerializeField] private Image _statusImage;

    public UnityEvent OnClickEvent => _button.onClick;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void ChangeSprite(Sprite sprite)
    {
        _statusImage.sprite = sprite;
    }

    public void ChangeItemStatus(ShopItemStyle itemStyle)
    {
        _statusText.text = itemStyle.Text;
        _statusImage.color = itemStyle.Color;
    }
}
