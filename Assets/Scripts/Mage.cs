using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{
    public Character enemy;

    public override void attack() {
        enemy.takeDamage(10);
        Debug.Log(this.name + " attacked " + enemy.name);
    }
}
