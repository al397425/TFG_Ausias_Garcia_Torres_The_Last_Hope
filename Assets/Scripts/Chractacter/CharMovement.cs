using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    //solving gravity character controller
    private Vector3 velocity;
    //Z Targeting
    Vector3 dir;
    Collider[] nearbyTargets;
    [SerializeField] int noticeZone = 10;
    [SerializeField] LayerMask LayerMaskTarget;
    public bool blockedtarget = false;
    private bool courutineNotWaiting = false;
    GameObject TargetsObject;
    //movement and rotation
    float horizontalInput;
    float verticalInput;
    Vector3 movementDirection;
    [SerializeField] public float speed = 5f;
    public float rotationSpeed = 4;
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

    //Life Magic Bars
    public int life = 7;
    public int magic = 7;
    public int pipo = 0;
    void Start()
    {
        cube.SetActive(false);
        animator = GetComponent<Animator>();
        CharCollider = GetComponent<Collider>();
        characterController = GetComponent<CharacterController>();
        Keyframe dodge_lastFrame = dodgeCurve[dodgeCurve.length - 1];
        dodgeTimer = dodge_lastFrame.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (blockedtarget == true)
            {
                blockedtarget = false;
                TargetsObject.transform.Find("TargetUI").gameObject.SetActive(false);
            }
            else { StartCoroutine(TargetRoutine()); }
        
        }
        print("encima pipo_blocked_target = " + blockedtarget + pipo);
        //Movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movementDirection;
        //movement direction must be the direction of the enemy, if it isn't

        /*Vector3 pos = playerT.position;
        Vector3 dir = (this.transform.position - target.transform.position).normalized;*/

        /*movementDirection = dir;
    }else{
        */

            movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            //}

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
 
        //Animations
        AnimationWalk();
        AnimationAttack();
        //AnimationRoll();
        //New Dodge Roll
        if(Input.GetKeyDown(KeyCode.Space)){
            /*if(direction.magnitude != 0) */StartCoroutine(Dodge()); //only if the character is moving 
        }
        //Rotation Logic + Z Targeting
        if (movementDirection /*!=*/!= Vector3.zero)
        {
            float rs = rotationSpeed;
            if (isDodging) rs = 3;
            if (!isDodging) rs = rotationSpeed;
            /*if(Input.GetKeyDown(KeyCode.Tab))
            {
                if(blockedtarget == true)
                {
                    blockedtarget = false;
                }else{
                        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, noticeZone, LayerMaskTarget);
                        //for (int i = 0; i < nearbyTargets.Length; i++)
                        //{
                        //if(nearbyTargets[i] != null)
                        //{
                        dir = nearbyTargets[0].transform.position - playerT.position;
                        dir.y = 0;
                        Collider TargetCollider = nearbyTargets[0];
                        GameObject TargetsObject = TargetCollider.transform.gameObject;
                        if ((TargetsObject.transform.Find("TargetUI").gameObject.activeSelf) == false 
                            /*&& UniqueTarget == false*//* && blockedtarget == false) {
                            TargetsObject.transform.Find("TargetUI").gameObject.SetActive(true);
                            blockedtarget = true;
                            //print("apretado pipo_blocked_target = " + blockedtarget + pipo);
                            //UniqueTarget = true;
                        }*/

            //}  
            /*Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rs * 360);
            //}*/
            //}else
            //{
            //if (courutineNotWaiting == false)
            //{
            if (blockedtarget == false)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rs * Time.deltaTime);
            }
            else
            {
                if (nearbyTargets[0] != null)
                {
                    TargetsObject.transform.Find("TargetUI").gameObject.SetActive(true);
                    dir = nearbyTargets[0].transform.position - playerT.position;
                    dir.y = 0;
                    Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rs * Time.deltaTime);
                }
            }

            //}
            //}
        }
        else
        {
            if(blockedtarget == true)
            {
                Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,Time.deltaTime);
            }
        }
    /*else if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(blockedtarget == true)
            {
                blockedtarget = false;
            }else{
                    Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, noticeZone, LayerMaskTarget);
            //for (int i = 0; i < nearbyTargets.Length; i++)
        //{ 
            if(nearbyTargets[0] != null)
            {
                dir = nearbyTargets[0].transform.position - playerT.position;
                dir.y = 0;
                Collider TargetCollider = nearbyTargets[0];
                GameObject TargetsObject = TargetCollider.transform.gameObject;
                    if ((TargetsObject.transform.Find("TargetUI").gameObject.activeSelf) == false
                    /*&& UniqueTarget == false*//*) {*/
                        /*TargetsObject.transform.Find("TargetUI").gameObject.SetActive(true);
                        blockedtarget = true;
                        //UniqueTarget = true;
                    }
            }
        //}*/
            /*Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,360);
            }
        }*/

    //Sword Attack
    if (Input.GetMouseButtonDown(0) && swordEquipped == true){
            //Attack
            cube.SetActive(true);
                /*}
            else{  cube.SetActive(false);*/
    }
    //Magic Shot
    if (Input.GetMouseButtonDown(0) && rodEquipped == true){
            GameObject gameObjectShot = (GameObject)
            Instantiate(prefabShot, positionShot.transform.position, positionShot.transform.rotation);
            gameObjectShot.layer = 9;//9 = layer Shot

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
    //Respawn Player
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
    private void Awake() 
        {
            //Fixed FPS to 50(?)
            Application.targetFrameRate = 50;
        }
    IEnumerator TargetRoutine()
    {

        //do stuff
            nearbyTargets = Physics.OverlapSphere(transform.position, noticeZone, LayerMaskTarget);
            //for (int i = 0; i < nearbyTargets.Length; i++)
            //{
            if (nearbyTargets[0] != null)
            {
                dir = nearbyTargets[0].transform.position - playerT.position;
                dir.y = 0;
                Collider TargetCollider = nearbyTargets[0];
                TargetsObject = TargetCollider.transform.gameObject;
                if ((TargetsObject.transform.Find("TargetUI").gameObject.activeSelf) == false
                        /*&& UniqueTarget == false*/ && blockedtarget == false) {
                    TargetsObject.transform.Find("TargetUI").gameObject.SetActive(true);
                    blockedtarget = true;
                    //print("apretado pipo_blocked_target = " + blockedtarget + pipo);
                    //UniqueTarget = true;
                }

            }  
                /*Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,360);
                //}*/
                //}else
                //{
                //wait for space to be pressed
                
                while (!Input.GetKeyDown(KeyCode.Tab))
                {
                    yield return null;
                }
                //blockedtarget = false;
                //TargetsObject.transform.Find("TargetUI").gameObject.SetActive(false);
                //do stuff once space is pressed



    }
        
    }
