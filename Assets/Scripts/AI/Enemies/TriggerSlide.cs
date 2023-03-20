using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSlide : MonoBehaviour
{
    [SerializeField] private float slideSpeed = 1000.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
        


    //While the player is in collision with the trigger, move him forward 
    public void OnTriggerStay (Collider other) {
        CharacterController controller = other.GetComponent<CharacterController>();
        if(controller != null)
        {
             Vector3 forward = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove( forward  * slideSpeed * Time.deltaTime); 
        }
    }
}
