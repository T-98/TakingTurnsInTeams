using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string charaName;
    public bool avaTurn;
    public GameObject canvas;
    public Dictionary<int, string> abilities;

    public Dictionary<int, string> getAbilities()
    {
        return abilities;
    }

    public void takeDamage(double dmg) {
        //currHP -= dmg;
        //check for death here
        Debug.Log(charaName + " took " + dmg + " dmg");
    }

    public virtual void heal(int val) { }

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

    public void enableCanvas() {
        canvas.SetActive(true);
    }

    public void disableCanvas() {
        canvas.SetActive(false);
    }

    public void Reset() {
        avaTurn = true;
    }

    public bool hasMove() {
        return avaTurn;
    }

    public virtual void attack() {
        Debug.Log("you shouldn't be here");
    }

    public virtual void execute(int val) { }
}
