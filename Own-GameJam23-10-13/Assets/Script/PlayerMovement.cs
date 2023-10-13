using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    private Camera camera;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;

    public Vector2 mixPower;
    public Vector2 maxPower;
    public float shootPower = 10f;
    public float losePower = 1f;
    public float losePowerPlus;
    public bool isMoving;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Start()
    {
        InitReference();
    }

    private void InitReference()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void OnMouseDown()
    {
        startPoint = camera.ScreenToWorldPoint(Input.mousePosition);
        startPoint.z = 15;
    }

    private void OnMouseUp()
    {
        endPoint = camera.ScreenToWorldPoint(Input.mousePosition);
        endPoint.z = 15;

        float forceX = Math.Clamp(startPoint.x - endPoint.x, mixPower.x, maxPower.x);
        float forceY = Math.Clamp(startPoint.y - endPoint.y, mixPower.y, maxPower.y);
        force = new Vector2(forceX, forceY);

        if (MoveDetect())
        {
            rigidbody.AddForce(force*shootPower,ForceMode2D.Force); 
        }

        PlayerMovementLine.Instance.EndLine();
    }

    private void Update()
    {
        if (!MoveDetect())
        {
            rigidbody.velocity=LosingVelocity();
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 currentPoint = camera.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;
                PlayerMovementLine.Instance.RenderLine(startPoint,currentPoint);
            }
        }
    }

    private bool MoveDetect()
    {
        if (rigidbody.velocity.x == 0 && rigidbody.velocity.y == 0)
        {
            isMoving = false;
            return true;
        }
        else
        {
            isMoving = true;
            return false;
        }
    }

    private Vector2 LosingVelocity()
    {
        Vector2 getVelocity = rigidbody.velocity;
        
        //有問題的彈射系統
        
        // if (getVelocity.x < 0)
        // {
        //     velocityX = Mathf.Abs(getVelocity.x) - (Time.deltaTime * losePower);
        //     getVelocity.x = -velocityX;
        // }
        // else
        // {
        //     getVelocity.x = Mathf.Abs(getVelocity.x) - (Time.deltaTime * losePower);
        // }
        //
        // if (getVelocity.y < 0)
        // {
        //     velocityY = Mathf.Abs(getVelocity.y) - (Time.deltaTime * losePower);
        //     getVelocity.y = -velocityY;
        // }
        // else
        // {
        //     getVelocity.y = Mathf.Abs(getVelocity.y) - (Time.deltaTime * losePower);
        // }

        if (Mathf.Abs(getVelocity.x) <= 1 && Mathf.Abs(getVelocity.y) <= 1)
        {
            getVelocity.x = 0;
            getVelocity.y = 0;
        }

        return getVelocity;
    }
}
