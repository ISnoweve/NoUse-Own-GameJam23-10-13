using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private BoxCollider2D boxCollider;
    private Camera camera;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;

    public Vector2 mixPower;
    public Vector2 maxPower;
    public float shootPower = 10f;
    public float losePower = 1f;

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
        boxCollider = GetComponent<BoxCollider2D>();
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
        Debug.Log(forceX);
        Debug.Log(forceY);
        force = new Vector2(forceX, forceY);
        
        rigidbody.AddForce(force*shootPower,ForceMode2D.Force);
    }

    private void Update()
    {
        MoveDetect();
    }

    private void MoveDetect()
    {
        if (rigidbody.velocity.x != 0 )
        {
            Vector2 rigidbodyVelocity = rigidbody.velocity;
            rigidbodyVelocity.x = 0;
            rigidbodyVelocity.y -= Time.deltaTime * losePower;
        }
    }
}
