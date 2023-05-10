using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSystem : MonoBehaviour
{
    public bool boolchecker = false;
    public SwitchSystem switchSystem;
    public bool flag = false;
    AudioSource audioData;
    private bool flagAudio = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Update(){
        if(switchSystem.resetflag == true){
            //hacer animacion reset
            boolchecker = false;
            animator.SetBool("IsActivated", false);
            
        }
        
    }
    
    public void OnTriggerEnter(Collider other ){

        if(other.gameObject.tag == "activateLever"){
            Debug.Log("Ha colisionado y ha activado la palanca");
            if(flag == false){
                if(flagAudio == false){
                    audioData.Play(0);
                    flagAudio = true;
                }
                
                animator.SetBool("IsActivated", true);
               //hacer animacion activar
                boolchecker = true;
                flag = true; 
            }

            if(flag == true){
                    audioData.Play(0);
                    flagAudio = true;
                }
            /*//hacer animacion activar
            */
        }
        
    }
    public void OnTriggerExit(Collider other) {
        flagAudio = false;

    }
}
