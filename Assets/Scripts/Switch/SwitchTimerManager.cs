using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTimerManager : MonoBehaviour
{
    [SerializeField] private GameObject Chest;
    public int counter;
    public bool flagCompleted = false;
    [SerializeField] private SwitchTimerUnit switch1;
    [SerializeField] private SwitchTimerUnit switch2;
    [SerializeField] private SwitchTimerUnit switch3;
    [SerializeField] private SwitchTimerUnit switch4;
    [SerializeField] private SwitchTimerUnit switch5;
    [SerializeField] private SwitchTimerUnit switch6;
    [SerializeField] private AudioSource audioSourceWin;
    [SerializeField] private AudioSource audioSourceError;

    //int counter = 0;
    public bool resetflag = false;
    private bool flag1 = false; 
    private bool flag2 = false; 
    private bool flag3 = false; 
    private bool flag4 = false; 
    private bool flag5 = false;
    private bool flag6 = false;

    //Audio
    void Start()
    {
        
    }
    void Update()
    {
        
        if((switch1.boolchecker || switch2.boolchecker || switch3.boolchecker ||
        switch4.boolchecker || switch5.boolchecker || switch6.boolchecker ) == true 
        && ((flag1 && flag2 && flag3 && flag4 && flag5 && flag6 ) == false))
        {
            StartCoroutine(Timer());
        }
        
        GetActiveSpheres();
        if(counter == 5 && flagCompleted == false){
            Destroy(Chest);
            /*Chest.SetActive(true);
            audioSourceWin.Play(0);
            flagCompleted = true;*/
        }
    }
    void GetActiveSpheres(){
        if(switch1.boolchecker == true && flag1 == false)
        {
            counter++;
            flag1 = true;  
        }
        if(switch2.boolchecker == true && flag2 == false)
        {
            counter++;
            flag2 = true; 
        }
        if(switch3.boolchecker == true && flag3 == false)
        {
            counter++;
            flag3 = true; 
        } 
        if(switch4.boolchecker == true && flag4 == false)
        {
            counter++;
            flag4 = true; 
        } 
        if(switch5.boolchecker == true && flag5 == false)
        {
            counter++;
            flag5 = true; 
        }
        if(switch6.boolchecker == true && flag6 == false)
        {
            counter++;
            flag6 = true; 
        } 
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(40);
        resetflag = true;
        counter = 0;
        switch1.boolchecker = false; flag1 = false; 
        switch2.boolchecker = false; flag2 = false; 
        switch3.boolchecker = false; flag3 = false; 
        switch4.boolchecker = false; flag4 = false; 
        switch5.boolchecker = false; flag5 = false; 
        switch6.boolchecker = false; flag6 = false;
         
    }

}

