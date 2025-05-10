using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FinishBuild : MonoBehaviour
{
    [SerializeField] Button _sellButton;
    [SerializeField] Transform[] partPositions; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sellButton.onClick.AddListener(OnClickSellButton);
    }

    public void AssembleWeapon(List<WeaponPart> parts)
    {
        foreach(WeaponPart _part in parts)
        {
            Part pos = _part.PartData.Part;
            switch (pos)
            {
                case Part.Stock:
                    _part.transform.SetParent(partPositions[0]);
                    _part.transform.position = partPositions[0].position;
                    break;
                case Part.Body:
                    _part.transform.SetParent(partPositions[1]);
                    _part.transform.position = partPositions[1].position;
                    break;
                case Part.Barrel:
                    _part.transform.SetParent(partPositions[2]);
                    _part.transform.position = partPositions[2].position;
                    break;
                case Part.Grip:
                    _part.transform.SetParent(partPositions[3]);
                    _part.transform.position = partPositions[3].position;
                    break;
                case Part.Magazine:
                    _part.transform.SetParent(partPositions[4]);
                    _part.transform.position = partPositions[4].position;
                    break;
                case Part.Special:
                    _part.transform.SetParent(partPositions[5]);
                    _part.transform.position = partPositions[5].position;
                    break;
                default:
                    break;
            }
        }
    }

    public void OnClickSellButton()
    {
        float price = BuildManager.Instance.Stats[5];
        GameManager.Instance.ChangeWealth((int)(RequestManager.Instance.CurrentRequest[5] - price));
        BuildManager.Instance.Reset();
        UIManager.Instance.ChangeToRequest();
    }
}
