using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    public GameObject lightning;
    public Enemy enemy;
    public Character warrior, thief;
    private string[] abilityNames = { "Searing Flames", "Electrical Surge", "Infusion", "Haste", "Health Potion", "Sacred Ash"};

    public override void attack() {
        Debug.Log(this.name + " attacked " + enemy.name);
        enemy.EnemyTakeDamage(damage + dmgIncrease, this);
        dmgIncrease = 0;
        anim = GetComponent<Animator>();
        anim.enabled = true;
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

    //A strong fire magic spell that does 40 damage, Speed: 6
    public void searingflames()
    {
        damage = 40;
        speed = 6 + decSpeed;
        decSpeed = 0;
    }

    //A devastating lightning attack that does 20 damage, the Boss� attack next turn is increased by 3, Speed:7
    public void electricalsurge()
    {
        damage = 20;
        speed = 7 + decSpeed;
        decSpeed = 0;
    }

    //A group heal that heals everyone for 30 HP, Speed: 8
    public void infusion()
    {
        speed = 8 + decSpeed;
        decSpeed = 0;
        //group heal
    }

    //A buff that decreases all party members� speed by 2 in the next turn, Speed : 8
    public void haste()
    {
        speed = 8 + decSpeed;
        decSpeed -= 2;
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

    public void Lightning()
    {
       GameObject l = Instantiate(lightning, enemy.transform.position, Quaternion.identity);
        l.transform.localScale *= 8;
    }
    //group heal func
    //triggered from within the meage_heal animation
    public void groupHeal(int val)
    {
        //code
        heal(val);
        warrior.heal(val);
        thief.heal(val);
        //TODO
    }
    public override void execute(int val)
    {
        Debug.Log("Mage used " + abilityNames[val]);
        switch(val)
        {
            case 0:
                anim.Play("mage_fire", 0, 0);
                attack();
                break;
            case 1:
                enemy.speedChange(3);
                anim.Play("mage_lighting", 0, 0);
                attack();
                break;
            case 2:
                anim.Play("mage_heal", 0, 0);
                groupHeal(30);
                break;
            case 3:
                anim.Play("mage_haste", 0, 0);
                speedChange(-2);
                warrior.speedChange(-2);
                thief.speedChange(-2);
                break;
            case 4:
                health += 50;
                hpPot--;
                if (health > 150) health = 150;
                break;
            case 5:
                //heal(50);
                item1--;
                anim.Play("mage_heal", 0, 0);
                groupHeal(50);
                break;
            default:
                break;
        }
    }

    public override void playDeath() {
        anim.Play("mage_death", 0, 0);
    }
}
