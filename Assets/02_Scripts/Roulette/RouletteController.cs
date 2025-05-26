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
        transform.Rotate(Vector3.forward * rotSpeed); // Z�� �������� ȸ���ϴ� ���

        // ���콺 ���� ��ư�� ������ �� ȸ���ϴ� ���
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = -8f;
        }

        // �����̽��ٸ� ������ �� ���ߴ� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }

        if (isStop == true)
        {
            //rotSpeed = rotSpeed * 0.98f;
            rotSpeed *= 0.992f; // ���� �ӵ����� Ư�� ����ŭ ���� ���̴� ���

            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }
        
    }

}