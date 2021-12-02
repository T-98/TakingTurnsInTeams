using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Character
{
    public Enemy enemy;
    public Character warrior, mage;
    private string[] abilityNames = { "Quick Stab", "Roll the Dice", "Rage Swipes", "Coin Toss", "Health Potion", "Final Feint", "Lucky Charm" };
    public bool lucky = false;
    public bool feint = false;

    public override void attack() {
        Debug.Log(this.name + " attacked " + enemy.name);
        enemy.EnemyTakeDamage(damage, this);
    }

    public override void takeDamage(int dmg) {
        if(!isAlive()) return;
        health -= dmg;
        hpBar.SetHealth(health);
        Debug.Log("Thief took " + dmg + " dmg");
        if(health < 0 && feint) {
            health = maxHealth;
            feint = false;
            Debug.Log("Thief survived from the effects of final feint");
        }
        hpBar.SetHealth(health);

        if(!isAlive()) {
            Debug.Log("Thief died");
            death();
        }
    }

    private void Start()
    {
        hpBar.SetMaxHealth(maxHealth);
        loadAbilities();
        //checkAbilities();
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
        speed = 1 + decSpeed;
        decSpeed = 0;
    }

    //Randomly obtain a number from 1 to 6. Your party will receive a buff dependent on the number you receive. The higher the number the better the buff, Speed 2
    public void rolldice()
    {
        speed = 2 + decSpeed;
        decSpeed = 0;
    }

    //A multi-strike attack that does 25 damage each hit up to 4 times. Each hit is dependent on luck (rolls a number from 0 to 4), Speed: 2 (avg:50)
    //(random buff dmg adds on top of final value) 
    public void rageswipes()
    {
        speed = 2 + decSpeed;
        decSpeed = 0;
    }

    //Flip a coin, If heads deal 70 damage. If tails deal 0 damage, Speed: 2
    public void cointoss()
    {
        speed = 2 + decSpeed;
        decSpeed = 0;
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

    public override void execute(int val)
    {
        Debug.Log("Thief used " + abilityNames[val]);
        switch (val)
        {
            case 0:
                anim.Play("thief_quick", 0, 0);
                attack();
                break;
            case 1: //roll the dice
                int randomNumber = UnityEngine.Random.Range(1, 7);
                anim.Play("thief_dice", 0, 0);
                switch (randomNumber)
                {
                    //this is where these go
                    case 1: //decrease team speed by 1 next turn
                        diceSpeed(-1);
                        break;
                    case 2: //decrease team speed by 2 next turn
                        diceSpeed(-2);
                        break;
                    case 3: //decrease team speed by 3 next turn
                        diceSpeed(-3);
                        break;
                    case 4: //increase team damage by 10 next turn
                        dmgInc(10);
                        warrior.dmgInc(10);
                        mage.dmgInc(10);
                        break;
                    case 5: //increase team damage by 20 next turn
                        dmgInc(20);
                        warrior.dmgInc(20);
                        mage.dmgInc(20);
                        break;
                    case 6: //increase team damage by 30 next turn
                        dmgInc(30);
                        warrior.dmgInc(30);
                        mage.dmgInc(30);
                        break;
                    default:
                        Debug.Log("Die Rolled");
                        break;
                }
                break;
            case 2: //rage swipes
                int randomNum = (lucky) ? 4 : Random.Range(1, 5);
                lucky = false;
                //randomnumber will decide how many times to trigger the anim
                damage = randomNum * 25;
                anim.Play("thief_rage", 0, 0);
                break;
            case 3://coin toss
                int coin = (lucky) ? 1 : Random.Range(0, 2);
                lucky = false;
                if (coin == 0) {
                    damage = 70;
                    anim.Play("thief_heads", 0, 0);
                }
                else {
                    damage = 0;
                    anim.Play("thief_tails", 0, 0);
                }
                
                //trigger animation
                break;
            case 4:
                health += 50;
                if (health > 60) health = 60;
                break;
            case 5:
                feint = true;
                break;
            case 6:
                lucky = true;
                break;
            default:
                break;
        }
    }

    private void diceSpeed(int val) {
        speedChange(val);
        warrior.speedChange(val);
        mage.speedChange(val);
    }
}
