using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSystem : MonoBehaviour
{
    public bool boolchecker = false;
    public SwitchSystem switchSystem;
    public bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update(){
        if(switchSystem.resetflag == true){
            //hacer animacion reset
            boolchecker = false;
        }
        
    }

    
    public void OnTriggerEnter(Collider other ){

        if(other.gameObject.tag == "activateLever"){
            Debug.Log("Ha colisionado y ha activado la palanca");
            if(flag == false){
               //hacer animacion activar
                boolchecker = true;
                flag = true; 
            }
            /*//hacer animacion activar
            boolchecker = true;*/
        }
        
    }
}
