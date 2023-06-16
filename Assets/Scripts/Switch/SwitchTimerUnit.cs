using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTimerUnit : MonoBehaviour
{
    public bool boolchecker = false;
    public SwitchTimerManager SwitchTimerManager;
    AudioSource audioData;
    private bool flagAudio = false;
    private bool myreset;
    private Color defaultColor; 

    public bool flag;
    [SerializeField] private GameObject sphere;
    Renderer Rendererswitch;
    void Start()
    {
        Rendererswitch = sphere.GetComponent<Renderer>();
        audioData = GetComponent<AudioSource>();
        defaultColor = Rendererswitch.material.GetColor("_Color");
    }

    void Update(){

        if(SwitchTimerManager.resetflag == true){ 
            //Desactiva
            Rendererswitch.material.SetColor("_Color", defaultColor);
            //audioData.Play(0);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Shot"){
            boolchecker = true;
            
            Rendererswitch.material.SetColor("_Color", Color.magenta);
        }
    }

    
}
