using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ObstacleAgent))]

public class AIMovement : MonoBehaviour
{
    [SerializeField] private int patrolSwitch;
    [SerializeField] private float timer;
    [SerializeField] private Animator anim; 
    public Quaternion angulo;
    public float grado;
    [SerializeField] Collider enemy_Collider;
    
    //Detect Player
    public   GameObject target;
    public bool attacking;

    //Player in Range
    public Enemy_Range range;
    
    //NavMesh
    public ObstacleAgent agentobs;
    public NavMeshAgent agent;
    public float distance_Attack;
    public float range_vision;
    [SerializeField] private float speed;
    Vector3 RandomPoint;
    bool reached = false;
    float dist;
    void Start()
    {
        
        
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");

        //get collider damage
        Collider enemy_Collider = GetComponent<Collider>();

        dist=agent.remainingDistance;
        Debug.Log("AAAAAAAAAAA" + dist);

    }
    private void Awake() 
        {
            agentobs = GetComponent<ObstacleAgent>();
        }
    
    

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Enemy_behaviour();
        
    }
    public void Enemy_behaviour(){

        if(Vector3.Distance(transform.position, target.transform.position) > range_vision)
        {
            agentobs.enabled = false;
            anim.SetBool("IsRunning", false);
            timer += 1 * Time.deltaTime;
            if(timer >=2)
            {
                patrolSwitch = Random.Range(0, 2);
                timer = 0;
            }
            switch(patrolSwitch)
            {
                case 0:
                        anim.SetBool("IsWalking", false);
                        break;
                case 1:
                        grado = Random.Range(0, 360);
                        angulo = Quaternion.Euler(0, grado, 0);
                        patrolSwitch++;
                        break;
                case 2:
                        
                        dist=agent.remainingDistance;
                        if (dist!= Mathf.Infinity && agent.pathStatus==NavMeshPathStatus.PathComplete && agent.remainingDistance==0){
                            NavMeshPath path = new NavMeshPath();
                            //Arrived.
                            RandomPoint = 2.5f * Random.insideUnitSphere + this.transform.position;
                            Debug.Log(RandomPoint+ "Random Point");
                        
                            //transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                            agent.CalculatePath(RandomPoint,path);
                            if (path.status != NavMeshPathStatus.PathComplete)
                            {
                            }
                            if (path.status == NavMeshPathStatus.PathComplete)
                            {
                                agentobs.SetDestination(RandomPoint);
                            }

                            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
                            anim.SetBool("IsWalking",true);
                        }
                        break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            agentobs.enabled = true;
            agentobs.SetDestination(target.transform.position);
            Debug.Log("Destination " + target.transform.position);

            if(Vector3.Distance(transform.position, target.transform.position) > distance_Attack && !attacking)
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", true);
            }
            else
            {
                if(!attacking)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                    anim.SetBool("IsWalking", false);
                    anim.SetBool("IsRunning", true);
                }
            }
            /*
            if(Vector3.Distance(transform.position, target.transform.position) > 1 && !attacking )
            {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            anim.SetBool("IsWalking", false);

            anim.SetBool("IsRunning", true);
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
            anim.SetBool("IsAttacking", false);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                enemy_Collider.enabled = true;
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);

                //anim.SetBool("IsAttacking", true);
                //attacking = true;

            }*/
        }
        if(attacking)
                {
                    agentobs.enabled = false;
                }

    }

    public void Final_Animation()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > distance_Attack + 0.2f)
        {
            anim.SetBool("IsAttacking", false);
        }
        
        attacking = false;
        enemy_Collider.enabled = false;
        range.GetComponent<CapsuleCollider>().enabled = true;
    }

}
