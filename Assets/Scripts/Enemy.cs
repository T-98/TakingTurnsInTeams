using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Character warrior, mage, thief;
    public Character target;
    public bool immune = false;
    public bool reflection = false;

    void Start() {
        hpBar.SetMaxHealth(maxHealth);
        avaTurn = false;
    }

    public void pickTarget(Character tar) {
        target = tar;
    }

    public override void attack() {
        //later this will queue up moves
        Debug.Log(this.name + " attacked " + target.name);
        target.takeDamage(10);
    }

    public void EnemyTakeDamage(int dmg, Character chara) {
        health -= (immune) ? 0 : dmg;
        hpBar.SetHealth(health);
        if(reflection) {
            chara.takeDamage((immune) ? 0 : Mathf.FloorToInt(dmg / 2));
        }
    }

    public void setSpeed(int id) {
        switch(id) {
            case 0:
                damage = 20;
                speed = 5;
                break;
            case 1:
                damage = 50;
                speed = 8;
                break;
            case 2:
                speed = 2;
                break;
            case 3:
                speed = 2;
                break;
            case 4:
                speed = 7;
                break;
            default:
                break;
        }
    }

    public override void execute(int val) {
        switch(val) {
            case 0:
                //earthquake
                aoeAtk(damage, 2);
                Debug.Log("enemy used earthquake");
                break;
            case 1:
                //single strike
                target.takeDamage(damage);
                Debug.Log("enemy used single strike");
                break;
            case 2:
                //enrage
                heal(150);
                speedChange(-2);
                Debug.Log("enemy used enrage");
                break;
            case 3:
                //inspire
                immune = true;
                aoeAtk(damage, 0);
                Debug.Log("enemy used inspire");
                break;
            case 4:
                //reflect
                reflection = true;
                Debug.Log("enemy used reflect");
                break;
            default:
                break;
        }
    }

    private void aoeAtk(int dmg, int speed) {
        warrior.takeDamage(dmg);
        mage.takeDamage(dmg);
        thief.takeDamage(dmg);
        warrior.speedChange(speed);
        mage.speedChange(speed);
        thief.speedChange(speed);
    }
}
