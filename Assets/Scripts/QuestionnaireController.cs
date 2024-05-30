using UnityEngine;
using UnityEngine.UI;

public class QuestionnaireController : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private GameObject[] UIPages;
    
    private int[] intAnswers;
    private int intPageIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (UIPages.Length == 0)
        {
            Debug.LogError("No UI page objects found");
            return;
        }
        
        intAnswers = new int[UIPages.Length];
        foreach (GameObject i in UIPages)
        {
            i.SetActive(false);
        }
        UIPages[0].SetActive(true);
    }

    public void SetAnswer(Slider slider)
    {
        intAnswers[intPageIndex] = (int)slider.value;
        Debug.Log($"Set answer {intPageIndex} to {slider.value}");
    }

    public void GoNextPage()
    {
        foreach (GameObject i in UIPages)
        {
            i.SetActive(false);
        }

        if (++intPageIndex >= UIPages.Length)
        {
            sceneController.EndScene();
        }
        else
        {
            UIPages[intPageIndex].SetActive(true);
        }
    }

    public void GoPrevPage()
    {
        foreach (GameObject i in UIPages)
        {
            i.SetActive(false);
        }
        UIPages[--intPageIndex].SetActive(true);
    }
}
