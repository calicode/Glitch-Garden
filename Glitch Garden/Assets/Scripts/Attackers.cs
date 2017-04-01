using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attackers : MonoBehaviour
{
    [TooltipAttribute("Average number of seconds between appearances")]
    public float seenEverySeconds;
    float walkSpeed;
    private GameObject currentTarget;
    Animator animator;
    private GameObject attackerParent;
    // Use this for initializa
    void Start()

    {
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myRigidBody.isKinematic = true;
        attackerParent = GameObject.Find("Attackers");
        if (!attackerParent)

        {
            attackerParent = new GameObject("Attackers");

        }
        gameObject.transform.parent = attackerParent.transform;
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
        if (currentTarget)
        {
            currentTarget.GetComponent<Health>().TakeDamage(damage);
        }
    }
    public void SetCurrentTarget(GameObject target)
    {
        currentTarget = target;
    }


    void OnTriggerExit2D(Collider2D other)
    {

        animator.SetBool("isAttacking", false);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        if (!currentTarget) { animator.SetBool("isAttacking", false); }
    }
}
