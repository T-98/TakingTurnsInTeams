using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverDescription : MonoBehaviour
{
    public Text description;

    void OnMouseOver() {
        description.text = "hi";
    }
}
