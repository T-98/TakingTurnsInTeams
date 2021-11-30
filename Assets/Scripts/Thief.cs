using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Character
{
    public Character enemy;
    private string[] abilityNames = { "Quick Stab", "Roll the Dice", "Rage Swipes", "Coin Toss", "Health Potion", "Final Feint", "Lucky Charm" };
    private double health = 60, damage = 0, incomingDamage = 0, speed = 0, decSpeed = 0;

    public override void attack() {
        Debug.Log(this.name + " attacked " + enemy.name);
        enemy.takeDamage(10);
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

    //A simple slash that does 40 damage, Speed: 1
    public void quickstab()
    {
        damage = 40;
        speed = 1;
    }

    //Randomly obtain a number from 1 to 6. Your party will receive a buff dependent on the number you receive. The higher the number the better the buff, Speed 2
    public void rolldice()
    {
        speed = 2;
    }

    //A multi-strike attack that does 25 damage each hit up to 4 times. Each hit is dependent on luck (rolls a number from 0 to 4), Speed: 2 (avg:50)
    //(random buff dmg adds on top of final value) 
    public void rageswipes()
    {
        speed = 2;
    }

    //Flip a coin, If heads deal 70 damage. If tails deal 0 damage, Speed: 2
    public void cointoss()
    {
        speed = 2;
    }

    //Health Potion x2 - Recovers 50 HP
    public void healthpotion()
    {
        speed = 1;
    }

    //Final Feint x1 - Resurrects the Thief at full HP upon death
    public void finalfeint()
    {
        speed = 1;
    }

    //Lucky Charm x1 - Increases luck for the next skill used
    public void luckycharm()
    {
        speed = 1;
    }

    public override void heal(int val)
    {
        if (health == 60) Debug.Log("cannot heal any further");
        else
        {
            health += val;
            if (health > 60) health = 60;
        }
    }

    public override void execute(int val)
    {
        switch (val)
        {
            case 1: //roll the dice
                int randomNumber = UnityEngine.Random.Range(1, 7);
                switch (randomNumber)
                {
                    //this is where these go
                    case 1: //decrease team speed by 1 next turn 
                    case 2: //decrease team speed by 2 next turn
                    case 3: //decrease team speed by 3 next turn
                    case 4: //increase team damage by 10 next turn
                    case 5: //increase team damage by 20 next turn
                    case 6: //increase team damage by 30 next turn

                    default:
                        Debug.Log("Die Rolled");
                        break;
                }
                break;

            case 2: //rage swipes
                int randomNum = UnityEngine.Random.Range(0, 5);
                //randomnumber will decide how many times to trigger the anim
                damage = randomNum * 25;
                attack();
                Debug.Log(randomNum + " Rage Swipes inflicted "+ damage +" damage");
                damage = 0;
                break;

            case 3://coin toss
                int coin = UnityEngine.Random.Range(0, 2);
                if (coin == 0) damage = 70; // heads
                else damage = 0; //tails
                attack();
                //trigger animation
                break;

            case 4:
                if (health == 60) Debug.Log("cannot use potion");
                else
                {
                    health += 50;
                    if (health > 60) health = 60;
                    Debug.Log("healed");
                }
                Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + speed + "\n incomingDamage: " + incomingDamage);
                break;

            case 5:
                //declare a state variable called resurrection, set it to true and check on death if true, then 
                //full hp
                Debug.Log("Resurrect on 0 HP");
                break;

            case 6:
                Debug.Log("Increase Luck");
                break;

            default:
                attack();
                break;
        }
    }
}
