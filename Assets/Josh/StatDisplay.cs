using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI fuelPriceText;
    public TextMeshProUGUI metalPriceText;

    public void DisplayStats(StatScript statScript)
    {
        if (statScript == null)
        {
            Debug.LogWarning("StatScript is null.");
            return;
        }

        healthText.text = $"Health: {statScript.health}";
        damageText.text = $"Damage: {statScript.dmg}";
        rangeText.text = $"Range: {statScript.range}";
        fuelPriceText.text = $"Fuel Cost: {statScript.fuelPrice}";
        metalPriceText.text = $"Metal Cost: {statScript.metalPrice}";
    }
}
