using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask hittableObjects;
    public Transform attackstartpoint;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
      if (Time.time >= nextAttackTime)
        {
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
          Attack();
                //Talk();      

          nextAttackTime = Time.time + 1f / attackRate;

        }
        }
    }



    void Attack()
    {
        // Animator.SetTrigger("Attack"); Insert attack animation here
       Collider[] hitenemies = Physics.OverlapCapsule(attackPoint.position,attackstartpoint.position, attackRange, hittableObjects);
        foreach (Collider enemy in hitenemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("You hit a thing");
        }


        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
