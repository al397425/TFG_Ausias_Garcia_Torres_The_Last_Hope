using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnableWeaponTest : MonoBehaviour
{
    public MeshRenderer espada;
    public int test = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(test == 1){
            espada.enabled = true;
        }
        if(test == 0){
            espada.enabled = false;
        }
    }
}
