using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    private int metalAmount = 0;
    private int fuelAmount = 0;

    private void Awake()
    {
        // Ensure there is only one instance of the ResourceManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Function to add resources
    public void AddResource(string resourceName, int amount)
    {
        if (resourceName == "Metal")
        {
            metalAmount += amount;
        }
        else if (resourceName == "Fuel")
        {
            fuelAmount += amount;
        }
    }

    // Function to retrieve resource amounts
    public int GetResourceAmount(string resourceName)
    {
        if (resourceName == "Metal")
        {
            return metalAmount;
        }
        else if (resourceName == "Fuel")
        {
            return fuelAmount;
        }
        return 0; // Return 0 if the resource name is not recognized
    }
}
