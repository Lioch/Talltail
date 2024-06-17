using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayChest : MonoBehaviour
{
    [SerializeField] GameObject objChest;
    [SerializeField] SceneController sceneController;
    [SerializeField] Transform transformPlayer;
    [SerializeField] float fltMinDist = 1;

    // Start is called before the first frame update
    void Start()
    {
        objChest.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 255, 255, 100);
        Gizmos.DrawSphere(transform.position, fltMinDist);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transformPlayer.position, this.transform.position) < fltMinDist)
        {
            objChest.SetActive(false);
        }
    }
}
