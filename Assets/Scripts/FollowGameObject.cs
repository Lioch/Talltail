using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
    [SerializeField] GameObject gameObject;

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            this.transform.position = gameObject.transform.position;
        }
    }
}
