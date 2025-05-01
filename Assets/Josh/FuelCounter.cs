using UnityEngine;
using TMPro;

public class FuelCounter : MonoBehaviour
{
    public TextMeshProUGUI fuelText; // Assign in Inspector
    private int fuelCount = 0; // Tracks fuel collected
    private Camera cam; // Reference to the main camera
    // private GameObject highlightedFuel; // Stores currently highlighted fuel
    // private Color originalColor; // Stores the original color of the fuel

    private void Start()
    {
        cam = Camera.main; // Get the main camera
        UpdateFuelText();
    }

    private void Update()
    {
       // HandleHighlight(); // Check if the player is hovering over a fuel object

        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // If the ray hits something
            {
                if (hit.collider.CompareTag("Fuel")) // If it's a Fuel object
                {
                    CollectFuel(hit.collider.gameObject);
                }
            }
        }
    }

    // private void HandleHighlight()
    // {
    //     Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit)) // If the ray hits something
    //     {
    //         // If it's a Fuel object, highlight it
    //         if (hit.collider.CompareTag("Fuel"))
    //         {
    //             GameObject fuelObject = hit.collider.gameObject;

    //             // Only highlight the new fuel object if it is different from the currently highlighted one
    //             if (highlightedFuel != fuelObject)
    //             {
    //                 ResetHighlight(); // Reset previous highlight
    //                 highlightedFuel = fuelObject;

    //                 // Highlight the new fuel object
    //                 Renderer fuelRenderer = highlightedFuel.GetComponent<Renderer>();
    //                 if (fuelRenderer != null)
    //                 {
    //                     originalColor = fuelRenderer.material.color; // Store original color
    //                     fuelRenderer.material.color = new Color(0.31761f, 1f, 0.4866742f); // Highlight color
    //                 }
    //             }
    //         }
    //     }
    //     else
    //     {
    //         // If the raycast doesn't hit any fuel, reset highlight
    //         ResetHighlight();
    //     }
    // }

    // private void ResetHighlight()
    // {
    //     if (highlightedFuel != null)
    //     {
    //         Renderer fuelRenderer = highlightedFuel.GetComponent<Renderer>();
    //         if (fuelRenderer != null)
    //         {
    //             fuelRenderer.material.color = originalColor; // Restore original color
    //         }
    //         highlightedFuel = null; // Clear the highlighted fuel object
    //     }
    // }

    private void CollectFuel(GameObject fuelObject)
    {
        Debug.Log("Fuel collected: " + fuelObject.name); // Debugging message
        fuelCount++; // Increase fuel count
        UpdateFuelText(); // Update UI

       // ResetHighlight(); // Reset highlight before destroying
        Destroy(fuelObject); // Remove the fuel object
    }

    public bool TrySpendFuel(int amount)
    {
        if (fuelCount >= amount)
        {
            fuelCount -= amount;
            UpdateFuelText();
            return true;
        }

        return false;
    }

    public int GetFuelCount()
    {
        return fuelCount;
    }

    private void UpdateFuelText()
    {
        fuelText.text = fuelCount.ToString("D1"); // Display as single digit
    }
}
