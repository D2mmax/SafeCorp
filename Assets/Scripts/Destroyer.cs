using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject gameObjecttoDestroy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Tab or Escape was pressed.");
            DestroyHere();
        }
        
    }

    public void DestroyHere()
    {
        if (gameObjecttoDestroy != null)
        {
           Destroy(gameObjecttoDestroy); 
        }
    }
}
