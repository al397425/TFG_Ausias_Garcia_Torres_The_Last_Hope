using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTree : MonoBehaviour
{
    //public GameObject TreePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisiontree");
        //if (collision.gameObject.tag == "Shot")
        //{
            Debug.Log("pipo");
            Destroy(this.gameObject);
        //}
        /*if(other.gameObject.tag == "SwordCollider"){
            Debug.Log("Tree cut");
            //GameObject ParticlesTree = Instantiate(TreePos, this.transform.position, Quaternion.identity);
        //Destroy(ParticlesTree, 1);
        Destroy(this.gameObject, 1);
        }*/
        
    }
}
