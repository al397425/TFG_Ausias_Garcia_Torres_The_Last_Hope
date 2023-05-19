using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAvoidance : MonoBehaviour
{
    GameObject[] enemiesArray;
    public float SpaceBetween = 1.0f;
    public EnemyLifeTest EnemyLifeTest1;
    // Start is called before the first frame update
    void Start()
    {
        enemiesArray = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in enemiesArray) {
            {
                float distance = Vector3.Distance(new Vector3(go.transform.position.x, 0, go.transform.position.z), new Vector3(this.transform.position.x, 0, this.transform.position.z));
                if(distance <= SpaceBetween)
                {
                    Vector3 direction = new Vector3(this.transform.position.x, 0, this.transform.position.z) - new Vector3(go.transform.position.x, 0, go.transform.position.z);
                    
                    
                    transform.Translate(direction * Time.deltaTime);
                }
            }
        }
    }
}
