using UnityEngine;

public class PinballManager : MonoBehaviour
{
    public Rigidbody2D leftBarRb;
    public Rigidbody2D rightBarRb;
    public int totalScore = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftBarRb.AddTorque(45f); // Torque�� ȸ�� ���� ���ϴ� ��
        }
        else
        {
            leftBarRb.AddTorque(-35f); //�ݴ�� ��� ���ƿ��� ��
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightBarRb.AddTorque(-45f); //�ݴ�� ȸ���ϴ� ����
        }
        else
        {
            rightBarRb.AddTorque(35f);
        }

    }

}
