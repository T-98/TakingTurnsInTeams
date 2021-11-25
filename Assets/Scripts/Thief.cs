using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Character
{
    public Character enemy;

    public override void attack() {
        Debug.Log(this.name + " attacked " + enemy.name);
        enemy.takeDamage(10);
    }
}
