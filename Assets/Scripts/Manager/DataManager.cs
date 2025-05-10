using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance => _instance;
    public List<WeaponPartData> PartData => _partData;
    public List<WeaponPartData> OwnedPartData => _ownedPartData;
    public GameObject WeaponPartPrefab => _weaponPartPrefab;
    public GameObject PartIconPrefab => _partIconPrefab;
    static DataManager _instance;

    List<WeaponPartData> _partData;
    List<WeaponPartData> _ownedPartData;
    GameObject _weaponPartPrefab;
    GameObject _partIconPrefab;
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
        Init();
    }

    void Init()
    {
        _partData = new List<WeaponPartData>(Resources.LoadAll<WeaponPartData>("Data"));
        _ownedPartData = new List<WeaponPartData>(_partData);
        _weaponPartPrefab = Resources.Load<GameObject>("Prefabs/PartPrefab");
        _partIconPrefab = Resources.Load<GameObject>("Prefabs/IconPrefab");
    }

}
