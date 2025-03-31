using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [System.Serializable]
    public class TogglePair
    {
        public GameObject objectToDisable;
        public GameObject objectToEnable;
        public Button toggleButton;
    }

    public TogglePair[] togglePairs; // Array for multiple toggle groups

    private void Start()
    {
        foreach (TogglePair pair in togglePairs)
        {
            if (pair.toggleButton != null)
            {
                pair.toggleButton.onClick.AddListener(() => ToggleObjects(pair));
            }
            else
            {
                Debug.LogError("Toggle Button is missing in one of the toggle pairs!");
            }
        }
    }

    private void ToggleObjects(TogglePair pair)
    {
        if (pair.objectToDisable != null && pair.objectToEnable != null)
        {
            bool isCurrentlyActive = pair.objectToDisable.activeSelf;

            // Enable one, disable the other
            pair.objectToDisable.SetActive(!isCurrentlyActive);
            pair.objectToEnable.SetActive(isCurrentlyActive);
        }
    }
}
