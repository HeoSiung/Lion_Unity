using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet;
    
    public float rotSpeed = 30f; // 자전 속도

    public float revolutionSpeed = 100f; // 공전 속도

    public bool isRevolution = false; // 논리 타입 -> true / false

    void Update()
    {
        //  자전하는 회전하는 기능
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime, Space.Self);

        if (isRevolution == true) // 조건문 -> 만약 공전을 한다면,
        {
            // 공전하는 기능
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}