﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attackers : MonoBehaviour
{
    float walkSpeed;
    bool isAttacking = true;
    private GameObject currentTarget;
    Animator animator;
    // Use this for initialization
    void Start()

    {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myRigidBody.isKinematic = true;

    }


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
        if (currentTarget)
        {
            currentTarget.GetComponent<Health>().TakeDamage(damage);
        }
    }
    public void SetCurrentTarget(GameObject target)
    {
        currentTarget = target;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        if (!currentTarget) { animator.SetBool("isAttacking", false); }
    }
}
