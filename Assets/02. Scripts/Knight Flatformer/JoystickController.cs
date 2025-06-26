using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler   // 3개는 원래 있는 기능을 넣은 거
{
    [SerializeField] private KnightController_Joystick_Town knightController;

    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handlerUI;

    private Vector2 startPos, currPos;

    private void Start()
    {
        backgroundUI.SetActive(false);  // 시작할 때 안 보임
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true);   // 클릭시 보임
        backgroundUI.transform.position = eventData.position;
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currPos = eventData.position;
        Vector2 dragDir = currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 100f); // 핸들러 최대 거리 변수

        handlerUI.transform.position = startPos + dragDir.normalized * maxDist; // 핸들러 최대 거리

        knightController.InputJoystick(dragDir.x, dragDir.y);   // 조이스틱 입력값 KnightController_Joystick로 전달
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knightController.InputJoystick(0,0);    // 손 땠을때 멈추는 기능

        handlerUI.transform.localPosition = Vector2.zero;    // 손 땠을때 핸들러가 중앙으로 돌아가는 기능
        backgroundUI.SetActive(false);  // 클릭 땔때 사라짐
    }
}
