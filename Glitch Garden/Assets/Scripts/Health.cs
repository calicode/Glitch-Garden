using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    // Use this for initialization
    void Start()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f) { print("Health is " + health.ToString() + "calling killme"); KillMe(); }
    }

    // Update is called once per frame
    void Update()
    {
        // Separate method so I can call this from animation events
    }
    public void KillMe()
    {

        if (gameObject.tag == "pumpkitten") { print("pumpkitten dying"); ResourceManager.DeactiveLaneSpawner(transform.position.y); }
        Destroy(gameObject);

    }
}