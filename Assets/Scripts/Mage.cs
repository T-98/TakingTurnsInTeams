using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    public Character enemy, warrior, thief;
    private string[] abilityNames = { "Searing Flames", "Electrical Surge", "Infusion", "Haste", "Health Potion", "Sacred Ash"};
    private double health = 100, damage = 0, incomingDamage = 0, speed = 0, decSpeed = 0;
    public override void attack() {
        enemy.takeDamage(damage);
        Debug.Log(this.name + " attacked " + enemy.name);
    }
    private void Start()
    {
        loadAbilities();
        checkAbilities();
    }
    private void loadAbilities()
    {
        abilities = new Dictionary<int, string>();
        for (int i = 0; i < abilityNames.Length; ++i)
        {
            abilities.Add(i, abilityNames[i]);
        }
    }

    //test function to check if abilities dictionary was populated
    void checkAbilities()
    {
        foreach (KeyValuePair<int, string> kv in abilities) Debug.Log(kv.Value.ToString());
    }

    public override void heal(int val)
    {
        if (health == 100) Debug.Log("cannot heal any further");
        else
        {
            health += val;
            if (health > 100) health = 100;
        }
    }

    //A strong fire magic spell that does 40 damage, Speed: 6
    public void searingflames()
    {
        damage = 40;
        speed = 6;
    }

    //A devastating lightning attack that does 20 damage, the Boss’ attack next turn is increased by 3, Speed:7
    public void electricalsurge()
    {
        damage = 20;
        speed = 7;
        //increase bosses's atkdmg
    }

    //A group heal that heals everyone for 30 HP, Speed: 8
    public void infusion()
    {
        speed = 8;
        //group heal
    }

    //A buff that decreases all party members’ speed by 2 in the next turn, Speed : 8
    public void haste()
    {
        speed = 8;
        decSpeed = 2;
    }

    //Health Potion x2 - Recovers 50 HP
    public void healthpotion()
    {
        speed = 1;
    }

    //Sacred Ash x1 - Heals the whole group for 50 HP
    public void sacredash()
    {
        speed = 1;
    }
    public override void execute(int val)
    {
        switch(val)
        {
            case 2:
                heal(30);
                warrior.heal(30);
                thief.heal(30);
                attack();
                break;

            case 3:
                Debug.Log("Decrease speed of all characetrs by 2 in the next turn");
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

            case 5:
                heal(50);
                warrior.heal(50);
                thief.heal(50);
                break;

            default:
                attack();
                break;
        }
    }
}
