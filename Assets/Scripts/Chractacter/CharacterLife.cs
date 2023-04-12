using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLife : MonoBehaviour
{


    void OnTriggerEnter(Collider coll) {
        {
            if (coll.CompareTag("enemyWeapon"))
            {
                Debug.Log("Daño personaje");
            }

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
