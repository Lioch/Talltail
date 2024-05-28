using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private string strNextScene;
    [SerializeField] private float fltFadeTime = 2f;
    [SerializeField] private float fltWaitTime = 1f;
    [SerializeField] private MeshRenderer MRDarkSphere;

    private float timer = 0f;
    private bool finishedStartFade = false;

    private void Update()
    {
        while (timer < fltFadeTime && !finishedStartFade)
        {
            FadeMat(1, 0);
        }
        finishedStartFade = true;
        timer = 0;
    }

    public void EndScene()
    {
        if (animDoor != null)  // some scenes might not have a door
        {
            animDoor.SetTrigger("Open");
        }
        StartCoroutine(SwitchScenes());
    }

    private IEnumerator SwitchScenes()
    {
        while (timer < fltFadeTime)
        {
            FadeMat(0, 1);
        }
        timer = 0;
        yield return new WaitForSeconds(fltWaitTime);
        SceneManager.LoadScene(strNextScene);
    }

    private void FadeMat(float fltStartApha, float fltEndApha)
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / fltFadeTime);
        float fltNewAlpha = Mathf.Lerp(fltStartApha, fltEndApha, t);
        MRDarkSphere.material.color = new Color(
            MRDarkSphere.material.color.r, 
            MRDarkSphere.material.color.g, 
            MRDarkSphere.material.color.b, 
            fltNewAlpha);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (true) // WIP in case of trigger necessity
        {
            Debug.Log(other.name);
            EndScene();
        }
    }
}
