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
            leftBarRb.AddTorque(45f); // Torque는 회전 힘을 가하는 것
        }
        else
        {
            leftBarRb.AddTorque(-35f); //반대로 살살 돌아오는 것
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightBarRb.AddTorque(-45f); //반대로 회전하니 음수
        }
        else
        {
            rightBarRb.AddTorque(35f);
        }

    }

}
