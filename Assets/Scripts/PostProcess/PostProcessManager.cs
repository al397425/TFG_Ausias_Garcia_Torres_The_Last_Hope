using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessManager : MonoBehaviour
{
    private PostProcessVolume PostProcessVolume;
    private Vignette vignette;
    [SerializeField] private Animator animatorCam;
    // Start is called before the first frame update
    void Start()
    {
        PostProcessVolume = GetComponent<PostProcessVolume>();
        PostProcessVolume.profile.TryGetSettings(out vignette); //get vignette
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void VignetteChange(){

        StartCoroutine(VignetteRoutine());
    }

    private IEnumerator VignetteRoutine()
 {
    animatorCam.SetBool("Shake", true);
    vignette.intensity.value = 0.3f;
    vignette.color.Override(Color.red);
    yield return new WaitForSeconds(0.2f);
    vignette.color.Override(Color.black);
    yield return new WaitForSeconds(0.2f);
    vignette.intensity.value = 0.25f;
    yield return new WaitForSeconds(0.2f);
    animatorCam.SetBool("Shake", false);
 }
}
