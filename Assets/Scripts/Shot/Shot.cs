using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject hit;
    public GameObject Fire;
    // Start is called before the first frame update
    void Start()
    {
        //Move the Shot, generate particles, and destroy the particles
        rb.AddForce(transform.forward *500);
        GameObject Particles1 = Instantiate(Fire, this.transform.position , Quaternion.identity);
        Destroy(Particles1, 2);
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colision");
        //Generate Collision Particles and destroy on collide with a wall
        GameObject Particles2 = Instantiate(hit, this.transform.position, Quaternion.identity);
        Destroy(Particles2, 2);
        Destroy(this.gameObject);
    }
    
}
