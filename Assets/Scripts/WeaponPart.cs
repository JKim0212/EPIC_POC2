using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponPart : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static WeaponPart weaponPartDragged;
    public WeaponPartData PartData => _partData;
    public Part PartName => _partName;
    Image _partImage;
    Transform pastParent;
    WeaponPartData _partData;
    Part _partName;

    public void Init(WeaponPartData data)
    {
        _partImage = GetComponent<Image>();
        _partData = data;
        _partName = _partData.Part;
        _partImage.sprite = _partData.Sprite;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        weaponPartDragged = this;
        pastParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == BuildManager.Instance.DragParent.transform)
        {
            transform.position = eventData.position;
        } else
        {
            Debug.Log("here");
            transform.position = transform.parent.position;
        }
            weaponPartDragged = null;
    }

}
