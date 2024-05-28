using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDoor : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] Transform transformPlayer;
    [SerializeField] float fltMinDist = 1;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255,255,255,100);
        Gizmos.DrawSphere(transform.position, fltMinDist);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transformPlayer.position, this.transform.position) < fltMinDist)
        {
            sceneController.EndScene();
        }
    }
}
