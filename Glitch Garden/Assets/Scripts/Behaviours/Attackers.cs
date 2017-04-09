using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attackers : MonoBehaviour
{


    Animator animator;
    private GameObject attackerParent;
    private GameObject currentTarget;

    public float walkSpeed;
    Vector3 moveDirection;

    [TooltipAttribute("Average number of seconds between appearances")]
    public float seenEverySeconds;

    bool runAway = false;
    public bool canJump = false; // set in inspector for enemy types that can jump


    public float strikeDamage = 10;

    void Start()

    {
        animator = GetComponent<Animator>();
        Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
        myRigidBody.isKinematic = true;


        UtilityClass.ParentMe(gameObject, "Attackers");
    }





    public void SetSpeed(float speed)
    {
        walkSpeed = speed;

    }
    // setup a method called below which will choose the right damage based on object name
    // i don't like digging through animation events to find damage numbers
    // the individual attackers have a method now but that shortcuts the animation event

    public void StrikeCurrentTarget()
    {
        /*		switch (name){
                    case 
                }
        */
        if (currentTarget)
        {
            currentTarget.GetComponent<Health>().TakeDamage(strikeDamage);
        }
    }
    public void SetCurrentTarget(GameObject target)
    {
        currentTarget = target;
    }
    public Vector3 GetMoveVector()
    {
        switch (runAway)
        {
            case false:
                return (Vector3.left * walkSpeed * Time.deltaTime);
            case true:
                return (Vector3.right * walkSpeed * Time.deltaTime);
        }
        return Vector3.left;

    }
    public void RunAway()
    {
        runAway = true;
        animator.SetBool("isRunning", true);
        animator.SetBool("isAttacking", false);


    }

    public void TurnToRun()
    {
        if (!runAway)
        {
            animator.SetTrigger("turnToRun");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!runAway)
        {
            if (!other.GetComponent<Defenders>())
            {
                return;
            }
            else
            {
                if (other.GetComponent<Stone>() && canJump)
                {
                    animator.SetTrigger("jumping");
                }
                else
                {
                    animator.SetBool("isAttacking", true); SetCurrentTarget(other.gameObject);
                }

            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        animator.SetBool("isAttacking", false);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(GetMoveVector());
        if (!currentTarget) { animator.SetBool("isAttacking", false); }
    }
}
