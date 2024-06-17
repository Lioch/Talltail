using UnityEngine;

public class ShrinkHallway : MonoBehaviour
{
    [SerializeField] GameObject objBlockingColliderOne;
    [SerializeField] GameObject objBlockingColliderTwo;
    [SerializeField] HeightController heightController;
    [SerializeField] SizeController sizeController;

    void Update()
    {
        if (sizeController.enabled && !heightController.enabled)
        {
            if (sizeController.GetCurrentIndex() == 1) // check if smaller than normal
            {
                objBlockingColliderOne.SetActive(false);
            }
            else if (sizeController.GetCurrentIndex() == 0) // check if smaller than small
            {
                objBlockingColliderTwo.SetActive(false);
            }
            else
            {
                objBlockingColliderOne.SetActive(true);
                objBlockingColliderTwo.SetActive(true);
            }
        }
        else if (!sizeController.enabled && heightController.enabled)
        {
            if (heightController.GetCurrentIndex() == 1) // check if smaller than normal
            {
                objBlockingColliderOne.SetActive(false);
            }
            else if (heightController.GetCurrentIndex() == 0) // check if smaller than normal
            {
                objBlockingColliderTwo.SetActive(false);
            }
            else
            {
                objBlockingColliderOne.SetActive(true);
                objBlockingColliderTwo.SetActive(true);
            }
        }
        else
        {
            Debug.LogError($"Problem with height or size controller found for {gameObject.name}");
        }
    }
}
