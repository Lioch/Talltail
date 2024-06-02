using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FruitHeightChange : MonoBehaviour
{
    [SerializeField] HeightController heightController;
    [SerializeField] SizeController sizeController;
    [SerializeField] Transform headPos;
    [SerializeField] float fltMinDistance = 0.5f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [Tooltip("If true, it is a grow fruit. If not is a shrink fruit")]
    [SerializeField] bool isGrowFruit;

    private bool useSizeConntroller;
    private bool isEaten = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // check which controller is being used
        if (heightController == null || sizeController == null)
        {
            Debug.LogError($"No height or size controller found for {gameObject.name}");
            useSizeConntroller = false;
        }
        if (heightController.enabled && sizeController.enabled)
        {
            Debug.LogWarning($"Both height and size controller found for {gameObject.name}. Using HeightController as default.");
            useSizeConntroller = false;
        }
        else if (heightController.enabled)
        {
            useSizeConntroller = false;
        }
        else if (sizeController.enabled)
        {
            useSizeConntroller = true;
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
            if (useSizeConntroller)
            {
                if (isGrowFruit)
                {
                    sizeController.IncreaseHeightIndex();
                }
                else
                {
                    sizeController.DecreaseHeightIndex();
                }
            }
            else
            {
                if (isGrowFruit)
                {
                    heightController.IncreaseHeightIndex();
                }
                else
                {
                    heightController.DecreaseHeightIndex();
                }
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
