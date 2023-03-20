using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public Transform Goal;
    public float SpaceBetween = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(new Vector3(Goal.position.x, 0, Goal.position.z), transform.position) >= SpaceBetween);
        
        Vector3 direction = new Vector3(Goal.position.x-1, 0, Goal.position.z-1) - new Vector3(transform.position.x, 0, transform.position.z);
        Debug.Log(direction);
        transform.Translate(direction * Time.deltaTime);
    }
}
