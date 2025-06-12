using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed;

    public bool isStop;
    public bool isRotating;

    void Start()
    {
        rotSpeed = 0f;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed); // Z축 기준으로 회전하는 기능

        // 마우스 왼쪽 버튼을 눌렀을 때 -> 1번 실행
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
            isRotating = true; // 룰렛이 도는 중
        }

        // 키보드 스페이스 버튼을 눌렀을 때 -> 1번 실행
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isRotating) // 만약 돌고 있다면
                isStop = true; // 감속 시작
        }
            
        if (isStop) // isStop == true || if (!isStop) // isStop == false
        {
            rotSpeed *= 0.98f; // 현재 속도에서 특정 값만큼 줄이는 기능

            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isRotating = false;
                isStop = false;
            }
        }
    }
}