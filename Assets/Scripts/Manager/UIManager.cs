using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => _instance;

    static UIManager _instance;


    [SerializeField] TextMeshProUGUI _wealthText;

    UI_Reqeust _ui_requestCanvas;
    UI_Build _ui_buildCanvas;
    UI_WeaponStats _ui_weaponStats;
    UI_FadeInFadeOut _ui_fade;
    UI_FinishBuild _ui_finishCanvas;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _ui_requestCanvas = FindAnyObjectByType<UI_Reqeust>();
        _ui_buildCanvas = FindAnyObjectByType<UI_Build>();
        _ui_weaponStats = FindAnyObjectByType<UI_WeaponStats>();
        _ui_fade = FindAnyObjectByType<UI_FadeInFadeOut>();
        _ui_finishCanvas = FindAnyObjectByType<UI_FinishBuild>();
    }

    public void ChangeToRequest()
    {
        _ui_buildCanvas.GetComponent<Canvas>().enabled = false;
        _ui_finishCanvas.GetComponent<Canvas>().enabled = false;
        _ui_requestCanvas.GetComponent<Canvas>().enabled = true;
    }
    public void ChangeToBuild()
    {
        _ui_requestCanvas.GetComponent<Canvas>().enabled = false;
        _ui_finishCanvas.GetComponent<Canvas>().enabled = false;
        _ui_buildCanvas.GetComponent<Canvas>().enabled = true;
        UpdateWeaponStats(false);
    }

    public void UpdateWeaponStats(bool isWeaponReady)
    {
        _ui_weaponStats.UpdateStats(BuildManager.Instance.Stats, RequestManager.Instance.CurrentRequest);
        ToggleFinishWeaponButton(isWeaponReady);
    }

    void ToggleFinishWeaponButton(bool status)
    {
        _ui_buildCanvas.ToggleFinishWeaponButton(status);
    }

    public void FadeInFadeOut()
    {
        _ui_fade.FadeinFadeout();
    }

    public void ChangeToFinishBuild()
    {
        _ui_requestCanvas.GetComponent<Canvas>().enabled = false;
        _ui_finishCanvas.GetComponent<Canvas>().enabled = true;
        _ui_buildCanvas.GetComponent<Canvas>().enabled = false;
        _ui_finishCanvas.AssembleWeapon(BuildManager.Instance.WeaponParts);
    }

    public void UpdateWealthUI() 
    {
        _wealthText.SetText(GameManager.Instance.Wealth.ToString());
    }
}
