using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator animCanvas;
    [SerializeField] private Animator animDoor;
    [SerializeField] private string strNextScene;
    [SerializeField] private float fltWaitTime = 2f;

    public void EndScene()
    {
        animCanvas.SetTrigger("End");
        animDoor.SetTrigger("Open");
        StartCoroutine(SwitchScenes());
    }

    private IEnumerator SwitchScenes()
    {
        yield return new WaitForSeconds(fltWaitTime);
        SceneManager.LoadScene(strNextScene);
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
