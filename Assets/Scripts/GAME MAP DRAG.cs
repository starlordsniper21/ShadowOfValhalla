using UnityEngine;
using UnityEngine.UI;

public class MinimapCameraControl : MonoBehaviour
{
    private Vector3 touchStartPos;
    private bool isDragging = false;

    public Camera mapCamera; 
    public Slider zoomSlider;

    public float minZoom = 2f;     
    public float maxZoom = 10f;    

    public Vector3 defaultPosition; 
    public float defaultZoom = 5f;  

    void Start()
    {
      
        defaultPosition = transform.position;

        zoomSlider.value = Mathf.InverseLerp(minZoom, maxZoom, defaultZoom);
    }

    void Update()
    {
       
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector3 touchPosWorld = mapCamera.ScreenToWorldPoint(touch.position);
                        Vector3 touchStartPosWorld = mapCamera.ScreenToWorldPoint(touchStartPos);
                        Vector3 touchDelta = touchPosWorld - touchStartPosWorld;

                        Vector3 newPosition = transform.position - touchDelta;
                        transform.position = newPosition;

                        touchStartPos = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }


        float targetZoom = Mathf.Lerp(minZoom, maxZoom, zoomSlider.value);
        mapCamera.orthographicSize = targetZoom;

      
        if (zoomSlider.value == 1)
        {
            float currentZoom = mapCamera.orthographicSize;
            mapCamera.orthographicSize = Mathf.Lerp(currentZoom, maxZoom, Time.deltaTime * 2f); 
        }
    }


    public void ResetCamera()
    {
        transform.position = defaultPosition;
        mapCamera.orthographicSize = defaultZoom;
        zoomSlider.value = Mathf.InverseLerp(minZoom, maxZoom, defaultZoom);
    }
}
