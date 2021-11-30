using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    public Character enemy;
    private string[] abilityNames = {"Raging Blow", "Power Slash", "Taunt", "Crescent Shield", "Health Potion", "Berzerker Potion", "Sacrificial Pact"};
    private double health = 150, damage = 0, incomingDamage = 0, speed = 0, decSpeed = 0;

    public override void attack() {
        Debug.Log(this.name + " attacked " + enemy.name);
        enemy.takeDamage(10);
    }

    private void Start()
    {
        loadAbilities();
        //checkAbilities();
    }

    private void loadAbilities()
    {
        abilities = new Dictionary<int, string>();
        for(int i = 0; i < abilityNames.Length; ++i)
        {
            abilities.Add(i, abilityNames[i]);
        }
    }

    //test function to check if abilities dictionary was populated
    void checkAbilities()
    {
        foreach (KeyValuePair<int, string> kv in abilities) Debug.Log(kv.Value.ToString());
    }

    //checks crescent shield usage
    private bool wasused = false;

    private void update()
    {
        if (health == 0)
        {
            Debug.Log("trigger death scene");
            Destroy(this);
        }
    }

    public override void heal(int val)
    {
        if (health == 150) Debug.Log("cannot heal any further");
        else
        {
            health+= val;
            if (health > 150) health = 150;
        }
    }

    //Health Potion x2 - Recovers 50 HP
    public void healthpotion()
    {
        speed = 1;
    }

    //Berserker Potion x1 - Increase damage output by 20, incoming damage you take is increased by 10
    public void bersekerpotion()
    {
        speed = 1;
        incomingDamage = 10;
        damage += 20;
        Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + speed + "\n incomingDamage: " + incomingDamage);
    }

    //Sacrificial Pact x1 - Kill your character in order to regen the rest of your party members to full health
    public void sacrificialpact()
    {
        //mage.getcomponent<mage>().health = 100;
        speed = 1;
    }

    public void damagetaken(double damage, double speed)
    {
        incomingDamage += damage;
        health -= incomingDamage;
        this.speed -= speed;
        Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + this.speed + "\n incomingDamage: " + incomingDamage);
    }

    //Blocks 30 damage for next attack, Speed: 2
    public void crescentshield()
    {
        damagereset();
        incomingDamage -= 30;
        speed = 2;
        wasused = true;
        Debug.Log("health: " + health + " damage: " + damage + " speed: " + speed + " incomingDamage: " + incomingDamage);
    }

    //A normal basic attack that does 20 damage, Speed: 3
    public void powerslash()
    {
        if (wasused == true) incomingDamagereset();
        damagereset();
        damage += 20;
        speed = 3;
        Debug.Log("health: " + health + " damage: " + damage + " speed: " + speed + " incomingDamage: " + incomingDamage);
    }

    //A slow but hefty attack that allows you to do 40 damage, Speed: 10
    public void ragingblow()
    {
        if (wasused == true) incomingDamagereset();
        damagereset();
        damage += 40;
        speed = 10;
        Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + speed + "\n incomingDamage: " + incomingDamage);
    }

    //Takes aggro of the enemy to use their next ability on warrior (aoe moves are not affected), Speed : 2
    public void taunt()
    {
        if (wasused == true) incomingDamagereset();
        damagereset();
        //change enemy target varibale to warrior
    }

    private void incomingDamagereset()
    {
        incomingDamage = 0;
    }
    private void damagereset()
    {
        damage = 0;
    }
    public override void execute(int val)
    {
        switch (val)
        {
            case 4:
                if (health == 150) Debug.Log("cannot use potion");
                else
                {
                    health += 50;
                    if (health > 150) health = 150;
                    Debug.Log("healed");
                }
                Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + speed + "\n incomingDamage: " + incomingDamage);

                break;

            case 6:
                health = 0;
                death();
                Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + speed + "\n incomingDamage: " + incomingDamage);
                break;

            default:
                attack();
                break;
        }
    }
}
