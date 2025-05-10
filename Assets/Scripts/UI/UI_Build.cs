using UnityEngine;
using UnityEngine.UI;

public class UI_Build : MonoBehaviour
{
    [SerializeField] Button _finishWeaponButton;

    private void Start()
    {
        _finishWeaponButton.onClick.AddListener(OnFinishButtonClick);
    }
    public void ToggleFinishWeaponButton(bool status)
    {
        _finishWeaponButton.gameObject.SetActive(status);
    }

    public void OnFinishButtonClick()
    {
        UIManager.Instance.FadeInFadeOut();
    }
}
