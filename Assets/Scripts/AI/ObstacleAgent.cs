using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(NavMeshObstacle))]
public class ObstacleAgent : MonoBehaviour
{
    [SerializeField] private float CarvingTime = 0.5f;
    [SerializeField] private float CarvingMoveThreshold = 0.1f;

    private NavMeshAgent agent;
    private NavMeshObstacle obstacle;

    private float LastMoveTime;
    private Vector3 LastPosition;

    private void Awake() 
        {
            agent = GetComponent<NavMeshAgent>();
            obstacle = GetComponent<NavMeshObstacle>();

            obstacle.enabled = false;
            obstacle.carveOnlyStationary = false;
            obstacle.carving = true;

            LastPosition = transform.position;
        }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(LastPosition, transform.position) > CarvingMoveThreshold)
        {
            LastMoveTime = Time.time;
            LastPosition = transform.position;
        }
        if (LastMoveTime + CarvingTime < Time.time)
        {
            agent.enabled = false;
            obstacle.enabled = true;
        }
    }

    public void SetDestination(Vector3 Position)
    {
        obstacle.enabled = false;

        LastMoveTime = Time.time;
        LastPosition = transform.position;

        StartCoroutine(MoveAgent(Position));
    }

    private IEnumerator MoveAgent(Vector3 Position)
    {
        yield return null;
        agent.enabled = true;
        agent.SetDestination(Position);
    }
}
