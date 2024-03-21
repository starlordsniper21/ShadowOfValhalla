using UnityEngine;

public class MinimapCameraDrag : MonoBehaviour
{
    private Vector3 touchStartPos;
    private bool isDragging = false;

    public float minX = -10f; // Minimum X position
    public float maxX = 10f;  // Maximum X position
    public float minY = -10f; // Minimum Y position
    public float maxY = 10f;  // Maximum Y position

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle touch phase
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Record the touch start position
                    touchStartPos = touch.position;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        // Convert touch position to world space
                        Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(touch.position);
                        Vector3 touchStartPosWorld = Camera.main.ScreenToWorldPoint(touchStartPos);

                        // Calculate the difference in touch position
                        Vector3 touchDelta = touchPosWorld - touchStartPosWorld;

                        // Apply the movement to the camera
                        Vector3 newPosition = transform.position - touchDelta;
                        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX); // Clamp X position
                        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY); // Clamp Y position
                        transform.position = newPosition;

                        // Update touch start position
                        touchStartPos = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }
    }
}
