using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        BuildManager.Instance.RemovePart(WeaponPart.weaponPartDragged);
        Destroy(WeaponPart.weaponPartDragged.gameObject);
        WeaponPart.weaponPartDragged = null;
    }
}
