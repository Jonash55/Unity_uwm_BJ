using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 30f;
    public float radius = 30f;
    public Vector2 Left;
    public Vector2 Right;
    public GameObject PlayerTarget;
    float horizontalMove = 0f;
    bool directionLeft = false;
    bool isWalking = true;
    float stopRadius = 0.1f;

    void Update()
    {
        if (isWalking)
        {
            if(directionLeft)
            {
                horizontalMove = 1 * runSpeed;
            }
            else if (!directionLeft)
            {
                horizontalMove = -1 * runSpeed;
            }
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate()
    {
        isWalking = true;
        if (Math.Abs(PlayerTarget.transform.position.x - transform.position.x) <= radius)
        {
            if (Math.Abs(PlayerTarget.transform.position.x - transform.position.x) >= stopRadius)
            {
                if (directionLeft && PlayerTarget.transform.position.x > transform.position.x)
                {
                    if (directionLeft)
                    {
                        transform.Rotate(0f, -180f, 0f);
                    }
                    else
                    {
                        transform.Rotate(0f, 180f, 0f);
                    }
                    directionLeft = !directionLeft;
                }               
                else if (!directionLeft && PlayerTarget.transform.position.x < transform.position.x)
                {
                    if (directionLeft)
                    {
                        transform.Rotate(0f, -180f, 0f);
                    }
                    else
                    {
                        transform.Rotate(0f, 180f, 0f);
                    }
                    directionLeft = !directionLeft;
                }

                if (!directionLeft && transform.position.x >= Right.x ||
                    directionLeft && transform.position.x <= Left.x)
                {
                    isWalking = false;
                }
                else
                {
                    transform.Translate(runSpeed * Time.fixedDeltaTime, 0f, 0f);
                }
            }
            else
            {
                isWalking = false;
            }
        }
        else
        {
            transform.Translate(runSpeed * Time.fixedDeltaTime, 0f, 0f);
            if (!directionLeft && transform.position.x >= Right.x)
            {
                if (directionLeft)
                {
                    transform.Rotate(0f, -180f, 0f);
                }
                else
                {
                    transform.Rotate(0f, 180f, 0f);
                }
                directionLeft = !directionLeft;
            }
            else if (directionLeft && transform.position.x <= Left.x)
            {
                if (directionLeft)
                {
                    transform.Rotate(0f, -180f, 0f);
                }
                else
                {
                    transform.Rotate(0f, 180f, 0f);
                }
                directionLeft = !directionLeft;
            }
        }
    }
}
