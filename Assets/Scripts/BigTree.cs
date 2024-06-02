using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTree : MonoBehaviour
{
    [SerializeField] GameObject[] objHandGrabable;
    [SerializeField] GameObject objBlockingCollider;
    [SerializeField] HeightController heightController;
    [SerializeField] SizeController sizeController;

    // Update is called once per frame
    void Update()
    {
        if (sizeController.enabled && !heightController.enabled)
        {
            if (sizeController.GetCurrentIndex() > 2) // check if bigger than normal
            {
                ActivatePuzzle();
            }
            else
            {
                DeactivatePuzzle();
            }
        }
        else if (!sizeController.enabled && heightController.enabled)
        {
            if (heightController.GetCurrentIndex() > 2) // check if bigger than normal
            {
                ActivatePuzzle();
            }
            else
            {
                DeactivatePuzzle();
            }
        }
        else
        {
            Debug.LogError($"Problem with height or size controller found for {gameObject.name}");
        }
    }

    private void ActivatePuzzle()
    {
        foreach (GameObject i in objHandGrabable)
        {
            i.SetActive(true);
        }
        objBlockingCollider.SetActive(false);
    }

    private void DeactivatePuzzle()
    {
        foreach (GameObject i in objHandGrabable)
        {
            i.SetActive(false);
        }
        objBlockingCollider.SetActive(true);
    }
}
