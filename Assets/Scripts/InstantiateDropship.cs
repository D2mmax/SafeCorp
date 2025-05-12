using UnityEngine;

public class InstantiateDropship : MonoBehaviour
{
    public Transform plane2; 
    public GameObject objectToSpawn;
    public float scaleFactor = 2.0f; 

    void Start()
    {
        // Retrieve stored position
        Vector3 storedLocalPosition = thisworksfornow.GetStoredPosition();
        Debug.Log("Please be the same" + storedLocalPosition);
        Instantiate(objectToSpawn, storedLocalPosition * scaleFactor, Quaternion.identity);
    }
    
}

