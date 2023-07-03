using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeTest : MonoBehaviour
{
    [SerializeField] private int life = 1;
    private bool candamage = true;
    private GameObject turtleShell;
    Renderer RendererEnemy;
    // Start is called before the first frame update
    void Start()
    {
        turtleShell = transform.GetChild(1).gameObject;
        print(turtleShell);
        RendererEnemy= turtleShell.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0){
            Destroy(this.gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "SwordCollider" && candamage == true)
        {
            StartCoroutine(Damage());
            StartCoroutine(Renderanimation());
            
        }
    }
    private IEnumerator Damage()
    {
        life--;
        candamage = false;
        print(life +"me queda vida");
        yield return new WaitForSeconds(0.5f);
        candamage = true;
        
        
    }
    private IEnumerator Renderanimation()
    {
    RendererEnemy.material.SetColor("_Color", Color.red);
    yield return new WaitForSeconds(0.3f);
    RendererEnemy.material.SetColor("_Color", Color.white);
    }
}
