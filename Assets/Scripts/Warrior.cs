using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public GameObject canvas;
    private List<string> abilities;
    private double health = 150, damage, incomingDamage, speed;
    // Start is called before the first frame update

    private void Update()
    {
        if (health == 0)
        {
            Debug.Log("Trigger Death Scene");
            Destroy(this);
        }
    }
    public void enableWarriorCanvas()
    {
        canvas.SetActive(true);
    }

    public void disableWarriorCanvas()
    {
        canvas.SetActive(false);
    }

    public void healthPotion()
    {
        if (health == 150) Debug.Log("Cannot use potion");
        else health += 50;
    }

    public void bersekerPotion()
    {
        incomingDamage = 10;
        damage += 20;
    }

    public void damageTaken(double damage, double speed)
    {
        health -= damage;
        speed -= speed;
    }
}
