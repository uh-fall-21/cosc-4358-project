using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool
         groundDetected,
         wallDetected;
}
