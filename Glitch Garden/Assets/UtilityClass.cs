using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityClass : MonoBehaviour
{


    /// Set thisGameObject parent to empty Gameobject for editor heirarchy clarity. 
    public static void ParentMe(GameObject thisGameObject, string parentName)
    {
        GameObject attackerParent = GameObject.Find(parentName);
        if (!attackerParent)

        {
            attackerParent = new GameObject(parentName);

        }
        thisGameObject.transform.parent = attackerParent.transform;

    }
}
