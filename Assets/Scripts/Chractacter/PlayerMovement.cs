using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private GameObject cube;
    private Animator animator;
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float groundDrag;
    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    
    public MovementState state;

    public enum MovementState
    {
        walking,
        sprinting,
        air
    }
    private void Start(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)){
            //Debug.Log("click");
            animator.SetBool("IsAttacking", true);
            cube.SetActive(true);
                }
            else  cube.SetActive(false);
            animator.SetBool("IsAttacking", false);

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();
        // handle drag
        if (grounded == true)
            rb.drag = groundDrag;
        else 
            rb.drag = 0;
    }
    private void FixedUpdate() 
    {
        MovePlayer();
    }
    
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void StateHandler()
    {
        //Mode - Sprinting
        if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        //Mode - Walking
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        //Mode - Air
        else
        {
           state = MovementState.air; 
        }
        
    }
    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if(verticalInput == 0){
            
            animator.SetBool("IsWalkingFWD", false);
            animator.SetBool("IsWalkingBWD", false);

        }else if (verticalInput == 1){
            
            animator.SetBool("IsWalkingFWD", true);
            

        }else if (verticalInput == -1){
            
            animator.SetBool("IsWalkingBWD", true);

        }
        if(horizontalInput == 0){
            
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);

        }else if (horizontalInput == 1){
            
            animator.SetBool("IsWalkingRight", true);

        }else if (horizontalInput == -1){
            
            animator.SetBool("IsWalkingLeft", true);
            
        }

        
        if(moveDirection.Equals(Vector3.zero)){
            /*animator.SetBool("IsWalkingFWD", false);
            animator.SetBool("IsWalkingBWD", false);
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);*/
        }else{
            /*animator.SetBool("IsWalkingFWD", true);
            animator.SetBool("IsWalkingBWD", true);
            animator.SetBool("IsWalkingRight", true);
            animator.SetBool("IsWalkingLeft", true);*/
        }

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    
    private void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
