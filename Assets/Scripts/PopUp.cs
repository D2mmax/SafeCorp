using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject Popup;
    
    void OnTriggerEnter()
    {
        Popup.SetActive(true);
    }
    void OnTriggerExit()
    {
        Popup.SetActive(false);
    }
}
