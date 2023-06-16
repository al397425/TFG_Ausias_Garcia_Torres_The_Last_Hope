using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImage : MonoBehaviour
{
     //private GameObject lever;
     [SerializeField] private GameObject image;
     //private Transform TransformObject;
    // Start is called before the first frame update
    void Start()
    {
        //image = lever.transform.Find("key").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other ){
        
        if(other.gameObject.tag == "Player")
        {
            image.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other ){
        
        if(other.gameObject.tag == "Player")
        {
            image.SetActive(false);
        }
    }
}
