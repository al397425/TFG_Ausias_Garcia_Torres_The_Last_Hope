using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    //solving gravity character controller
    private Vector3 velocity;
    //Z Targeting
    [Header("Z Targeting")]
    Vector3 dir;
    Collider[] nearbyTargets;
    [SerializeField] int noticeZone = 10;
    [SerializeField] LayerMask LayerMaskTarget;
    public bool blockedtarget = false;
    private bool courutineNotWaiting = false;
    GameObject TargetsObject;
    //movement and rotation
    [Header("movement and rotation")]
    float horizontalInput;
    float verticalInput;
    Vector3 movementDirection;
    [SerializeField] public float speed = 5f;
    public float rotationSpeed = 300;
    public bool swordEquipped = false;
    public bool rodEquipped = false;
    private CharacterController characterController;
    //Dodge Roll
    [Header("Dodge Roll")]
    [SerializeField] AnimationCurve dodgeCurve;
    bool isDodging;
    float dodgeTimer;
    //Animation
    private Animator animator;
    [Header("Interactuate With Things")]

    [SerializeField] private GameObject Levercollider;

    //Atack collider
    [Header("Atack collider")]
    [SerializeField] private GameObject SwordCollider;
    Collider CharCollider;
    // Magic Shot
    [Header("Magic Shot")]
    public GameObject prefabShot;
    public GameObject positionShot;
    //Items Management
    [Header("Items Management")]
    public bool has2items = true;
    //Respawn
    [Header("Respawn")]
    [SerializeField] private Transform playerT;

    //Life Magic Bars
    public int life = 7;
    public int magic = 7;
    private bool invincibleEnabled = false;
    [SerializeField]
    private float invincCooldown = 3.0f;
    //VignetteChange
    
    private PostProcessManager PostProcessManager;

    //open door
    public bool havekeydoor = false;
    
    void Start()
    {
        Levercollider.SetActive(false);
        SwordCollider.SetActive(false);
        animator = GetComponent<Animator>();
        CharCollider = GetComponent<Collider>();
        characterController = GetComponent<CharacterController>();
        Keyframe dodge_lastFrame = dodgeCurve[dodgeCurve.length - 1];
        dodgeTimer = dodge_lastFrame.time;
        PostProcessManager = GameObject.Find("Post Processing").GetComponent<PostProcessManager>();

        //material change when hited (unfnished)
        /*for(int j = 0; j<11;j++)
        playerRenderer[j] = GetComponentInChildren<SkinnedMeshRenderer>();
        print("Array" + playerRenderer);*/
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && has2items == true)
        {
            if(swordEquipped == true){
                swordEquipped = false;
                //change Icon to Sword
                //change model to Sword
                rodEquipped = true;
            }else
             if(rodEquipped == true){
                rodEquipped = false;
                //change Icon to Rod
                //change model to Rod
                swordEquipped = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (blockedtarget == true)
            {
                blockedtarget = false;
                TargetsObject.transform.Find("TargetUI").gameObject.SetActive(false);
            }
            else { StartCoroutine(TargetRoutine()); }
        }

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
                            /* && blockedtarget == false) {
                            TargetsObject.transform.Find("TargetUI").gameObject.SetActive(true);
                            blockedtarget = true;
                            //print("apretado pipo_blocked_target = " + blockedtarget);
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
                    /*) {*/
                        /*TargetsObject.transform.Find("TargetUI").gameObject.SetActive(true);
                        blockedtarget = true;
                        
                    }
            }
        //}*/
            /*Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,360);
            }
        }*/
    //Interactuate With Things
    if (Input.GetKeyDown(KeyCode.Q))
    {
        Levercollider.SetActive(true);
        StartCoroutine(WaitInteractuate(0.3f));
    }
    //Sword Attack
    if (Input.GetMouseButtonDown(0) && swordEquipped == true){
            //Attack
            Debug.Log("AESPADA");
            SwordCollider.SetActive(true);
            StartCoroutine(SwordAttack(0.5f));
                /*}
            else{  cube.SetActive(false);*/
    }
    //Magic Shot
    if (Input.GetMouseButtonDown(0) && rodEquipped == true){
        if (magic > 0)
            {
                magic--;
            
            GameObject gameObjectShot = (GameObject)
            Instantiate(prefabShot, positionShot.transform.position, positionShot.transform.rotation);
            gameObjectShot.layer = 9;//9 = layer Shot
            StartCoroutine(WaitShot(1.5f));
        }
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
                SwordCollider.SetActive(true);
                }
            else{  SwordCollider.SetActive(false);
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

    public void InvincEnabled()
    {
        invincibleEnabled = true;
        StartCoroutine(InvincDisableRoutine());
    }

    IEnumerator InvincDisableRoutine()
    {
        //Blink Animation
        
        PostProcessManager.VignetteChange();
        yield return new WaitForSeconds(invincCooldown);
        invincibleEnabled = false;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (invincibleEnabled == false)
            {
                life--;
            }
            InvincEnabled();
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
                life++;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "PurplePlatform")
        {
            magic = 7;
        }
    }

    private void Awake() 
        {
            //Fixed FPS to 50(?)
            Application.targetFrameRate = 50;
        }
    IEnumerator TargetRoutine()
    {
            nearbyTargets = Physics.OverlapSphere(transform.position, noticeZone, LayerMaskTarget);
            if (nearbyTargets[0] != null)
            {
                dir = nearbyTargets[0].transform.position - playerT.position;
                dir.y = 0;
                Collider TargetCollider = nearbyTargets[0];
                TargetsObject = TargetCollider.transform.gameObject;
                if ((TargetsObject.transform.Find("TargetUI").gameObject.activeSelf) == false
                         && blockedtarget == false) {
                    TargetsObject.transform.Find("TargetUI").gameObject.SetActive(true);
                    blockedtarget = true;
                }
            }  
                /*Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,360);
                //}*/
                //}else
                //{
                while (!Input.GetKeyDown(KeyCode.Tab))
                {
                    yield return null;
                }
                //blockedtarget = false;
                //TargetsObject.transform.Find("TargetUI").gameObject.SetActive(false);
    }

    IEnumerator SwordAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SwordCollider.SetActive(false);
    }
    IEnumerator WaitShot(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    IEnumerator WaitInteractuate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Levercollider.SetActive(false);
    }
    }
