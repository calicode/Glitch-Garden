using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testvalues : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        EntityValuesManager.EntityValues blah = EntityValuesManager.GetValues("dwarf");
        Debug.Log("Name is" + blah.entityName + " damage is " + blah.damage);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
