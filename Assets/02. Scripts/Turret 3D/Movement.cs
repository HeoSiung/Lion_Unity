using UnityEngine;
 
 public class Movement : MonoBehaviour
 {
     public float moveSpeed = 5f;

     public static int coinCount = 0;
     
     void Update()
     {
         float h = Input.GetAxis("Horizontal");
         float v = Input.GetAxis("Vertical");

         Vector3 dir = new Vector3(h, 0, v);
         
         Vector3 normalDir = dir.normalized;
         
         transform.position += normalDir * moveSpeed * Time.deltaTime;

         transform.LookAt(transform.position + normalDir);
     }
 }