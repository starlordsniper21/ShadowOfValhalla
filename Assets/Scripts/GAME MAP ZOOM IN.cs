using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MinimapZoom : MonoBehaviour
{
    public Camera minimapCamera;
    public float zoomSpeed = 1.0f;
    public float minSize = 1.0f;
    public float maxSize = 4.0f;

    private float originalSize;
    private Vector3 originalPosition;
    private Vector3 pointerOffset;

    public Button zoomInButton;
    public Button zoomOutButton;

    void Start()
    {
        originalSize = minimapCamera.orthographicSize;
        originalPosition = minimapCamera.transform.position;

        zoomInButton.onClick.AddListener(ZoomIn);
        zoomOutButton.onClick.AddListener(ZoomOut);
    }

    void ZoomIn()
    {
        float newSize = Mathf.Clamp(minimapCamera.orthographicSize - zoomSpeed, minSize, maxSize);
        minimapCamera.orthographicSize = newSize;
    }

    void ZoomOut()
    {
        // Reset camera to original size and position
        ResetZoom();
    }

    void ResetZoom()
    {
        minimapCamera.orthographicSize = originalSize;
        minimapCamera.transform.position = originalPosition;
    }
}
