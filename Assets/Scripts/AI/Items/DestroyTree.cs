using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTree : MonoBehaviour
{
    [SerializeField] private GameObject TreePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.tag == "Shot")
        //{

            //Destroy(this.gameObject);
        //}
        if(other.gameObject.tag == "SwordCollider"){
            Debug.Log("Tree cut");
            GameObject ParticlesTree = Instantiate(TreePos, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject, 0.2f);
        Destroy(ParticlesTree, 1);
        }
        
    }
    
}
