using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    private Animator animator;
    
   
    public UnitSelectionManager selectionManager;
    public GameObject currentTarget;


    private void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        if (selectionManager == null)
        {
            selectionManager = FindObjectOfType<UnitSelectionManager>();  // Find it if not assigned
        }
    }

    private void Update()
{
    if (Input.GetMouseButtonDown(1) && UnitSelectionManager.Instance.unitsSelected.Count > 0) // Right-click while units are selected
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // Check if something was clicked
        {
            GameObject clickedObject = hit.collider.gameObject;

            
            
            if (((1 << clickedObject.layer) & LayerMask.GetMask("Ground")) != 0) // If clicked on ground
            {
                currentTarget = null;
                // animator.SetBool("isAttacking", false);   
                MoveUnitsToPosition(hit.point);
            }
        }
    }
    if (currentTarget != null)
            {
                
                FollowTarget(currentTarget); // Move towards the target
            }
}

// Move unit towards its current target
private void FollowTarget(GameObject currentTarget)
{
    if (currentTarget == null) return;

    NavMeshAgent unitAgent = GetComponent<NavMeshAgent>();
    Animator unitAnimator = GetComponentInChildren<Animator>();

    unitAgent.SetDestination(currentTarget.transform.position); // Move towards the target
    unitAnimator.SetBool("isMoving", true);
}


    // Move all selected units to a target position
    private void MoveUnitsToPosition(Vector3 targetPosition)
    {
        foreach (var unit in UnitSelectionManager.Instance.unitsSelected)
        {
            NavMeshAgent unitAgent = unit.GetComponent<NavMeshAgent>();
            Animator unitAnimator = unit.GetComponentInChildren<Animator>();

            unitAgent.SetDestination(targetPosition);  // Move the unit
            unitAnimator.SetBool("isMoving", true); // Set the moving animation
        }
    }
    private void AttackTarget()
    {
        if (currentTarget == null) return;
        
        agent.ResetPath(); // Stop movement
        animator.SetBool("isMoving", false);
        animator.SetTrigger("Attack"); // Play attack animation

        // Add attack logic here (e.g., damage)
        Debug.Log(gameObject.name + " is attacking " + currentTarget.name);
        

    }

    private void OnTriggerEnter(Collider other)
    {
         if (currentTarget == null)
        {
            return;
        }
        else if(other.gameObject == currentTarget && other.CompareTag("Enemy"))
        {
            AttackTarget(); // Start attacking if enemy enters range
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentTarget && other.CompareTag("Enemy"))
        {
            // animator.SetBool("isAttacking", false);
            if (currentTarget != null)
            {
                FollowTarget(currentTarget); // Resume following if target leaves attack range
            }
        }
    }

    
    
   
}
   
