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
        if(sprite.tag == "player") playercontroller.GetComponent<PlayerController>().PlayerSelect(sprite);
        else playercontroller.GetComponent<PlayerController>().EnemySelect(sprite);
    }
}
