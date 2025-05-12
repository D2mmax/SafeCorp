using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCam : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject Dropship;
    public GameObject PopUp;

    public InstantiateDropship Plane;

    void CallSetUp()
    {
        mainCam.SetActive(false);
        Dropship.SetActive(false);
        PopUp.SetActive(true);
        Plane.enabled = true;   
    }
}
