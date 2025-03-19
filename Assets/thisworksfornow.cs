using UnityEngine;

//THIS WORKS TRUST 
public class thisworksfornow : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public GameObject[] buttons;
    public Camera topCam;
    private Vector3 targetPosition;
    private bool halt = false; //check for if the player has clicked a valid area 
    private byte x = 1;

    void Start()
    {
        Vector3 gronker;
        gronker = topCam.transform.position;
        Debug.Log(gronker); 
    }

    void Update()
    {
        if (halt == false)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)); 
            targetPosition = new Vector3(mousePosition.x, transform.position.y, mousePosition.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //function to check for click (shoot raycast, ignore player tagged objects, if hit "Enemy" dont halt, else halt)
            CheckForClick();
        }
        else if (halt == true && x == 1)
        {
            x += 1;
            Halt();
        }
        else if (halt == true && x > 1)
        {
            //halted
        }
        else
        {
            Debug.LogWarning("smth has gone wrong man");
        }
    }

    void CheckForClick()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag("Player")) //the cursor
                    continue;

                else if (hit.collider.CompareTag("Enemy")) //high enemy density areas
                {
                    halt = false;
                    return;
                }
                else if (hit.collider.CompareTag("Ground"))
                {
                    halt = true;
                    TPtoTarget();
                    return;
                }
                else
                {
                    Debug.LogWarning("Click out of bounds");
                    return;
                }
            }
        }
    }

    private void TPtoTarget()
    {
        if (halt) 
        {
            transform.position = targetPosition;
        }
    }



    private void Halt()
    {
        //Maybe add a camera zoom ltr here (og camera pos stored as "gronker")
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
        Debug.Log("Halting");
    }

    public void Confirm()
    {
        //1. Zoom in and fade to black
        //2. Load next scene in the build settings
        //3. Rest comes AFTER map has been finalized
    }
     public void GoBack()
     {
        //broad reset of everything called in HAlt()
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        halt = false;
        x = 1;
     }
}

