using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitCounter : MonoBehaviour
{
    public TextMeshProUGUI totalUnitsText;  // UI Text for total units on the field
    public TextMeshProUGUI selectedUnitsText;  // UI Text for selected units

    private void Update()
    {
        UpdateUnitCount();
        UpdateSelectedUnitCount();
    }

    private void UpdateUnitCount()
    {
        int totalUnits = UnitSelectionManager.Instance.allUnitsList.Count; // Counts all units in the scene
        totalUnitsText.text = "" + totalUnits.ToString("D2");
    }

    private void UpdateSelectedUnitCount()
    {
        if (UnitSelectionManager.Instance != null)
        {
            int selectedUnits = UnitSelectionManager.Instance.unitsSelected.Count; // Counts selected units
            selectedUnitsText.text = "" + selectedUnits.ToString("D2");
        }
    }
}
