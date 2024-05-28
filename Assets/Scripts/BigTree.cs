using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTree : MonoBehaviour
{
    [SerializeField] GameObject[] objHandGrabable;
    [SerializeField] GameObject objBlockingCollider;
    [SerializeField] HeightController heightController;

    // Update is called once per frame
    void Update()
    {
        if (heightController.GetCurrentOffset() > 0) // check if bigger than normal
        {
            foreach (GameObject i in objHandGrabable)
            {
                i.SetActive(true);
            }
            objBlockingCollider.SetActive(false);
        }
        else
        {
            foreach (GameObject i in objHandGrabable)
            {
                i.SetActive(false);
            }
            objBlockingCollider.SetActive(true);
        }
    }
}
