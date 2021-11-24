using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOnMouseClick : MonoBehaviour
{
    public GameObject sprite;
    public GameObject playercontroller;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (sprite.tag == "player")
        {
            playercontroller.GetComponent<PlayerController>().PlayerSelect(sprite);
            if (sprite.name == "Warrior") sprite.GetComponent<Warrior>().enableWarriorCanvas();
            if (sprite.name == "Mage") Debug.Log("Set canvas active");
        }
        else playercontroller.GetComponent<PlayerController>().EnemySelect(sprite);
    }
}
