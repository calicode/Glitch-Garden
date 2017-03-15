using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    // add a function that searches array of defenders before instantiating to make sure we aren't spawning on an already
    // taken tile. right now this kind of works with colliders but you can still click in a few places that will allow double placement
    // i think having an array of defenders will be useful anyway.
    private Camera mainCam;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
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
        Vector3 mousePositionRounded = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePositionRounded.x = Mathf.Round(mousePositionRounded.x);
        mousePositionRounded.y = Mathf.Round(mousePositionRounded.y);
        mousePositionRounded.z = -5f;
        print("screen to world point is: " + mousePositionRounded);
        Instantiate(Button.selectedDefender, mousePositionRounded, Quaternion.identity);
    }
}
