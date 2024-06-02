using UnityEngine;

public class MessageHolder : MonoBehaviour
{
    [SerializeField] private GameObject objMessage;

    private void OnTriggerEnter(Collider other)
    {
        objMessage.SetActive(true);
    }
}
