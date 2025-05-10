using UnityEngine;
using UnityEngine.UI;


public class RequestManager : MonoBehaviour
{
    public static RequestManager Instance => _instance;
    public float[] CurrentRequest => _currentRequestData;
    
    static RequestManager _instance;
    float[] _currentRequestData;

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

    public void GenerateRequest()
    {
        float accuracy = Random.Range(15, 30);
        float weight = Random.Range(60, 80);
        float ammo = Random.Range(1, 31);
        float ergo = Random.Range(20, 40);
        float durability = Random.Range(30, 60);
        float priceToPay = Random.Range(1500, 3000);
        float[] newRequest = {accuracy, weight, ammo, ergo, durability, priceToPay};
        _currentRequestData = newRequest;
    }
}
