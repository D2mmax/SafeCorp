using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private StatScript statScript;

    [SerializeField] private float hp; 
    private float damageReduction;
    private string personalID;

    // Start is called before the first frame update
    void Start()
    {
        statScript = GetComponent<StatScript>();

        if (statScript == null)
        {
            Debug.LogError("No StatScript found on this object!");
        }

        hp = statScript.health;
        damageReduction = statScript.dmgRed;
        personalID = statScript.ID;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTakeDamage(float dmg, float ArmorPiercing, string ID)
    {
        Debug.Log("DMG TAKEN!");
        float Armor = damageReduction - ArmorPiercing;
        if (Armor < 0 )
        {
            Armor = 0;
            hp = hp - dmg;
            Debug.Log($"Guard {ID} hit Alien {personalID} for {dmg} damage!");
        }
        else 
        {
            float DealtDmg = dmg - Armor;
            hp = hp - DealtDmg;
            Debug.Log($"Guard {ID} hit {personalID} for {DealtDmg} damage!");
        }

        if (hp <= 0)
        {
            Die();
        }

    
    }
    private void Die()
    {
        Debug.Log(statScript.ID + " has been destroyed!");
        Destroy(gameObject);
    }
}
