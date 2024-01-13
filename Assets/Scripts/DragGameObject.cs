using UnityEngine;

public class DragGameObject : MonoBehaviour
{
    private GameObject selectedObject;
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Down");
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Lego"))
                {
                    Debug.Log("Hit Lego");
                    isDragging = true;
                    selectedObject = hit.collider.gameObject;
                    offset = selectedObject.transform.position - hit.point;
                }
            }
        }

        // Check for mouse release
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            selectedObject = null;
        }

        // Move the object
        if (isDragging && selectedObject != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                selectedObject.transform.position = hit.point + offset;
            }
        }
    }
}
