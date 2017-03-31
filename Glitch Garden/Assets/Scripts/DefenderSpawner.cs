using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    // add a function that searches array of defenders before instantiating to make sure we aren't spawning on an already
    // taken tile. right now this kind of works with colliders but you can still click in a few places that will allow double placement
    // i think having an array of defenders will be useful anyway.
    private Camera mainCam;
    void Start()
    {
        mainCam = GameObject.FindObjectOfType<Camera>();
    }


    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        PlaceDefender();
    }

    void PlaceDefender()
    {
        int defCost = Button.selectedDefender.GetComponent<Defenders>().starCost;
        if (ResourceManager.UseStars(defCost))
        {
            Vector3 mousePositionRounded = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePositionRounded.x = Mathf.Round(mousePositionRounded.x);
            mousePositionRounded.y = Mathf.Round(mousePositionRounded.y);
            mousePositionRounded.z = -5f;
            Instantiate(Button.selectedDefender, mousePositionRounded, Quaternion.identity);
        }


    }


}
