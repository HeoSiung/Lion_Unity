using System;
using UnityEngine;
using UnityEngine.UI;

public class KnightController_Joystick : MonoBehaviour
{
    private bool isGround; // 애니메이터의 isGround와는 별개
    private bool isAttack;
    private bool isCombo;

    private float atkDamage;

    private Animator animator;
    private Rigidbody2D knightRb;
    [SerializeField] private Button jumpButton; // 점프 버튼 변수
    [SerializeField] private Button atkButton; // 공격 버튼 변수


    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 20f;

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();

        jumpButton.onClick.AddListener(Jump);   // 점프 버튼 누르면 클릭 이벤트 발생
        atkButton.onClick.AddListener(Attack);   // 공격 버튼 누르면 클릭 이벤트 발생
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", false);
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage}로 공격");
        }
    }

    public void InputJoystick(float x, float y) // 조이스틱 조작 입력 값, 애니메이터 파라미터에 대입
    {
        inputDir = new Vector3(x, y, 0).normalized;    // normalized로 겁나 빠른거 수정

        animator.SetFloat("JoystickX", x); //
        animator.SetFloat("JoystickY", y); // 애니메이터 파라미터

        if (inputDir.x != 0)    // 플립(x축 회전) 기능
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }

    void Move()
    {
        if (inputDir.x != 0)
            knightRb.linearVelocityX = inputDir.x * moveSpeed;
    }

    void Jump()   // 점프 애니메이션
    {
        if (isGround) // 땅에 닿아있다면
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    void Attack()   // 공격 애니메이션
    {
        animator.SetBool("isCombo", false);

        if (!isAttack)  // 기본 공격
        {
            atkDamage = 5f;
            isAttack = true;
            animator.SetTrigger("Attack");
        }
        else  // 콤보 공격
        {
            atkDamage = 6f;
            animator.SetBool("isCombo", true);
        }
    }

    public void CheckCombo()    // 콤보 공격 수행
    {
            isAttack = false;
    }
}