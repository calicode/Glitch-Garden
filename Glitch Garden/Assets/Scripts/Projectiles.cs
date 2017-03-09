using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float damage;
    // Use this for initialization
    void Start()
    {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " collided with " + other.gameObject.name);
        Health healthComp = other.gameObject.GetComponent<Health>();
        if (healthComp) { healthComp.TakeDamage(damage); }

    }

}
