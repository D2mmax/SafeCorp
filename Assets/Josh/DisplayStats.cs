using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public StatScript weaponStats;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI rangeText;
    public TextMeshProUGUI metalText;
    public TextMeshProUGUI fuelText;

    private bool lastUpgradeState;

    private void OnEnable()
    {
        lastUpgradeState = weaponStats.Upgraded;
        RefreshStats();
    }

    private void Update()
    {
        // Check if upgrade status changed
        if (weaponStats.Upgraded != lastUpgradeState)
        {
            lastUpgradeState = weaponStats.Upgraded;
            RefreshStats();
        }
    }

    private void RefreshStats()
    {
        healthText.text = "Health: " + weaponStats.health;
        damageText.text = "Damage: " + weaponStats.dmg;
        rangeText.text = "Range: " + weaponStats.range;
        metalText.text = "Metal: " + weaponStats.metalPrice;
        fuelText.text = "Fuel: " + weaponStats.fuelPrice;
    }
}
