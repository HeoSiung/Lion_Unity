using UnityEngine;

public class TransformLoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float returnPosX = 15f;
    public float randomPosY;

    void Start()
    {
        randomPosY = Random.Range(-8, -3);

        transform.position = new Vector3(transform.position.x, randomPosY, 0);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            // randomPosY = Random.Range(-8f, -3.5f);
            randomPosY = Random.Range(-8, -3);

            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}