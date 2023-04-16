using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Range : MonoBehaviour
{
    public Animator anim;
    public AIMovement enemy;

    
     void OnCollisionEnter(Collision collision){
        
         if (collision.gameObject.tag == "Player")
        {
            Debug.Log("pipo");
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
