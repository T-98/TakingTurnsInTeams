using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOnMouseClick : MonoBehaviour
{
    //public GameObject playercontroller;
    public CombatSystem system;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        //disable all canvas
        Character chara = this.GetComponent<Character>();
        if(chara.hasMove()) {
            system.selectedChara(chara);
            //enable the canvas for this character
            //Debug.Log(this);
        }
    }
}
