using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string charaName;
    public bool avaTurn;
    public GameObject canvas;
    public HealthBar hpBar;
    public Dictionary<int, string> abilities;
    public int health, maxHealth, damage = 0, incomingDamage = 0, speed = 0, decSpeed = 0, dmgIncrease = 0;
    public int hpPot = 2, item1, item2;
    public Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public Dictionary<int, string> getAbilities()
    {
        return abilities;
    }

    public virtual void takeDamage(int dmg) {
        if(!isAlive()) return;
        health -= dmg;
        hpBar.SetHealth(health);
        Debug.Log(charaName + " took " + dmg + " dmg");
        if(!isAlive()) {
            Debug.Log(charaName + " died");
            this.playDeath();
        }
    }

    public void heal(int val) {
        if(!isAlive()) return;
        health = ((health + val) > maxHealth) ? maxHealth : health + val;
        hpBar.SetHealth(health);
    }

    public void death() {
        //play death animation here
        Debug.Log(this.charaName + " has died!");
        Destroy(gameObject);
        hpBar.death();
    }

    public virtual void refreshTurn() {
        if(isAlive()) {
            avaTurn = true;
        }
        damage = 0;
        speed = 0;
    }

    public void usedMove() {
        avaTurn = false;
    }

    public void enableCanvas() {
        canvas.SetActive(true);
    }

    public void disableCanvas() {
        canvas.SetActive(false);
    }

    public void Reset() {
        if(isAlive()) {
            avaTurn = true;
        }
    }

    public bool hasMove() {
        return avaTurn;
    }

    public bool isAlive() {
        return health > 0;
    }

    public void speedChange(int val) {
        decSpeed += val;
    }

    public void dmgInc(int val) {
        dmgIncrease += val;
    }

    public bool hasRemaining(int id) {
        switch(id) {
            case 4:
                if(hpPot > 0) {
                    return true;
                }
                break;
            case 5:
                if(item1 > 0) {
                    return true;
                }
                break;
            case 6:
                if(item2 > 0) {
                    return true;
                }
                break;
            default:
                return false;
        }
        return false;
    }

    public virtual void attack() {
        Debug.Log("you shouldn't be here");
    }

    public virtual void execute(int val) { }

    public int getSpeed() { return speed + decSpeed; }

    public virtual void playDeath() { }
}
