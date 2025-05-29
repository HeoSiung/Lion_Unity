using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D carRb;

    private float h;

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        // transform 이동
        // transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // rigidbody 이동
        carRb.linearVelocityX = h * moveSpeed; // FixedUpdate에서는 Time.deltaTime 안 써도 됨
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }
    
    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }
}
