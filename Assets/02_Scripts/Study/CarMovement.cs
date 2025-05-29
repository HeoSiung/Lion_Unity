using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D carRb;

    private float h;

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        // transform �̵�
        // transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // rigidbody �̵�
        carRb.linearVelocityX = h * moveSpeed; // FixedUpdate������ Time.deltaTime �� �ᵵ ��
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
