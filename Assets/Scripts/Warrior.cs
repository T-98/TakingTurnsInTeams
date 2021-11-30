using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    public Enemy enemy;
    private string[] abilityNames = {"Raging Blow", "Power Slash", "Taunt", "Crescent Shield", "Health Potion", "Berzerker Potion", "Sacrificial Pact"};
    public bool berserk = false;

    public override void attack() {
        Debug.Log(this.name + " attacked " + enemy.name);
        enemy.EnemyTakeDamage(damage + ((berserk) ? 20 : 0), this);
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

    //Health Potion x2 - Recovers 50 HP
    public void healthpotion()
    {
        speed = 1;
    }

    //Berserker Potion x1 - Increase damage output by 20, incoming damage you take is increased by 10
    public void bersekerpotion()
    {
        speed = 1;
        incomingDamage += 10;
        berserk = true;
    }

    //Sacrificial Pact x1 - Kill your character in order to regen the rest of your party members to full health
    public void sacrificialpact()
    {
        //mage.getcomponent<mage>().health = 100;
        speed = 1;
    }

    public override void takeDamage(int dmg) {
        health -= dmg + incomingDamage;
        wasused = false;
    }

    //Blocks 30 damage for next attack, Speed: 2
    public void crescentshield()
    {
        speed = 2 + decSpeed;
        decSpeed = 0;
        wasused = true;
    }

    //A normal basic attack that does 20 damage, Speed: 3
    public void powerslash()
    {
        damage = 20;
        speed = 3 + decSpeed;
        decSpeed = 0;
    }

    //A slow but hefty attack that allows you to do 40 damage, Speed: 10
    public void ragingblow()
    {
        damage = 40;
        speed = 10 + decSpeed;
        decSpeed = 0;
    }

    //Takes aggro of the enemy to use their next ability on warrior (aoe moves are not affected), Speed : 2
    public void taunt()
    {
        speed = 1 + decSpeed;
        decSpeed = 0;
    }

    public override void execute(int val)
    {
        switch (val)
        {
            case 2:
                enemy.pickTarget(this);
                break;
            case 3:
                incomingDamage -= 30;
                break;
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
        Debug.Log("Warrior used " + abilityNames[val]);
    }

    public override void refreshTurn() {
        damage = 0;
        speed = 0;
        incomingDamage = ((berserk) ? 10 : 0) + ((wasused) ? -30 : 0);
        wasused = false;
        avaTurn = true;
    }
}
