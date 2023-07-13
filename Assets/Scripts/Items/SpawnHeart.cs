using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : MonoBehaviour
{
    [SerializeField] private GameObject breakparticle;
    public GameObject positionPot;
    [SerializeField] private GameObject heart;

    
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "SwordCollider")
        {   
            GameObject particlesbreak = Instantiate(breakparticle, this.transform.position , Quaternion.identity);
            
            Instantiate(heart, this.transform.position , Quaternion.identity);
            Destroy(particlesbreak, 2);
            Destroy(this.gameObject);
            
        }
    }
}
