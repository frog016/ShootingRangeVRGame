using UnityEngine;

[CreateAssetMenu(menuName = "Store/Styles/Item", fileName = "ShopItemStyle")]
public class ShopItemStyle : ScriptableObject
{
    [SerializeField] private string _text;
    [SerializeField] private Color _color;

    public string Text => _text;
    public Color Color => _color;
}
