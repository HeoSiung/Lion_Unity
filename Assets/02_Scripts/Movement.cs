using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.W)) //앞
        //{
        //    transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S)) //뒤로
        //{
        //    transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D)) //오른쪽
        //{
        //    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.A)) //왼쪽
        //{
        //    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //}

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        Debug.Log($"현재 입력 : { dir}");

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
