using UnityEngine;
using TMPro;

public class UI_WeaponStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI AccText;
    [SerializeField] TextMeshProUGUI WeightText;
    [SerializeField] TextMeshProUGUI AmmoText;
    [SerializeField] TextMeshProUGUI ErgoText;
    [SerializeField] TextMeshProUGUI DuraText;
    [SerializeField] TextMeshProUGUI LackAccText;
    [SerializeField] TextMeshProUGUI LackWeightText;
    [SerializeField] TextMeshProUGUI LackAmmoText;
    [SerializeField] TextMeshProUGUI LackErgoText;
    [SerializeField] TextMeshProUGUI LackDuraText;

    public void UpdateStats(float[] weaponParts, float[] requestStats)
    {
        AccText.SetText($"{weaponParts[0]:00}/{requestStats[0]:00}");
        WeightText.SetText($"{weaponParts[1]:00}/{requestStats[1]:00}");
        AmmoText.SetText($"{weaponParts[2]:00}/{requestStats[2]:00}");
        ErgoText.SetText($"{weaponParts[3]:00}/{requestStats[3]:00}");
        DuraText.SetText($"{weaponParts[4]:00}/{requestStats[4]:00}");
        float[] diff = new float[5];
        for (int i = 0; i < diff.Length; i++)
        {
            diff[i] = requestStats[i] - weaponParts[i];
        }
        if (diff[0] > 0)
        {
            LackAccText.color = Color.red;
        }
        else
        {
            LackAccText.color = Color.green;
        }
        LackAccText.SetText($"{-diff[0]:00}");

        if (diff[1] < 0)
        {
            LackWeightText.color = Color.red;
        }
        else
        {
            LackWeightText.color = Color.green;
        }
        LackWeightText.SetText($"{-diff[1]:00}");

        if (diff[2] > 0)
        {
            LackAmmoText.color = Color.red;
        }
        else
        {
            LackAmmoText.color = Color.green;
        }
        LackAmmoText.SetText($"{-diff[2]:00}");

        if (diff[3] > 0)
        {
            LackErgoText.color = Color.red;
        }
        else
        {
            LackErgoText.color = Color.green;
        }
        LackErgoText.SetText($"{-diff[3]:00}");

        if (diff[4] > 0)
        {
            LackDuraText.color = Color.red;
        }
        else
        {
            LackDuraText.color = Color.green;
        }
        LackDuraText.SetText($"{-diff[4]:00}");

    }
}
