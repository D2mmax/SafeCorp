using UnityEngine;

public class TargetSelectionManager : MonoBehaviour
{
    private Camera cam;
    public static TargetSelectionManager Instance;
    public LayerMask Clickable;
    public GameObject targetMarkerPrefab;  // Reference to the TargetMarker prefab

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && UnitSelectionManager.Instance.unitsSelected.Count > 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Clickable))
            {
                if (hit.collider.CompareTag("Enemy") || hit.collider.CompareTag("Recourse"))
                {
                    AssignTarget(hit.collider.gameObject);
                }
            }
        }
    }

    private void AssignTarget(GameObject newTarget)
    {
        // Instantiate the target marker at the target's position
        // Instantiate the target marker at the target's position, rotated correctly
        GameObject marker = Instantiate(targetMarkerPrefab, newTarget.transform.position, Quaternion.Euler(0f, 0f, -180f)); // Adjust rotation

        marker.transform.position = new Vector3(marker.transform.position.x, 0.02f, marker.transform.position.z);
        // Destroy the marker after 2 seconds
        Destroy(marker, 2f);

        // Assign the target to all selected units
        foreach (var unit in UnitSelectionManager.Instance.unitsSelected)
        {
            unit.GetComponent<UnitMovement>().currentTarget = newTarget;
        }
    }
}
