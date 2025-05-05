using UnityEngine;

public class GameObjectSwitcher : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    private bool hasEnabled = false;

    // Called by the UI button
    public void SwitchObjects()
    {
        if (objectToDisable != null) objectToDisable.SetActive(false);
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
            hasEnabled = true;
        }
    }

    private void Update()
    {
        if (hasEnabled && Input.GetKeyDown(KeyCode.Escape))
        {
            if (objectToEnable != null)
            {
                objectToEnable.SetActive(false);
                hasEnabled = false;
            }
        }
    }
}
