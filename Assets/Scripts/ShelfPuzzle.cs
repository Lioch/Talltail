using UnityEngine;

public class ShelfPuzzle : MonoBehaviour
{
    [SerializeField] GameObject objChest;

    [SerializeField] Transform tfBluePotion;
    [SerializeField] Transform tfGreenPotion;
    [SerializeField] Transform tfBlueShelf;
    [SerializeField] Transform tfGreenShelf;

    [SerializeField] Vector3 blueBoxSize;
    [SerializeField] Vector3 greenBoxSize;

    bool boolFinishedPuzzle = false;
    float fltElapsedTime = 0f;

    void Update()
    {
        fltElapsedTime += Time.deltaTime;
        if (fltElapsedTime >= 1f)
        {
            fltElapsedTime = fltElapsedTime % 1f;
            CheckAll();
        }
    }

    private void CheckAll()
    {
        if (!boolFinishedPuzzle)
        {
            if (CheckBlueCollisions() && CheckGreenCollisions())
            {
                objChest.GetComponent<Animator>().SetTrigger("Unlocked");
                objChest.GetComponent<AudioSource>().Play();
                boolFinishedPuzzle = true;
            }
        }
    }

    private bool CheckBlueCollisions()
    {
        Collider[] hitCollidersBlue = Physics.OverlapBox(tfBlueShelf.position, blueBoxSize);

        //Check when there is a new collider coming into contact with the box
        for (int i = 0; i < hitCollidersBlue.Length; i++)
        {
            if (hitCollidersBlue[i].transform == tfBluePotion)
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckGreenCollisions()
    {
        Collider[] hitCollidersGreen = Physics.OverlapBox(tfGreenShelf.position, greenBoxSize);

        //Check when there is a new collider coming into contact with the box
        for (int i = 0; i < hitCollidersGreen.Length; i++)
        {
            if (hitCollidersGreen[i].transform == tfGreenPotion)
            {
                return true;
            }
        }
        return false;
    }

    void OnDrawGizmos()
    {
        if (tfBlueShelf != null && tfGreenShelf != null)
        {
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(tfBlueShelf.position, blueBoxSize);
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(tfGreenShelf.position, greenBoxSize);
        }
    }
}
