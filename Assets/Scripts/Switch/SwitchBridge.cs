using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBridge : MonoBehaviour
{
    public GameObject Bridge;
    public bool flag;
    /*private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = WaitAndPrint(3.0f);
    }

    public IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            MoveBridge();
            yield return new WaitForSeconds(waitTime);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Shot"){
            StartCoroutine(coroutine);
            
            StopCoroutine(coroutine);
        }
    }
    void MoveBridge(){
        for(int i=0;i<500;i++){
            Bridge.transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }*/

    public Transform Goal;
    void Start()
    {
        
    }
    void FixedUpdate(){
        if(flag ==true){
            Vector3 direction = new Vector3(Goal.position.x, 0, Goal.position.z) - new Vector3(Bridge.transform.position.x, 0, Bridge.transform.position.z);
            Bridge.transform.Translate(direction * Time.deltaTime*0.9f);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Shot"){
            flag = true;
        }
}
}

