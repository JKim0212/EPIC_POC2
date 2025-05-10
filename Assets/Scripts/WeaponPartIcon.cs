using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponPartIcon : MonoBehaviour
{
    Button _iconButton;
    Image _icon;    
    WeaponPartData _partData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Init(WeaponPartData partData)
    {
        _icon = GetComponent<Image>();
        _partData = partData;
        _icon.sprite = _partData.Sprite;
        _iconButton = GetComponent<Button>();
        _iconButton.onClick.AddListener(OnClickIcon);
    }

    public void OnClickIcon()
    {
        GameObject weaponPart = Instantiate(DataManager.Instance.WeaponPartPrefab, BuildManager.Instance.DragParent.transform);
        weaponPart.GetComponent<WeaponPart>().Init(_partData);
        WeaponPart.weaponPartDragged = weaponPart.GetComponent<WeaponPart>();
    }




}
