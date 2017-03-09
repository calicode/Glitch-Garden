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
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { KillMe(); }
        // Separate method so I can call this from animation events
    }
    public void KillMe()
    {
        Destroy(gameObject);

    }
}