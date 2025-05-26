using UnityEngine;
using UnityEngine.UI;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed;

    public bool isStop; // false

    void Start()
    {
        rotSpeed = 0f;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed); // Z축 기준으로 회전하는 기능

        // 마우스 왼쪽 버튼을 눌렀을 때 회전하는 기능
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = -8f;
        }

        // 스패이스바를 눌렀을 때 멈추는 기능
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }

        if (isStop == true)
        {
            //rotSpeed = rotSpeed * 0.98f;
            rotSpeed *= 0.992f; // 현재 속도에서 특정 값만큼 점점 줄이는 기능

            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }
        
    }

}