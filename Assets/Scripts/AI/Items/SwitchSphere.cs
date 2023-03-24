using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSphere : MonoBehaviour
{
    
    //public int Health = 10;

    private void OnCollisionEnter(Collision other){

        if(other.transform.tag =="Shot")
        {
            /*Health -=2;

            if(health <= 0)
            {
                Destroy(this.gameObject);
            }*/

            //Move la posicion de el puente o hacer una animación
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
