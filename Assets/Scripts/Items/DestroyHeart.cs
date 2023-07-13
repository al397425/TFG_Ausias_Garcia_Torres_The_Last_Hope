using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeart : MonoBehaviour
{
    [SerializeField] private CharMovement charac;
    // Start is called before the first frame update

private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player")
        {   
            charac.life++;
            charac.magic++;
            Destroy(this.gameObject);
            
        }
    }
}
