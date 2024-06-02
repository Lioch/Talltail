using UnityEngine;
using Oculus.Interaction.Locomotion;

public class HeightController : MonoBehaviour
{
    [SerializeField] private PlayerLocomotor _locomotor;
    [SerializeField] private Transform transformPlayer;
    [SerializeField] float[] fltOffsets = { -0.5f, -0.25f, 0, 0.25f, 0.5f }; // This defines the offset for the PlayerLocomotor
    [SerializeField] float fltChangeTime = 2;

    private Vector3 v3PosRef;
    private int intCurrentIndex = 2;
    private float fltStartOffset = 0;
    private float fltCurrentOffset;
    private float fltTimer;

    // Start is called before the first frame update
    void Start()
    {
        fltTimer = fltChangeTime;
        fltCurrentOffset = fltStartOffset;
        v3PosRef = transformPlayer.position;

        if (_locomotor != null)
        {
            // Subscribe to the event
            _locomotor.WhenLocomotionEventHandled += OnLocomotionEventHandled;
        }
        else
        {
            Debug.LogError("PlayerLocomotor not found in the scene.");
        }
    }
    void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        if (_locomotor != null)
        {
            _locomotor.WhenLocomotionEventHandled -= OnLocomotionEventHandled;
        }
    }

    private void OnLocomotionEventHandled(LocomotionEvent locomotionEvent, Pose delta)
    {
        // Handle the locomotion event
        Debug.Log("Locomotion event handled. " + locomotionEvent.Translation);
        if (locomotionEvent.Translation != LocomotionEvent.TranslationType.None)
        {
            v3PosRef = new Vector3(transformPlayer.position.x, transformPlayer.position.y, transformPlayer.position.z);
        }
    }

    private void Update()
    {
        if (fltStartOffset != fltOffsets[intCurrentIndex])
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
            fltCurrentOffset = Mathf.Lerp(fltStartOffset, fltOffsets[intCurrentIndex], t);
            transformPlayer.position = new Vector3(transformPlayer.position.x, v3PosRef.y + fltCurrentOffset, transformPlayer.position.z);
        }
        else
        {
            fltStartOffset = fltOffsets[intCurrentIndex];
        }
    }

    private void AdjustHeadHeightInstant()
    {
        fltCurrentOffset = fltOffsets[intCurrentIndex];
        transformPlayer.position = new Vector3(transformPlayer.position.x, v3PosRef.y + fltCurrentOffset, transformPlayer.position.z);
    }

    public void IncreaseHeightIndex() {
        if (intCurrentIndex < fltOffsets.Length)
        {
            intCurrentIndex += 1;
            fltTimer = 0;
            Debug.Log($"Fruit eaten! Current height index: {intCurrentIndex}");
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
            Debug.Log($"Fruit eaten! Current height index: {intCurrentIndex}");
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
