using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Character target;

    public void pickTarget(Character tar) {
        target = tar;
    }

    public override void attack() {
        //later this will queue up moves
        Debug.Log(this.name + " attacked " + target.name);
        target.takeDamage(10);
    }
}
