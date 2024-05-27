using UnityEngine;

public class MagicFruit : MonoBehaviour
{
    [SerializeField] HeightController heightController;
    [SerializeField] Transform headPos;
    [SerializeField] float fltMinDistance = 0.5f;
    [Tooltip("If true, it is a grow fruit. If not is a shrink fruit")]
    [SerializeField] bool isGrowFruit;   

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, headPos.position);
        if (distance < fltMinDistance)
        {
            if (isGrowFruit)
            {
                heightController.IncreaseHeightIndex();
            }
            else
            {
                heightController.DecreaseHeightIndex();
            }
            this.gameObject.SetActive(false);
        }
    }
}
