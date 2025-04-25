using UnityEngine;

public class ResourceHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Call this when a unit gathers from this resource
    public bool TakeResource(int amount)
    {
        if (currentHealth <= 0) return false;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            return false;
        }

        return true;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
