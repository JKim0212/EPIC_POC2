using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Wealth => _wealth;
    public static GameManager Instance => _instance;
    static GameManager _instance;

    int _wealth = 3000;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UIManager.Instance.UpdateWealthUI();
    }

    public void ChangeWealth(int amount)
    {
        _wealth += amount;
        UIManager.Instance.UpdateWealthUI();
    }
}
