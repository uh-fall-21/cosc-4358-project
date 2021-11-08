using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    //can currently hit 
    [SerializeField]
    private bool combatEnabled; //set in inspector
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private Transform attack1HitBoxPos;
    [SerializeField]
    private LayerMask whatIsDamageable;

    private bool gotInput, isAttacking, isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity; //always ready to attack since beginning of game

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                //attempt combat
                gotInput = true;
                lastInputTime = Time.time;
            }
        }
    }
    private void CheckAttacks()
    {
        if (gotInput)
        {
            //perform attack1
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                //anim.SetBool("attack1", true);
                //anim.SetBool("firstAttack", isFirstAttack);
                //anim.SetBool("isAttacking", isAttacking);
            }
        }
        if (Time.time >= lastInputTime + inputTimer)
        {
            //wait for new input
            gotInput = false;

        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable);
        foreach(Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attack1Damage);
            //instantiate hit particle
        }
    }

    //lets script know it is done
    private void FinishAttack1()
    {
        isAttacking = false;
        //anim.SetBool("isAttacking", isAttacking);
        //anim.SetBool("attack1", false);
    }

    private void onDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }
    
}
