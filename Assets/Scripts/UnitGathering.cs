using UnityEngine;
using UnityEngine.AI;

public class UnitGathering : MonoBehaviour
{
    private NavMeshAgent agent;

    public float metalStoppingDistance = 1.5f;
    public float fuelStoppingDistance = 2.5f;
    public float normalStoppingDistance = 0.5f;

    public float metalGatherRate = 1f; // 1 metal per second
    public float fuelGatherRate = 1f;  // 1 fuel per second

    private GameObject currentResourceTarget;
    private string currentResourceTag;
    private float gatherTimer = 0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void GatherMaterial(GameObject target)
    {
        if (target == null)
        {
            StopGathering();
            return;
        }

        currentResourceTarget = target;
        currentResourceTag = target.tag;

        // Adjust stopping distance based on resource type
        if (currentResourceTag == "Metal")
        {
            agent.stoppingDistance = metalStoppingDistance;
        }
        else if (currentResourceTag == "Fuel")
        {
            agent.stoppingDistance = fuelStoppingDistance;
        }

        agent.SetDestination(target.transform.position);
    }

    private void Update()
    {
        // If there's no target, do nothing
        if (currentResourceTarget == null) return;

        float distance = Vector3.Distance(transform.position, currentResourceTarget.transform.position);
        float stoppingDistance = currentResourceTag == "Metal" ? metalStoppingDistance : fuelStoppingDistance;

        // If we are within range of the target, start gathering
        if (!agent.pathPending && agent.remainingDistance <= stoppingDistance)
        {
            agent.ResetPath();

            gatherTimer += Time.deltaTime;

            float gatherRate = currentResourceTag == "Metal" ? metalGatherRate : fuelGatherRate;

            if (gatherTimer >= 1f / gatherRate)
{
    ResourceHealth resourceHealth = currentResourceTarget.GetComponent<ResourceHealth>();

    if (resourceHealth != null && resourceHealth.TakeResource(1))
    {
        if (currentResourceTag == "Metal")
        {
            ResourceManager.Instance.AddResource("Metal", 1);
        }
        else if (currentResourceTag == "Fuel")
        {
            ResourceManager.Instance.AddResource("Fuel", 1);
        }
    }
    else
    {
        StopGathering();
    }

    gatherTimer = 0f;
}
        }
        else
        {
            gatherTimer = 0f; // Reset if not in range
        }
    }

    public void StopGathering()
    {
        currentResourceTarget = null;
        currentResourceTag = "";
        gatherTimer = 0f;
        agent.stoppingDistance = normalStoppingDistance;
    }
}
