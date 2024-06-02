using UnityEngine;
using Oculus.Interaction.Locomotion;

public class SizeController : MonoBehaviour
{
    //[SerializeField] private PlayerLocomotor _locomotor;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] float[] fltScales = { 0.33f, 0.67f, 1, 1.5f, 2f }; // This defines the size change for the player game object
    [SerializeField] float fltChangeTime = 1;

    //private Vector3 v3PosRef;
    private int intCurrentIndex = 2;
    private float fltStartSize = 0;
    private float fltCurrentSize;
    private float fltTimer;

    // Start is called before the first frame update
    void Start()
    {
        fltTimer = fltChangeTime;
        fltCurrentSize = fltStartSize;
        //v3PosRef = transformPlayer.position;

        //if (_locomotor != null)
        //{
        //    // Subscribe to the event
        //    _locomotor.WhenLocomotionEventHandled += OnLocomotionEventHandled;
        //}
        //else
        //{
        //    Debug.LogError("PlayerLocomotor not found in the scene.");
        //}
    }
    //void OnDestroy()
    //{
    //    // Unsubscribe from the event to avoid memory leaks
    //    if (_locomotor != null)
    //    {
    //        _locomotor.WhenLocomotionEventHandled -= OnLocomotionEventHandled;
    //    }
    //}

    //private void OnLocomotionEventHandled(LocomotionEvent locomotionEvent, Pose delta)
    //{
    //    // Handle the locomotion event
    //    Debug.Log("Locomotion event handled. " + locomotionEvent.Translation);
    //    if (locomotionEvent.Translation != LocomotionEvent.TranslationType.None)
    //    {
    //        v3PosRef = new Vector3(transformPlayer.position.x, transformPlayer.position.y, transformPlayer.position.z);
    //    }
    //}

    private void Update()
    {
        if (fltStartSize != fltScales[intCurrentIndex])
        {
            AdjustHeadHeightOverTime();
        }
        else
        {
            AdjustHeadHeightInstant();
        }
    }

    private void AdjustHeadHeightOverTime()
    {
        if (fltTimer < fltChangeTime)
        {
            fltTimer += Time.deltaTime;
            float t = Mathf.Clamp01(fltTimer / fltChangeTime);
            fltCurrentSize = Mathf.Lerp(fltStartSize, fltScales[intCurrentIndex], t);
            transformPlayer.localScale = new Vector3(fltCurrentSize, fltCurrentSize, fltCurrentSize);
        }
        else
        {
            fltStartSize = fltScales[intCurrentIndex];
        }
    }

    private void AdjustHeadHeightInstant()
    {
        fltCurrentSize = fltScales[intCurrentIndex];
        transformPlayer.localScale = new Vector3(fltCurrentSize, fltCurrentSize, fltCurrentSize);
    }

    public void IncreaseHeightIndex() {
        if (intCurrentIndex < fltScales.Length)
        {
            intCurrentIndex += 1;
            fltTimer = 0;
            Debug.Log($"Fruit eaten! Current size index: {intCurrentIndex}");
        }
        else
        {
            Debug.Log("Max height reached");
        }
    }

    public void DecreaseHeightIndex()
    {
        if (intCurrentIndex >= 0)
        {
            intCurrentIndex -= 1;
            fltTimer = 0;
            Debug.Log($"Fruit eaten! Current size index: {intCurrentIndex}");
        }
        else
        {
            Debug.Log("Min height reached");
        }
    }

    public float GetCurrentIndex()
    {
        return intCurrentIndex;
    }
}
