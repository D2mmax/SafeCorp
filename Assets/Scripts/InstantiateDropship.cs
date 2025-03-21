using UnityEngine;

public class InstantiateDropship : MonoBehaviour
{
    public Transform plane2; 
    public GameObject objectToSpawn;
    public float scaleFactor = 2.0f; // Adjust based on plane size ratio

    void Start()
    {
        // Retrieve stored position
        Vector3 storedLocalPosition = thisworksfornow.GetStoredPosition();
        Vector3 newLocalPosition = storedLocalPosition * scaleFactor;
        Vector3 spawnPosition = plane2.TransformPoint(newLocalPosition);

        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}

