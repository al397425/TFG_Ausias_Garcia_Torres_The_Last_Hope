using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    //solving gravity character controller
    private Vector3 velocity;
    //movement and rotation
    
    float horizontalInput;
    float verticalInput;
    Vector3 movementDirection;
    [SerializeField] public float speed = 5f;
    public float rotationSpeed;
    public bool swordEquipped = true;
    public bool rodEquipped = true;
    private CharacterController characterController;
    //Dodge Roll
    [SerializeField] AnimationCurve dodgeCurve;
    bool isDodging;
    float dodgeTimer;
    //Animation
    private Animator animator;
    //Atack collider
    [SerializeField] private GameObject cube;
    Collider CharCollider;
    // Magic Shot
    public GameObject prefabShot;
    public GameObject positionShot;
    //Respawn
    [SerializeField] private Transform playerT;
    // Start is called before the first frame update
    void Start()
    {
        cube.SetActive(false);
        animator = GetComponent<Animator>();
        CharCollider = GetComponent<Collider>();
        characterController = GetComponent<CharacterController>();

        Keyframe dodge_lastFrame = dodgeCurve[dodgeCurve.length - 1];
        dodgeTimer = dodge_lastFrame.time;

    }

    // Update is called once per frame
    void Update()
    {
        
        
    

    

        //Movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput,0 , verticalInput );

        movementDirection.Normalize();

        //Solve Gravity character controller
        // === AFTER CALCULATING MOVE INPUT
    
        if(!isDodging) //dodging block
        characterController.Move(movementDirection * Time.deltaTime * speed);

        velocity += Physics.gravity * Time.deltaTime;

        characterController.Move(velocity); // Apply Gravity

        //if (characterController.isGrounded) velocity = Vector3.zero;


        

        //oldmovement
        //transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        //Dodge Roll
        
        //Animations
        AnimationWalk();
        AnimationAttack();
        //AnimationRoll();
        //New Roll
        if(Input.GetKeyDown(KeyCode.Space)){
            /*if(direction.magnitude != 0) */StartCoroutine(Dodge()); //only if the character is moving 
        }       
    //Rotation Logic

    if(movementDirection != Vector3.zero)
    {
        float rs = rotationSpeed;
        if(isDodging) rs = 3;
        if(!isDodging) rs = rotationSpeed;
        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rs * Time.deltaTime);
    }

    
    //Sword Attack
    if (Input.GetMouseButtonDown(0) && swordEquipped == true){
            //Debug.Log("click");
            //Attack
            cube.SetActive(true);
                /*}
            else{  cube.SetActive(false);*/
    }
    //Magic Shot
    if (Input.GetMouseButtonDown(0) && rodEquipped == true){
            Debug.Log("click Rod");
            
            Instantiate(prefabShot, positionShot.transform.position, positionShot.transform.rotation);

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
    //Old Roll
    /*public void AnimationRoll(){
    //Roll

    if (Input.GetKeyDown(KeyCode.Space)){
        characterController.Move(movementDirection * Time.deltaTime * speed);
            animator.SetBool("IsRolling", true);
            //Vector3 myVector = new Vector3(1.0f, 0.0f, 0.0f);
            //transform.Translate(myVector * speed * Time.deltaTime, Space.World);
            CharCollider.enabled = false;
        }
        else{
            CharCollider.enabled = true;
            animator.SetBool("IsRolling", false);
    }
    }*/
    //Attack Animation
    public void AnimationAttack(){
    if (Input.GetMouseButtonDown(0)){
            
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
            
            animator.SetBool("IsWalkingLeft", false);
            animator.SetBool("IsWalkingRight", true);

        }else if (horizontalInput == -1){
            animator.SetBool("IsWalkingRight", false);
            animator.SetBool("IsWalkingLeft", true);
        }
    }
    IEnumerator Dodge(){
        isDodging = true;
        animator.SetBool("IsRolling", true);
        float timer = 0;
        characterController.center = new Vector3(0, 0.35f, 0);
        characterController.height = 0.5f;
        while(timer < dodgeTimer){
            float speed = dodgeCurve.Evaluate(timer);
            Vector3 dir = (transform.forward * speed) /*+ (Vector3.up * velocityY)*/; //adding direction and gravity
            characterController.Move(dir * Time.deltaTime);
            timer += Time.deltaTime;
            //Debug.Log("in while");
            yield return null;
        }
        animator.SetBool("IsRolling", false);
        //Debug.Log("exit while");
        isDodging = false;
        characterController.center = new Vector3(0, 0.71f, 0);
        characterController.height = 1.48f;
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("TriggerRCentro")) {
            playerT.position = new Vector3(10.0f, 0.55f, -7.2f);
            
        }

        if (other.gameObject.CompareTag("TriggerRDerecha")) {
            playerT.position = new Vector3(58.2f, 0.55f, -31.7f); 
            
        }

        if (other.gameObject.CompareTag("TriggerRIzquierda")) {
            playerT.position = new Vector3(-43.9f, 0.55f, -3.4f);
            
        }
    }
}
