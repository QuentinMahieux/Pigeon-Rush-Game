using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float speed = 6;
    public float jumpForce = 5;
    
    [Header("Dash")]
    [Tooltip("Force du Dash")] public float dashForce = 10;
    [Tooltip("Temps entre 2 dash")] public float dashCoolDown = 2.5f;
    [Tooltip("Durée du Dash")] public float dashDuration = 0.5f;
    [Range(0f, 30f), Tooltip("Force du frénage du dash")] public float dahsStopForce = 10f;
    private float actualDashCoolDown = 0f;
    
    [Header("Stamina")]
    public Slider staminaSlider;
    private Vector3 lastSpeed;
    
    [Header("Other Information")]
    public float actualSpeed;
    
    public Rigidbody rb;
    private Vector3 moveDirection;
    public Camera camera;
    
    [Header("Booleans")]
    public bool isJumping;
    public bool isDashing;
    public bool isDashingCooldown;
    public bool isGrounded;

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

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        moveDirection = vertical * transform.forward  + horizontal * transform.right;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashingCooldown && !isDashing)
        {
            isDashing = true;
        }

        if (isDashing)
        {
            
        }
        
        if (isDashingCooldown)
        {
            actualDashCoolDown += Time.deltaTime;
            staminaSlider.value = actualDashCoolDown/dashCoolDown;
            if (actualDashCoolDown >= dashCoolDown)
            {
                isDashingCooldown = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) &&  isGrounded)
        {
            isJumping = true;
        }


    }
    void FixedUpdate()
    {

        //Jump
        if(isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
            isGrounded = false;
        }
        //Dash
        if (isDashing && !isDashingCooldown)
        {
            isGrounded = true;
            StartCoroutine(DashDuration());
            return;
        }
        //Move
        rb.MovePosition(rb.position + moveDirection * (Time.deltaTime * speed));
        
        
        actualSpeed = (rb.position - lastSpeed).magnitude / Time.fixedDeltaTime;
        lastSpeed = rb.position;
    }

    void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("DontClimb"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    IEnumerator DashDuration()
    {
        rb.AddForce(moveDirection * dashForce, ForceMode.Impulse);
        actualDashCoolDown = 0f;
        isDashingCooldown = true;
        yield return new WaitForSeconds(dashDuration);
        rb.linearDamping = 10f;
        isDashing = false;
        yield return new WaitForSeconds(0.1f);
        rb.linearDamping = 0f;
    }
}
