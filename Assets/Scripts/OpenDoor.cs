using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private CharMovement character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other ){
        
        if(other.gameObject.tag == "activateLever" && character.havekeydoor == true)
        {
            Destroy(this.gameObject);
        }
    } 
}
