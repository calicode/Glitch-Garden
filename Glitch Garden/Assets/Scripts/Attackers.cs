using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackers : MonoBehaviour
{
    float walkSpeed;
    bool isAttacking = true;

    // Use this for initialization
    void Start()

    {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();

        myRigidBody.isKinematic = true;

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>

    public void SetSpeed(float speed)
    {
        walkSpeed = speed;
    }
    // setup a method called below which will choose the right damage based on object name
    // i don't like digging through animation events to find damage numbers
    // the individual attackers have a method now but that shortcuts the animation event

    public void StrikeCurrentTarget(float damage)
    {
        /*		switch (name){
                    case 
                }
        */
        Debug.Log(name + " did " + damage + " damage");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
    }
}
