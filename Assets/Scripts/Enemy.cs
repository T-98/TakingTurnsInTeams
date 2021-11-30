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
        health = 500;
        avaTurn = false;
    }

    public void pickTarget(Character tar) {
        target = tar;
    }

    public override void heal(int val) {
        health = ((health + val) > 500) ? 500 : health + val;
    }

    public override void attack() {
        //later this will queue up moves
        Debug.Log(this.name + " attacked " + target.name);
        target.takeDamage(10);
    }

    public void EnemyTakeDamage(int dmg, Character chara) {
        health -= (immune) ? 0 : dmg;
        if(reflection) {
            chara.takeDamage((immune) ? 0 : Mathf.FloorToInt(dmg / 2));
        }
    }

    public override void execute(int val) {
        switch(val) {
            case 0:
                //earthquake
                aoeAtk(20, 2);
                break;
            case 1:
                //single strike
                target.takeDamage(50);
                break;
            case 2:
                //enrage
                heal(150);
                speedChange(-2);
                break;
            case 3:
                //inspire
                immune = true;
                aoeAtk(10, 0);
                break;
            case 4:
                //reflect
                reflection = true;
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
