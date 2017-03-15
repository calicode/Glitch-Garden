using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static GameObject selectedDefender;
    SpriteRenderer spriteRender;
    Color origColor;
    private Button[] buttArray;
    public GameObject defenderToSpawn;
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        origColor = spriteRender.color;
        spriteRender.color = Color.gray;
        buttArray = GameObject.FindObjectsOfType<Button>();
        selectedDefender = gameObject;
    }   /// <summary>
        /// OnMouseDown is called when the user has pressed the mouse button while
        /// over the GUIElement or Collider.
        /// </summary>
    void OnMouseDown()
    {
        selectedDefender = defenderToSpawn;
        foreach (Button thisButton in buttArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        spriteRender.color = origColor;

    }

    void OnMouseUp()
    {
    }
}
