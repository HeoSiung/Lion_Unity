using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;
    
    void Update()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }
}