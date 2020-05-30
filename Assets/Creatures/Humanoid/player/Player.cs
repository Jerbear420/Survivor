using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UIElements;

public class Player : Humanoid
{
    new public static int ID = 3;

    override public int ClassId { get { return ID; } }

    private static int IDLE = 1;
    private static int WALKING = 2;
    private bool isMoving;
    private int anim;
    public int Anim { get { return anim; } }
    // Start is called before the first frame update
    void Start()
    {
        anim = IDLE;
        StartCoroutine(Initialize());
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
        Action();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {

            body.velocity = new Vector2(body.velocity.x, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.velocity = new Vector2(-1, body.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.velocity = new Vector2(body.velocity.x, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.velocity = new Vector2(1, body.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            body.velocity = new Vector2(body.velocity.x, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            body.velocity = new Vector2(body.velocity.x, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
        if (body.velocity == Vector2.zero)
        {
            isMoving = false;

        }
        else
        {
            isMoving = true;
        }
        Animate();
    }
    private void Animate()
    {
        facing = getFacing();
        animator.SetBool("isMoving", isMoving);
        animator.SetFloat("x", body.velocity.x);
        animator.SetFloat("y", body.velocity.y);
    }

    private Vector2 getFacing()
    {
        Vector2 direction = Vector2.down;

        if (body.velocity.x > 0)
        {
            direction = Vector2.right;
        }
        else if (body.velocity.x < 0)
        {
            direction = Vector2.left;
        }
        else if (body.velocity.y > 0)
        {
            direction = Vector2.up;
        }
        else if (body.velocity.y < 0)
        {
            direction = Vector2.down;
        }
        return direction;

    }
    private void Action()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetInteger("wpntype", 1);
            animator.SetTrigger("paction");
            print("Swing trigger");
        }
    }
    private void StopAction()
    {
        animator.SetTrigger("idleaction");
        print("No more swinging");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Ouch");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

}
