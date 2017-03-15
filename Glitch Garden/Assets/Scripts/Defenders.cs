using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    public GameObject projectile;
    public float attackspeed;
    Animator animator;
    private GameObject defenderParent;
    // Use this for initialization
    void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)

        {
            defenderParent = new GameObject("Defenders");
            gameObject.transform.parent = defenderParent.transform;

        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

}
