using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    //movement and rotation
    float horizontalInput;
    float verticalInput;
    public float speed;
    public float rotationSpeed;
    //Animation
    private Animator animator;

    //Ataack collider
    [SerializeField] private GameObject cube;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput,0 , verticalInput );
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        AnimationWalk();    
        

    if(movementDirection != Vector3.zero)
    {
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    //Attack

    if (Input.GetMouseButtonDown(0)){
            //Debug.Log("click");
            animator.SetBool("IsRolling", true);
            cube.SetActive(true);
                }
            else{  cube.SetActive(false);
            animator.SetBool("IsRolling", false);
    }
    //
    }
    public void AnimationWalk()
    {
        if(verticalInput == 0){
            animator.SetBool("IsWalkingFWD", false);
            animator.SetBool("IsWalkingBWD", false);
    

        }else if (verticalInput == 1){
            animator.SetBool("IsWalkingFWD", true);
            //Attack + Walking

            if (Input.GetMouseButtonDown(0)){
                //Debug.Log("click");
                animator.SetBool("IsWalkingFWD", false);
                animator.SetBool("IsAttacking", true);
                cube.SetActive(true);
                }
            else{  cube.SetActive(false);
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsWalkingFWD", true);
            }

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
    }
}
