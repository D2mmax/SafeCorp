using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScript : MonoBehaviour
{
    [Header("Troop Type")] //class type
    [Header("-----------------------------------------------")] 
    [ReadOnly] public string ID;
    public enum GunType{Pistol, AR, Sniper, Rocket, Shield}
    public GunType weaponType;
    public bool Upgraded;

    [Header("Stats")] //stats below (unserialize later)
    [Header("-----------------------------------------------")]
    [ReadOnly] [SerializeField] public float dmg;
    [ReadOnly] [SerializeField] public float dmgRed; //damage Reduction
    [ReadOnly] [SerializeField] public float armorPiercing;
    [ReadOnly] [SerializeField] public float range;
    [ReadOnly] [SerializeField] public float attackSpeed;
    [ReadOnly] [SerializeField] public float speed;
    [ReadOnly] [SerializeField] public float health;
    [ReadOnly] [SerializeField] public float fuelPrice; //consitant stat
    [ReadOnly] [SerializeField] public float metalPrice;
    [ReadOnly] [SerializeField] public bool splashDmg = false;
    [ReadOnly] [SerializeField] public bool melee = false;
    

    private void Start()
    {
        if (gameObject.CompareTag("Unit"))
        {
            GenerateIdentificationNumber();
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            GenerateBug();
        }
    }

    private void OnValidate()
    {
        UpdateStats();
    }

    private void UpdateStats()
    {
        switch (weaponType)
        {
            case GunType.Pistol:
                dmg = 10f;
                dmgRed = 2f;
                armorPiercing = 1f;
                range = 15f;
                attackSpeed = 1.2f;
                speed = 5f;
                health = 80f;
                fuelPrice = 20f;
                metalPrice = 20f;
                splashDmg = false;
                melee = false;
                break;

            case GunType.AR:
                dmg = 15f;
                dmgRed = 3f;
                armorPiercing = 2f;
                range = 20f;
                attackSpeed = 2f;
                speed = 5f;
                health = 100f;
                fuelPrice = 20f;
                metalPrice = 40f;
                splashDmg = false;
                melee = false;
                break;

            case GunType.Sniper:
                dmg = 50f;
                dmgRed = 5f;
                armorPiercing = 10f;
                range = 50f;
                attackSpeed = 0.5f;
                speed = 4f;
                health = 100f;
                fuelPrice = 20f;
                metalPrice = 40f;
                splashDmg = false;
                melee = false;
                break;

            case GunType.Rocket:
                dmg = 30f;
                dmgRed = 3f;
                armorPiercing = 5f;
                range = 25f;
                attackSpeed = 0.8f;
                speed = 3.5f;
                health = 150f;
                fuelPrice = 20f;
                metalPrice = 80f;
                splashDmg = true;
                melee = false;
                break;

            case GunType.Shield:
                dmg = 5f;
                dmgRed = 10f;
                armorPiercing = 0f;
                range = 5f;
                attackSpeed = 1f;
                speed = 4f;
                health = 200f;
                fuelPrice = 20f;
                metalPrice = 60f;
                splashDmg = false;
                melee = true;
                break;
        }
        Boost();
    }

    private void Boost()
    {
        if (Upgraded == true)
        {
            //Upgrade Health, Range, Speed and Damage
            float upgradeMultiplier = Upgraded ? 1.2f : 1.0f; //20% boost
            health = health * upgradeMultiplier; 
            range = range * upgradeMultiplier;
            speed = speed * upgradeMultiplier;
            dmg = dmg * upgradeMultiplier; 
        }
    }

    //I wonder what this next function does
    private void GenerateIdentificationNumber()
    {
        System.Random random = new System.Random();
        char randomLetter = (char)('A' + random.Next(0, 26));
        int digit1 = random.Next(0, 10);
        int digit2 = random.Next(0, 10);
        ID = $"{randomLetter}{digit1}{digit2}";
    }

    //remember: the only good alien is a dead alien, soldier
    private void GenerateBug()
    {
        System.Random random = new System.Random();
        string[] bugglyphsNew;
        bugglyphsNew = new string[9]{"Glor", "Glorb", "Nox", "Quax", "An", "Thwr", "Izx", "Pae", "Lthor"};
        
        string[] glyphsused = new string[2];
        byte x = 0;
        while (x < 2)
        {
            int shuffle = random.Next(0, 8);
            glyphsused[x] = bugglyphsNew[shuffle];
            x += 1;
        }
        ID = $"{glyphsused[0]}{glyphsused[1]}";
    }
}    
