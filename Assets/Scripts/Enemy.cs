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
        target.takeDamage(damage);
    }

    public void EnemyTakeDamage(int dmg, Character chara) {
        if(!isAlive()) return;
        health -= (immune) ? 0 : dmg;
        hpBar.SetHealth(health);
        if(reflection) {
            chara.takeDamage((immune) ? 0 : Mathf.FloorToInt(dmg / 2));
            reflection = false;
        }
        immune = false;

        if(!isAlive()) {
            Debug.Log(charaName + " died");
            playDeath();
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
                damage = 0;
                speed = 2;
                break;
            case 3:
                damage = 10;
                speed = 2;
                break;
            case 4:
                damage = 0;
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
                anim.Play("Golem_earthquake", 0, 0);
                aoeAtk(2);
                break;
            case 1:
                //single strike
                anim.Play("Golem_single", 0, 0);
                attack();
                break;
            case 2:
                //enrage
                anim.Play("Golem_enrage", 0, 0);
                heal(150);
                speedChange(-2);
                break;
            case 3:
                //inspire
                anim.Play("Golem_inspire", 0, 0);
                aoeAtk(0);
                immune = true;
                break;
            case 4:
                //reflect
                anim.Play("Golem_reflect", 0, 0);
                reflection = true;
                break;
            default:
                break;
        }
    }

    private void aoeAtk(int speed) {
        warrior.takeDamage(damage);
        mage.takeDamage(damage);
        thief.takeDamage(damage);
        warrior.speedChange(speed);
        mage.speedChange(speed);
        thief.speedChange(speed);
    }

    public void resetImmune() {
        immune = false;
    }

    public override void playDeath() {
        anim.Play("Golem_death", 0, 0);
    }
}
