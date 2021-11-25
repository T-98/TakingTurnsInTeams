using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string charaName;
    
    public int currHP;
    public int maxHP;

    public bool avaTurn;

    public Canvas Canvas;

    public void takeDamage(int dmg) {
        currHP -= dmg;
        //check for death here
        Debug.Log(charaName + " took " + dmg + " dmg");
    }

    public void heal(int val) {
        currHP = (currHP + val > maxHP) ? maxHP : currHP + val;
    }

    public void death() {
        //play death animation here
        Debug.Log(this.charaName + " has died!");
    }

    public void refreshTurn() {
        avaTurn = true;
    }

    public void usedMove() {
        avaTurn = false;
    }

    public void setCanvas(Canvas canva) {
        Canvas = canva;
    }

    public void enableCanvas() {
        Canvas.enabled = true;
    }

    public void disableCanvas() {
        Canvas.enabled = false;
    }

    public void Reset() {
        currHP = maxHP;
        avaTurn = true;
    }

    public bool hasMove() {
        return avaTurn;
    }

    public virtual void attack() {
        Debug.Log("you shouldn't be here");
    }
}
