using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPartData", menuName = "Scriptable Objects/WeaponPartData")]
public class WeaponPartData : ScriptableObject
{

    public Sprite Sprite => _sprite;
    public float Accuracy => _accuracy;
    public float Weight => _weight;
    public float Ammo => _ammo;
    public float Ergonomics => _ergonomics;
    public float Durability => _durability;
    public Part Part => _part;
    public float Price => _price;

    [SerializeField] Sprite _sprite;
    [SerializeField] float _accuracy;
    [SerializeField] float _weight;
    [SerializeField] float _ammo;
    [SerializeField] float _ergonomics;
    [SerializeField] float _durability;
    [SerializeField] Part _part;
    [SerializeField] float _price;
}
