using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Attackers))]
public class Lizard : MonoBehaviour
{
    Attackers attackers;
    Animator anim;
    float damage = 5f;
    // Use this for initialization
    void Start()
    {
        attackers = GetComponent<Attackers>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<Defenders>())
        {
            return;
        }
        else
        {
            anim.SetBool("isAttacking", true); attackers.StrikeCurrentTarget(damage);

        }
    }

    // Update is called once per frame
}
