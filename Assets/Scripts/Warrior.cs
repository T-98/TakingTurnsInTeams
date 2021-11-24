using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public GameObject canvas, mage, thief;
    public double health = 150, damage = 0, incomingDamage = 0, speed = 0;
    private bool wasUsed = false;
    // Start is called before the first frame update

    private void Update()
    {
        if (health == 0)
        {
            Debug.Log("Trigger Death Scene");
            Destroy(this);
        }
    }
    public void enableWarriorCanvas()
    {
        canvas.SetActive(true);
    }

    public void disableWarriorCanvas()
    {
        canvas.SetActive(false);
    }

    public void healthPotion()
    {
        if (health == 150) Debug.Log("Cannot use potion");
        else health += 50;
        Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + speed + "\n incomingDamage: " + incomingDamage);
    }

    public void bersekerPotion()
    {
        incomingDamage = 10;
        damage += 20;
        Debug.Log("health: "+health+"\n damage: "+ damage+ "\n speed: "+speed+"\n incomingDamage: "+ incomingDamage);
    }

    public void sacrificialPact()
    {
        mage.GetComponent<Mage>().health = 100;
        health = 0;
        Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + speed + "\n incomingDamage: " + incomingDamage);
    }

    public void damageTaken(double damage, double speed)
    {
        incomingDamage += damage;
        health -= incomingDamage;
        speed -= speed;
        Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + this.speed + "\n incomingDamage: " + incomingDamage);
    }

    public void crescentShield()
    {
        damageReset();
        incomingDamage -= 30;
        speed = 2;
        wasUsed = true;
        Debug.Log("health: " + health + " damage: " + damage + " speed: " + speed + " incomingDamage: " + incomingDamage);
    }

    public void powerSlash()
    {
        if (wasUsed == true) incomingDamageReset();
        damageReset();
        damage += 20;
        speed = 3;
        Debug.Log("health: " + health + " damage: " + damage + " speed: " + speed + " incomingDamage: " + incomingDamage);
    }

    public void ragingBlow()
    {
        if (wasUsed == true) incomingDamageReset();
        damageReset();
        damage += 40;
        speed = 10;
        Debug.Log("health: " + health + "\n damage: " + damage + "\n speed: " + speed + "\n incomingDamage: " + incomingDamage);
    }

    public void taunt()
    {
        if (wasUsed == true) incomingDamageReset();
        damageReset();
        //change enemy target varibale to warrior
    }

   void incomingDamageReset()
    {
        incomingDamage += 30;
    }
    void damageReset()
    {
        damage = 0;
    }
}
