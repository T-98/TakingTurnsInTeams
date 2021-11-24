using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public double health = 150, damage, incomingDamage, speed;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enableWarriorCanvas()
    {
        canvas.SetActive(true);
    }

    public void disableWarriorCanvas()
    {
        canvas.SetActive(false);
    }
}
