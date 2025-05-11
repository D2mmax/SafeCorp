using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipFuelManager : MonoBehaviour
{
    public Slider fuelSlider;
    public TextMeshProUGUI fuelPercentageText;
    
    private void Start()
    {
        UpdateFuelPercentageText();
    }

    public void AddFuelPercentage(float percent)
    {
        int currentFuel = ResourceManager.Instance.GetResourceAmount("Fuel");
        int maxSliderValue = 100;

        int fuelToAdd = Mathf.RoundToInt(maxSliderValue * percent);

        if (currentFuel >= fuelToAdd)
        {
            fuelSlider.value = Mathf.Clamp(fuelSlider.value + fuelToAdd, 0, maxSliderValue);
            ResourceManager.Instance.AddResource("Fuel", -fuelToAdd);
            UpdateFuelPercentageText();
        }
        else
        {
            Debug.Log("Not enough fuel to add " + fuelToAdd + "%.");
        }
    }

    private void UpdateFuelPercentageText()
    {
        fuelPercentageText.text = fuelSlider.value.ToString("F0") + "%";
    }
}
