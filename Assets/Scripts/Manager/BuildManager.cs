using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance => _instance;

    public GameObject DragParent => _dragParent;
    public List<WeaponPart> WeaponParts => _weaponParts;
    public float[] Stats => _stats;
    static BuildManager _instance;
    List<WeaponPart> _weaponParts;
    float[] _stats;
    [SerializeField] GameObject _dragParent;
    Dictionary<Part, bool> _weaponRequirements;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _weaponParts = new List<WeaponPart>();
        _stats = new float[] { 0, 0, 0, 0, 0, 0 };
        _weaponRequirements = new Dictionary<Part, bool>()
        {
            { Part.Stock, false },
            { Part.Body, false },
            { Part.Magazine, false },
            { Part.Grip, false },
            { Part.Barrel, false },
            { Part.Special, false }
        };
    }

    public void AddPart(WeaponPart part)
    {
        _weaponParts.Add(part);
        WeaponPartData data = part.PartData;
        _stats[0] += data.Accuracy;
        _stats[1] += data.Weight;
        _stats[2] += data.Ammo;
        _stats[3] += data.Ergonomics;
        _stats[4] += data.Durability;
        _stats[5] += data.Price;
        _weaponRequirements[data.Part] = true;
        bool isWeaponReady = _weaponRequirements[Part.Body] && _weaponRequirements[Part.Stock] && _weaponRequirements[Part.Barrel];
        Debug.Log(isWeaponReady);
        UIManager.Instance.UpdateWeaponStats(isWeaponReady);
    }

    public void RemovePart(WeaponPart part)
    {
        WeaponPartData data = part.PartData;
        _stats[0] -= data.Accuracy;
        _stats[1] -= data.Weight;
        _stats[2] -= data.Ammo;
        _stats[3] -= data.Ergonomics;
        _stats[4] -= data.Durability;
        _stats[5] -= data.Price;
        _weaponParts.Remove(part);
        _weaponRequirements[data.Part] = false;
        bool isWeaponReady = _weaponRequirements[Part.Body] && _weaponRequirements[Part.Stock] && _weaponRequirements[Part.Barrel];
        Debug.Log(isWeaponReady);
        UIManager.Instance.UpdateWeaponStats(isWeaponReady);
    }

    public void Reset()
    {
        _stats = new float[] { 0, 0, 0, 0, 0, 0 };
        foreach (WeaponPart part in _weaponParts)
        {
            Destroy(part.gameObject);
        }
        _weaponParts.Clear();

    }
}
