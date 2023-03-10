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
    public bool swordEquipped = true;
    public bool rodEquipped = false;
    
    //Animation
    private Animator animator;

    //Ataack collider
    [SerializeField] private GameObject cube;
    Collider CharCollider;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        CharCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        //Movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput,0 , verticalInput );
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        AnimationWalk();
        AnimationAttack();
        AnimationRoll();       
        

    if(movementDirection != Vector3.zero)
    {
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
    //Sword Attack
    if (Input.GetMouseButtonDown(0) && swordEquipped == true){
            //Debug.Log("click");
            //Attack
            cube.SetActive(true);
                }
            else{  cube.SetActive(false);
    }
    //Magic Shot
    if (Input.GetMouseButtonDown(0) && rodEquipped == true){
            //Debug.Log("click");
            
            //instantite bullet

            //¿subrutine destroy bullet?
                }
            else{  
    }
    //Defend Mechanic
    /*if (Input.KeyCode.E ){
            /
            //Attack
            CharCollider.enabled = false;
                }
            else{  CharCollider.enabled = true;
    }*/

    }
    public void AnimationRoll(){
    //Roll

    if (Input.GetKeyDown(KeyCode.Space)){
            animator.SetBool("IsRolling", true);
            //Vector3 myVector = new Vector3(1.0f, 0.0f, 0.0f);
            //transform.Translate(myVector * speed * Time.deltaTime, Space.World);
            CharCollider.enabled = false;
        }
        else{
            CharCollider.enabled = true;
            animator.SetBool("IsRolling", false);
    }
    }
    //Attack Animation
    public void AnimationAttack(){
    if (Input.GetMouseButtonDown(0)){
            //Debug.Log("click");
            animator.SetBool("IsAttacking", true);
            
                }
            else{
            animator.SetBool("IsAttacking", false);
    }
    }
    public void AnimationWalk()
    {
        if(verticalInput == 0){
            animator.SetBool("IsWalkingFWD", false);
            animator.SetBool("IsWalkingBWD", false);

        }else if (verticalInput == 1){
            animator.SetBool("IsWalkingFWD", true);
            //Attack + Walking

            /*if (Input.GetMouseButtonDown(0)){
                //Debug.Log("click");
                animator.SetBool("IsWalkingFWD", false);
                animator.SetBool("IsAttacking", true);
                cube.SetActive(true);
                }
            else{  cube.SetActive(false);
                animator.SetBool("IsAttacking", false);
                animator.SetBool("IsWalkingFWD", true);
            }*/

        }else if (verticalInput == -1){
            animator.SetBool("IsWalkingBWD", true);
        }

        if(horizontalInput == 0){
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", false);

        }else if (horizontalInput == 1){
            Debug.Log("1 horizontal");
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingRight", true);

        }else if (horizontalInput == -1){
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", true);
        }
    }
}
