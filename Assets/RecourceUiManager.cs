using TMPro; // Import TextMeshPro namespace
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    public TMP_Text metalText; // TextMeshPro component for Metal
    public TMP_Text fuelText;  // TextMeshPro component for Fuel

    private void Start()
    {
        // Initial UI update
        UpdateUI();
    }

    private void Update()
    {
        // Continuously update the UI with the current resource values
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Get current resource values from ResourceManager
        int metalAmount = ResourceManager.Instance.GetResourceAmount("Metal");
        int fuelAmount = ResourceManager.Instance.GetResourceAmount("Fuel");

        // Update the UI text
        metalText.text = "Metal: " + metalAmount.ToString();
        fuelText.text = "Fuel: " + fuelAmount.ToString();
    }
}
