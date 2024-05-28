using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacle : MonoBehaviour
{
    [SerializeField] GameObject objBlockingCollider;
    [SerializeField] HeightController heightController;

    void Update()
    {
        if (heightController.GetCurrentOffset() < 0) // check if smaller than normal
        {
            objBlockingCollider.SetActive(false);
        }
        else
        {
            objBlockingCollider.SetActive(true);
        }
    }
}
