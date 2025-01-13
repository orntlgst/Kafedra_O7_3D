using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float PlayerSpeed;
    public float GroundDrag;
    public float PlayerHeight;
    public LayerMask WhatIsGround;
    bool grounded;

    public Transform orient;

    float moveX;
    float moveY;

    Vector3 moveDir;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 
            PlayerHeight * 0.5f + 0.2f, WhatIsGround);
        if (grounded)
            rb.drag = GroundDrag;
        else
            rb.drag = 0;
        PlayerInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDir = orient.forward * moveY + orient.right * moveX;
        rb.AddForce(moveDir.normalized * PlayerSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.y);

        if (flatVel.magnitude > PlayerSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * PlayerSpeed;
            rb.velocity = new Vector3(limitedVel.x, limitedVel.y, limitedVel.z);
        }
    }
}
