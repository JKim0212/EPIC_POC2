using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_PartsTable : MonoBehaviour
{
    [SerializeField] RectTransform weaponPartsArea;
    [SerializeField] Transform partsTable;
    [SerializeField] float moveSpeed;
    Vector3 closePos = new Vector3(-200, 250, 0);
    Vector3 openPos = new Vector3(-200, -250, 0);
    [SerializeField] Button _openButton;
    bool _isOpen = false;
    void Start()
    {
        foreach (WeaponPartData data in DataManager.Instance.OwnedPartData)
        {
            GameObject partIcon = Instantiate(DataManager.Instance.PartIconPrefab, partsTable);
            partIcon.GetComponent<WeaponPartIcon>().Init(data);
        }
        _openButton.onClick.AddListener(OnOpenWeaponParts);
    }

    public void OnOpenWeaponParts()
    {
        if (!_isOpen)
        {
            _openButton.interactable = false;
            _isOpen = true;
            StartCoroutine(MoveCoroutine(openPos));
        } else
        {
            _openButton.interactable = false;
            _isOpen = false;
            StartCoroutine(MoveCoroutine(closePos));
        }
    }

    IEnumerator MoveCoroutine(Vector3 targetPos)
    {
        while(Vector3.Distance(weaponPartsArea.anchoredPosition, targetPos) > 0.01f)
        {
            weaponPartsArea.anchoredPosition = Vector3.MoveTowards(weaponPartsArea.anchoredPosition, targetPos, moveSpeed);
            yield return null;
        }
        weaponPartsArea.anchoredPosition = targetPos;
        _openButton.interactable = true;
    }
}
