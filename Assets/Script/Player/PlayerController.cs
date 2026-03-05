using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float speed = 6;

    private Vector3 lastSpeed;
    public float actualSpeed;
    
    public Rigidbody rb;
    private Vector3 moveDirection;
    public Camera camera;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerController in scene");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        lastSpeed = rb.position;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        moveDirection = vertical * transform.forward  + horizontal * transform.right;
        
        rb.MovePosition(rb.position + moveDirection * (Time.deltaTime * speed));
        
        actualSpeed = (rb.position - lastSpeed).magnitude / Time.fixedDeltaTime;
        lastSpeed = rb.position;
        
    }
}
