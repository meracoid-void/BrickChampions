using UnityEngine;

public class LegoSnap : MonoBehaviour
{
    public Transform snapPointTop; // Assign the top snap point in the editor
    public Transform snapPointBottom; // Assign the bottom snap point in the editor
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        LegoSnap otherBlock = other.GetComponent<LegoSnap>();

        if (otherBlock != null && Input.GetMouseButtonUp(0)) // Snap on mouse release
        {
            float distanceToSnap = Vector3.Distance(snapPointBottom.position, otherBlock.snapPointTop.position);

            if (distanceToSnap < 0.1f) // Check if close enough to snap
            {
                // Align position and rotation
                Vector3 snapPosition = otherBlock.snapPointTop.position - (snapPointBottom.position - transform.position);
                transform.position = snapPosition;
                transform.rotation = otherBlock.transform.rotation;

                // Optionally, disable physics
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
            }
        }
    }
}
