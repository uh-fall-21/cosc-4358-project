using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour


{
    /*
    public float walkSpeed;
[HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public Transform groundCheckPosition;

    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }




    */


    [SerializeField] float moveSpeed = 1f;


    //variables for actual bullet
    float fireRate;
    float nextFire;



    Rigidbody2D myRigidbody;


    //variables for detecting player and shooting at him
    public Transform player;
    public float range;
    private float distToPlayer;
    public GameObject bullet;

    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;

        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StartCoroutine(Wait());
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (isFacingRight())
        {
            //move sprite right
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            //move sprite left  
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }

        if (distToPlayer <= range)
        {
            myRigidbody.velocity = new Vector2(0f, 0f);
            Shoot();
        }

    }

    private void Shoot()
    {
        CheckifTimetoFire();
    }

    private void CheckifTimetoFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }



    //flips sprite-- Mathf.Sign returns us a number thats 1 or -1.
    private void OnTriggerExit2D(Collider2D collision)
    {

        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);

        //transform.localScale = new Vector2(-(myRigidbody.velocity.x), transform.localScale.y);
        /*
        transform.localScale = new Vector2(-3f, 3f);
        transform.localScale = new Vector2(3f, -f);\
        */
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
    }



}