using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private GameObject objKey;
    [SerializeField] private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.name);
        Debug.LogWarning(objKey.name);
        if (other.gameObject.name == objKey.name)
        {
            anim.SetBool("Unlocked", true);
        }
    }
}
