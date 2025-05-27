using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Vector3 returnPos = new Vector3(30f, 1.5f, 0f);

    void Update()
    {
        // 배경 왼쪽으로 이동하는 기능
        // transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime; // 고정적인 델타 타임
        Debug.Log(Time.fixedDeltaTime);

        if (transform.position.x <= -30f) // 이미지의 x축 값이 -30을 넘는 순간
        {
            transform.position = returnPos; // 다시 사용하기 위해서 오른쪽 x = 30으로 초기화
        }

    }

}