using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponPartSlot : MonoBehaviour, IDropHandler
{

    [SerializeField] Part _partName = Part.Body;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");

        if (WeaponPart.weaponPartDragged.PartName == _partName )
        {
            if (transform.childCount > 0 && transform.GetChild(0) != WeaponPart.weaponPartDragged.transform)
            {
                WeaponPart removedPart = transform.GetChild(0).GetComponent<WeaponPart>();
                BuildManager.Instance.RemovePart(removedPart);
                Destroy(removedPart.gameObject);
            }
            WeaponPart.weaponPartDragged.transform.SetParent(transform);
            WeaponPart.weaponPartDragged.transform.position = transform.position;
            BuildManager.Instance.AddPart(WeaponPart.weaponPartDragged);
        }
        else
        {
            Debug.Log("Wrong Position");
        }

    }
}
