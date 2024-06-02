using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacle : MonoBehaviour
{
    [SerializeField] GameObject objBlockingCollider;
    [SerializeField] HeightController heightController;
    [SerializeField] SizeController sizeController;

    void Update()
    {
        if (sizeController.enabled && !heightController.enabled)
        {
            if (sizeController.GetCurrentIndex() < 2) // check if smaller than normal
            {
                objBlockingCollider.SetActive(false);
            }
            else
            {
                objBlockingCollider.SetActive(true);
            }
        }
        else if (!sizeController.enabled && heightController.enabled)
        {
            if (heightController.GetCurrentIndex() < 2) // check if smaller than normal
            {
                objBlockingCollider.SetActive(false);
            }
            else
            {
                objBlockingCollider.SetActive(true);
            }
        }
        else
        {
            Debug.LogError($"Problem with height or size controller found for {gameObject.name}");
        }
    }
}
