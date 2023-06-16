using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSystem : MonoBehaviour
{
    public bool boolchecker = false;
    [SerializeField] private string debugAnimator;
    public SwitchSystem switchSystem;
    public bool flag = false;
    AudioSource audioData;
    private bool flagAudio = false;
    private Animator animator;
    private bool myreset; 
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Update(){
        if(switchSystem.resetflag == true){ //Desactiva
            myreset = switchSystem.resetflag;
            print("my reset desactivar"+ myreset +" "+ this.gameObject.name);
            //Do Reset animation
            boolchecker = false;
            animator.SetBool("IsActivated", false);
            debugAnimator = "IsActivated " + animator.GetBool((Animator.StringToHash("IsActivated")));
            //deactiavesound
            audioData.Play(0);
            StartCoroutine(WaitDeactivateLever(1.5f));
            
        }
        
    }
    public void OnTriggerEnter(Collider other ){
        
        if(other.gameObject.tag == "activateLever"){ //Activated
        
            if(flag == false){
                myreset = switchSystem.resetflag;
                print("my reset activar"+ myreset +" "+ this.gameObject.name);
                if(flagAudio == false){
                    audioData.Play(0);
                    flagAudio = true;
                }
                animator.SetBool("IsActivated", true);
                debugAnimator = "IsActivated " + animator.GetBool((Animator.StringToHash("IsActivated")));
               //Do Activate Animation
                boolchecker = true;
                flag = true; 
            }
            /*if(flag == true && flagAudio = false){
                    audioData.Play(0);
                    flagAudio = true;
                }*/
            //Do Activate Animation
        }
    }
    public void OnTriggerExit(Collider other) {

        flagAudio = false;
    }
    IEnumerator WaitDeactivateLever(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        switchSystem.resetflag = false;
    }
}
