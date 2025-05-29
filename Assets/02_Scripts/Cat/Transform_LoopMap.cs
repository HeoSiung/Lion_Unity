using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float returnPosX = 11f;
    public float randomPosY;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            randomPosY = Random.Range(-8.5f, -5f);
            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}