using UnityEngine;
using UnityEngine.UI;

public class UpgradeActivator : MonoBehaviour
{
    public int metalCost = 50;
    public Button upgradeButton;
    public StatScript targetStats;  // Reference to the StatScript script
    //public DisplayStats displayStats;  // Reference to the DisplayStats script

    void Start()
    {
        if (upgradeButton != null)
            upgradeButton.onClick.AddListener(TryUpgrade);
    }

    void TryUpgrade()
    {
        if (targetStats == null)
        {
            Debug.LogWarning("No StatScript assigned.");
            return;
        }

        if (targetStats.Upgraded)
        {
            Debug.Log("Already upgraded.");
            return;
        }

        int currentMetal = ResourceManager.Instance.GetResourceAmount("Metal");

        if (currentMetal >= metalCost)
        {
            // Spend metal and upgrade
            ResourceManager.Instance.AddResource("Metal", -metalCost);
            targetStats.Upgraded = true;
            //displayStats.StatRefresh();
            Debug.Log("Unit upgraded!");

            // Disable the button
            upgradeButton.interactable = false;
        }
        else
        {
            Debug.Log("Not enough metal.");
        }
    }
}
