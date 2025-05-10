using UnityEngine;
using UnityEngine.UI;
public class UI_Reqeust : MonoBehaviour
{

    Button _buildWeaponButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _buildWeaponButton = GetComponentInChildren<Button>();
        _buildWeaponButton.onClick.AddListener(OnRequestClick);
    }

    public void OnRequestClick()
    {   
        RequestManager.Instance.GenerateRequest();
        UIManager.Instance.ChangeToBuild();
    }
}
