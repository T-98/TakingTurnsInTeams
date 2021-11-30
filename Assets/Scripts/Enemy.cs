using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Character target;
    public int speed = 10;
    public int decSpeed = 0;

    public void pickTarget(Character tar) {
        target = tar;
    }

    public override void attack() {
        //later this will queue up moves
        Debug.Log(this.name + " attacked " + target.name);
        target.takeDamage(10);
    }

    public override int getSpeed() {
        return speed + decSpeed;
    }
}
