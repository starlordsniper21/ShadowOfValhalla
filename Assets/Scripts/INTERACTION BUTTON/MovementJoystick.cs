using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Animator animator;
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.GetComponent<RectTransform>(), eventData.position, null, out localPos);
        joystick.transform.localPosition = localPos;
        joystickBG.transform.position = eventData.position;
        joystickVec = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.GetComponent<RectTransform>(), eventData.position, null, out localPos);
        joystickVec = (localPos - Vector2.zero).normalized;

        float joystickDist = Vector2.Distance(localPos, Vector2.zero);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.localPosition = localPos;
        }
        else
        {
            joystick.transform.localPosition = Vector2.ClampMagnitude(joystickVec * joystickRadius, joystickRadius);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickVec = Vector2.zero;
        joystick.transform.localPosition = Vector2.zero;
        joystickBG.transform.position = joystickOriginalPos;
    }
}
