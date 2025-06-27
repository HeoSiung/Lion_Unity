using System;
using System.Collections;
using UnityEngine;

public class KnightController_Keyboard : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 20f;
    [SerializeField] private float slidePower = 50f;

    private float atkDamage = 3f;

    private bool isGround; // 애니메이터의 isGround와는 별개
    private bool isAttack;
    private bool isCombo;
    private bool isCrouch; // 수그림 여부
    private bool isRun;

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
    }

    void Update() // 일반적인 작업
    {
        InputKeyboard();
        Jump();
        Crouch();
        Attack();
        Slide();
    }

    void FixedUpdate() // 물리적인 작업
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log($"{atkDamage}로 공격");
        }
    }

    void InputKeyboard()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputDir = new Vector3(h, v, 0);

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

        SetAnimation();
    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            isRun = true;
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1); // 좌우 회전 기능

            knightRb.linearVelocity = inputDir * moveSpeed;
        }
        else
            isRun = false;
    }

    void Slide()
    {
        if (isRun == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                animator.SetTrigger("Slide");
                knightRb.AddForceX(slidePower * inputDir.x, ForceMode2D.Impulse);
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isCrouch", true);
            moveSpeed = 2f;
            isCrouch = true;
        }
        else
        {
            animator.SetBool("isCrouch", false);
            moveSpeed = 5f;
            isCrouch = false;
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))    // 무지성 연타가 안 되게 if문으로 isAttack 거르는 기본 공격 기능 + 공격 중에 한 번 더 누르면 isCombo를 true로 바꿈
        {
            if (!isAttack)
            {
                isAttack = true;
                atkDamage = 3f;
                animator.SetTrigger("Attack");
            }
            else
                isCombo = true;
        }
    }

    public void WaitCombo()     // 이 이벤트 전까지 공격키를 한 번 더 누르면 isCombo가 true가 되고 그걸 캐치함
    {
        if (isCombo)
        {
            atkDamage = 5f;
            animator.SetBool("isCombo", true);
        }
        else
        {
            isAttack = false;
            animator.SetBool("isCombo", false);
        }
    }

    public void EndCombo()      // 다시 공격이 가능하게 다 false로 바꿈
    {
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
    }

    void SetAnimation()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            animator.SetBool("isRun", true);
        }
        else if (inputDir.x == 0)
            animator.SetBool("isRun", false);
    }
}