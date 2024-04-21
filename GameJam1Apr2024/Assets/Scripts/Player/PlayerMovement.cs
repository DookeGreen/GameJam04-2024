using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    public bool canMove;
    private Vector2 movement;
    void Start()
    {
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);
        }

    }
    void FixedUpdate()
    {
        if(canMove)
        {
            Vector2 targetVelocity = movement.normalized * movementSpeed;

            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.fixedDeltaTime * 10f);
        }
        else{
            rb.velocity = Vector3.zero; 
        }
    }
}
