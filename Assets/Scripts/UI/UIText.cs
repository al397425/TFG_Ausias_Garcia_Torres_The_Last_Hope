using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIText : MonoBehaviour
{
    public GameObject Sign1;
    public GameObject Sign2;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player" &&
         gameObject.tag == "Sign1")
        {
            Sign1.SetActive(true);
        }
        if(other.gameObject.tag == "Player" &&
         gameObject.tag == "Sign2")
        {
            Sign2.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" &&
         gameObject.tag == "Sign1")
        {
            Sign1.SetActive(false);
        }
        if (other.gameObject.tag == "Player" &&
         gameObject.tag == "Sign2")
        {
            Sign2.SetActive(false);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
