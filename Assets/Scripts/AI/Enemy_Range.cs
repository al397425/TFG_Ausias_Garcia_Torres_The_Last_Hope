using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Range : MonoBehaviour
{
    public Animator anim;
    public AIMovement enemy;

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            //if(!enemy.stunned)
            //{
                anim.SetBool("IsWalking",false);
                anim.SetBool("IsRunning",false);
                anim.SetBool("IsAttacking",true);
                enemy.attacking = true;
                GetComponent<BoxCollider>().enabled = false;
            //}
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
