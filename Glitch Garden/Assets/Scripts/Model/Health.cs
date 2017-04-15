﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) { Debug.Log(gameObject.name + " health is" + health + " which is below 0 calling killme"); KillMe(); }
    }

    public void KillMe()
    {

        if (gameObject.tag == "pumpkitten") { ResourceManager.DeactiveLaneSpawner(transform.position.y); }
        Attackers atkComponent = GetComponent<Attackers>();
        if (atkComponent)

        {
            Debug.Log("atacker component found on" + gameObject.ToString());
            atkComponent.TurnToRun();
            return;
        }
        else { Debug.Log("No attacker component found on" + gameObject.ToString()); }
        Destroy(gameObject);

    }
}