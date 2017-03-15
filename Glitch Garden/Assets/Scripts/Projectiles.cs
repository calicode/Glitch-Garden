using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float damage, speed;
    private GameObject projectileParent;
    // Use this for initialization
    void Start()
    {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        gameObject.transform.parent = projectileParent.transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Attackers>())
        {
            Health healthComp = other.gameObject.GetComponent<Health>();
            if (healthComp) { healthComp.TakeDamage(damage); }
            Destroy(gameObject);
        }
    }

}
