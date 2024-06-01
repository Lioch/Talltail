using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MagicFruit : MonoBehaviour
{
    [SerializeField] HeightController heightController;
    [SerializeField] Transform headPos;
    [SerializeField] float fltMinDistance = 0.5f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [Tooltip("If true, it is a grow fruit. If not is a shrink fruit")]
    [SerializeField] bool isGrowFruit;

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

            if (isGrowFruit)
            {
                heightController.IncreaseHeightIndex();
            }
            else
            {
                heightController.DecreaseHeightIndex();
            }

            StartCoroutine(Eat());
        }
    }

    private IEnumerator Eat()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
