using UnityEngine;

public class RemoveSelector : MonoBehaviour
{
    public GameObject objectToToggle;

    private void OnEnable()
    {
        if (objectToToggle != null)
            objectToToggle.SetActive(false);
    }

    private void OnDisable()
    {
        if (objectToToggle != null)
            objectToToggle.SetActive(true);
    }
}
