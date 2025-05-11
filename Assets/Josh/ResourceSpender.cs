using UnityEngine;

public class ResourceSpender : MonoBehaviour
{
    public GameObject unitPrefab;      // Unit to spawn
    public Transform spawnPoint;       // Where to spawn it

    public int metalCost = 20;         // Cost in metal
    public int fuelCost = 10;          // Cost in fuel

    public void SpendResources()
    {
        int currentMetal = ResourceManager.Instance.GetResourceAmount("Metal");
        int currentFuel = ResourceManager.Instance.GetResourceAmount("Fuel");

        if (currentMetal >= metalCost && currentFuel >= fuelCost)
        {
            ResourceManager.Instance.AddResource("Metal", -metalCost);
            ResourceManager.Instance.AddResource("Fuel", -fuelCost);
            Debug.Log($"Spent {metalCost} metal and {fuelCost} fuel. Remaining: {currentMetal - metalCost} metal, {currentFuel - fuelCost} fuel");

            SpawnUnit();
        }
        else
        {
            Debug.LogWarning("Not enough resources to spawn unit.");
        }
    }

    private void SpawnUnit()
    {
        if (unitPrefab != null && spawnPoint != null)
        {
            Instantiate(unitPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Unit prefab or spawn point not assigned.");
        }
    }
}
