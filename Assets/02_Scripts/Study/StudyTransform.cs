using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float rotateSpeed = 70f;

    void Update()
    {
        // ���� �������� �̵�
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        // ���� �������� �̵�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


        float angle = transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime;
        float localX = transform.eulerAngles.x;
        float localZ = transform.eulerAngles.z;

        // ���� �������� ȸ��
        transform.rotation = Quaternion.Euler(localX, angle, localZ);

        // ���� �������� ȸ��
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); // Space.World ����

        // ���� �������� ȸ��
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        // Ư�� ��ġ �ֺ��� ȸ��
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
