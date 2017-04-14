using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button : MonoBehaviour
{
    public static GameObject selectedDefender;
    SpriteRenderer spriteRender;
    Color origColor;
    private Button[] buttArray;
    public GameObject defenderToSpawn;
    Text defenderCostText;
    void Start()
    {
        defenderCostText = GetComponent<Text>();
        spriteRender = GetComponent<SpriteRenderer>();
        origColor = spriteRender.color;
        spriteRender.color = Color.gray;
        buttArray = GameObject.FindObjectsOfType<Button>();
        selectedDefender = gameObject;


        defenderCostText.text = defenderToSpawn.GetComponent<Defenders>().starCost.ToString();


    }
    void OnMouseDown()
    {
        selectedDefender = defenderToSpawn;
        foreach (Button thisButton in buttArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        spriteRender.color = origColor;

    }

}
