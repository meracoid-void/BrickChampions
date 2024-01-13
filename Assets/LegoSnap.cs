using UnityEngine;

public class LegoSnap : MonoBehaviour
{
    public Transform snapPoint; // Assign the snap point in the editor

    private void OnTriggerEnter(Collider other)
    {
        LegoSnap otherBlock = other.GetComponent<LegoSnap>();

        if (otherBlock != null && otherBlock.snapPoint != null)
        {
            Vector3 snapPosition = otherBlock.snapPoint.position;
            transform.position = snapPosition;
            // Add more logic here if needed, like aligning rotation, disabling physics, etc.
        }
    }
}
