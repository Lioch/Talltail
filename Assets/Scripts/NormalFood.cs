using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NormalFood : MonoBehaviour
{
    [SerializeField] Transform headPos;
    [SerializeField] float fltMinDistance = 0.5f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    private bool isEaten = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, headPos.position);
        if (distance < fltMinDistance && !isEaten)
        {
            isEaten = true;
            audioSource.PlayOneShot(clip);
            StartCoroutine(Eat());
        }
    }

    private IEnumerator Eat()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
