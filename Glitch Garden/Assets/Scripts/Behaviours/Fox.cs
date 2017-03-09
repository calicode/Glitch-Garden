using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Attackers))]
public class Fox : MonoBehaviour
{
    Animator anim;
    Attackers attackers;
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
            if (other.GetComponent<Stone>())
            {
                anim.SetTrigger("jumping");
            }
            else
            {
                anim.SetBool("isAttacking", true); attackers.SetCurrentTarget(other.gameObject);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
