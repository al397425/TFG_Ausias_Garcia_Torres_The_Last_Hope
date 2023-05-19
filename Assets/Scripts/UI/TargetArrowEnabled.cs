using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArrowEnabled : MonoBehaviour
{
    [SerializeField] private CharMovement CharMovement;
    void OnEnable()
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        Debug.Log("WaitNarration started");
        //get the component of the player this can be made in the editor but to make a prefab enemy is better this way
        GameObject player = GameObject.Find("Player");
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        //yield on a new YieldInstruction that waits for 0.4 seconds.
        //yield return new WaitUntil(() => player.GetComponent<CharMovement>().blockedtarget == false);

        while (!player.GetComponent<CharMovement>().blockedtarget)
        {
        yield return null;
        }
        while (player.GetComponent<CharMovement>().blockedtarget)
        {
            yield return true;
            this.gameObject.SetActive(false);
        }
        Debug.Log("WaitNarration complete");
        //if(player.GetComponent<CharMovement>().blockedtarget == false)
        //this.gameObject.SetActive(false);
        //After we have waited 0.4f seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
