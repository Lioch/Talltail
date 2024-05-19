using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Message : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private Image[] imageObjects;
    [SerializeField] private TMP_Text[] textObjects;
    private float alpha = 1;

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        while (alpha > 0)
        {
            //Fade from 1 to 0
            alpha -= (fadeSpeed * Time.deltaTime);
            Debug.Log(alpha);
            foreach (Image i in imageObjects)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, alpha);
            }
            foreach (TMP_Text i in textObjects)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, alpha);
            }

            yield return new WaitForSeconds(0.05f);
        }
        gameObject.SetActive(false);
    }
}
