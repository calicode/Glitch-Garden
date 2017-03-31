using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    public GameObject projectile;
    public float attackspeed;
    Animator animator;
    private GameObject defenderParent;
    private Vector2 rayCastPositionStart;
    // Use this for initialization
    int layerMask;
    public int starCost = 1;
    void Start()
    {
        layerMask = 1 << 8;
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)

        {
            defenderParent = new GameObject("Defenders");


        }
        gameObject.transform.parent = defenderParent.transform;

        animator = GetComponent<Animator>();
    }
    bool EnemyInLane()
    {


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, layerMask);


        if (hit)
        {
            Attackers rayAttacker = hit.collider.gameObject.GetComponent<Attackers>();

            if (rayAttacker) { return true; } else { return false; }
        }
        return false;


    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "defender_fightback")
        {
            animator.SetBool("isAttacking", EnemyInLane());
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Attackers>())
        {
            animator.SetBool("takingDamage", true);

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Attackers>())
        {
            animator.SetBool("takingDamage", false);

        }

    }

    public void FireProjectile()
    {

        if (projectile)
        {
            Vector3 projectileSpawn = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            Instantiate(projectile, projectileSpawn, Quaternion.identity);
        }
    }

    public void AddStars()
    {
        ResourceManager.AddStar();

    }

}
