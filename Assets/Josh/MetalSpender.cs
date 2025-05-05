using UnityEngine;

public class MetalSpender : MonoBehaviour
{
    public void SpendMetal(int metalAmount)
    {
        int currentMetal = ResourceManager.Instance.GetResourceAmount("Metal");

        if (currentMetal >= metalAmount)
        {
            ResourceManager.Instance.AddResource("Metal", -metalAmount);
            Debug.Log($"Spent {metalAmount} metal. Remaining: {ResourceManager.Instance.GetResourceAmount("Metal")}");
        }
        else
        {
            Debug.LogWarning($"Not enough metal to spend {metalAmount}.");
        }
    }
}
