using UnityEngine;

public class MetalSpender : MonoBehaviour
{
    public GameObject unitPrefab;           // Unit spawning in
    public Transform spawnPoint;            // The spawn location

    public void SpendMetal(int metalAmount)
    {
        int currentMetal = ResourceManager.Instance.GetResourceAmount("Metal");

        if (currentMetal >= metalAmount)
        {
            ResourceManager.Instance.AddResource("Metal", -metalAmount);
            Debug.Log($"Spent {metalAmount} metal. Remaining: {ResourceManager.Instance.GetResourceAmount("Metal")}");

            SpawnUnit();
        }
        else
        {
            Debug.LogWarning($"Not enough metal to spend {metalAmount}.");
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
            Debug.LogError("Unit prefab or spawn point is not assigned.");
        }
    }
}
