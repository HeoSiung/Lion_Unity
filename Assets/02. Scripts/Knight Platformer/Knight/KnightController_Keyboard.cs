using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KnightController_Keyboard : MonoBehaviour, IDamageable
{
    private Animator animator;      // 애니메이션 조작용 컴포넌트
    private Rigidbody2D knightRb;   // 물리 조작용 컴포넌트
    private Collider2D knightCol;   // 충돌 처리용 컴포넌트
    public Image hpBar;             // 체력바 UI 컴포넌트

    private Vector3 inputDir;       // 입력된 운동 방향
    [SerializeField] private float moveSpeed = 7f;      // 유니티 설정 가능한 이동속도
    [SerializeField] private float jumpPower = 20f;     // 유니티 설정 가능한 점프력

    [SerializeField] public float hp = 100f;         // 최대 체력
    [SerializeField] public float currHp;            // 현재 체력

    [SerializeField] private float atkDamage = 3f;   // 공격력

    private bool isGround;          // 
    private bool isAttack;          // 
    private bool isCombo;           // 
    private bool isCrouch;          // 
    private bool isRun;             // 
    private bool isLadder;          // 전부 상태 표시 bool값

    void Start()    // 게임이 시작될 때
    {
        animator = GetComponent<Animator>();    // 애니메이터를 연결
        knightRb = GetComponent<Rigidbody2D>(); // 리지드바디를 연결

        currHp = hp;                    // 최대체력을 현재 체력에 적용
        hpBar.fillAmount = currHp / hp; // 체력바를 최대체력분에 현재체력만큼 체움 (업데이트에 넣는게 낫지 않나?)
    }

    void Update()   // 매 프레임마다
    {
        InputKeyboard();    // 
        Jump();             // 
        Crouch();           // 
        Attack();           // 각 함수를 실행
    }

    void FixedUpdate()      // 물리업데이트
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)      // 내가 다른 오브젝트와 닿았을 때
    {
        if (other.gameObject.CompareTag("Ground"))  // 만약 그것의 태그가 "Ground" 였을 때
        {
            animator.SetBool("isGround", true);     // 애니메이터에 접근해 "isGround"의 bool값을 참으로 함
            isGround = true;                        // 그리고 스크립트 내 "isGround"의 bool값도 참으로 함
        }
    }

    void OnCollisionExit2D(Collision2D other)       // 내가 다른 오브젝트와 떨어졌을 때
    {
        if (other.gameObject.CompareTag("Ground"))  // 만약 그것의 태그가 "Ground" 였을 때
        {
            
            animator.SetBool("isGround", false);    // 애니메이터에 접근해 "isGround"의 bool값을 거짓으로 함
            isGround = false;                       // 그리고 스크립트 내 "isGround"의 bool값도 거짓으로 함
        }
    }

    void OnTriggerEnter2D(Collider2D other)         // 내가 다른 오브젝트의 트러거에 닿았을 때
    {
        if (other.CompareTag("Monster"))            // 만약 그것의 태그가 "Monster" 였을 때
        {
            if (other.GetComponent<IDamageable>() != null)  // 만약 그 오브젝트에 IDamageable 인터페이스를 구현 중이지 않지 않을 떄
            {
                other.GetComponent<IDamageable>().TakeDamage(atkDamage);    // 그 오브젝트의 IDamageable의 TakeDamage함수에 내 atkDamage만큼의 값을 줌
                other.GetComponent<Animator>().SetTrigger("Hit");           // 그 오브젝트의 애니메이터에 "Hit" 트리거를 발동시킴
            }
        }

        if (other.CompareTag("Ladder")) // 만약 그것의 태그가 "Ladder" 였을 때
        {
            isLadder = true;            // isLadder라는 bool값을 참으로 함
        }
    }

    void OnTriggerExit2D(Collider2D other)  // 다른 오브젝트와 트러거가 떨어졌을 때
    {
        if (other.CompareTag("Ladder"))     // 만약 그것의 태그가 "Ladder" 였을 때
        {
            isLadder = false;               // isLadder라는 bool값을 거짓으로 함
        }
    }

    void Move()
    {
        if (inputDir.x != 0)    // 입력된 이동 방향의 x축 위치값이 0이 아닐 때
        {
            // x축 이동 값이 0보다 큰가? 참이면 x축 크기 값을 1, 거짓이면 -1 (뒤집음)
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
            // 오브젝트 변형.크기 = 새로운 3차원 값(scaleX, 1, 1);
            
            animator.SetBool("isRun", true);    // 애니메이터.Bool값 변형("isRun"을 참으로);
            knightRb.linearVelocityX = inputDir.x * moveSpeed;  
            
        }
        else                                    // x축 위치값이 0면
            animator.SetBool("isRun", false);   // 애니메이터.Bool값 변형("isRun"을 거짓으로);

        if (isLadder && inputDir.y != 0)        // 만약 isLadder 가침이고 y축 이동 값이 0이 아니라면
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed;
            // 이 오브젝트의 rigidbody.속도 = x축 운동값 * 이동속도; 
        }
    }

    void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");   // float 타입의 h 변수의 값은 키보드 입력 프리셋의 생 수평값
        float v = Input.GetAxisRaw("Vertical");     // float 타입의 v 변수의 값은 키보드 입력 프리셋의 생 수직값
        inputDir = new Vector3(h, v, 0);            // 이동 값 변수의 값은 새로운 3차원 값(h, v, 0); 
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)        // 만약 스페이스 바를 눌렀고 isGround가 참이면
        {
            animator.SetTrigger("Jump");                        // 애니메이터에 "Jump" 트리거 활성화
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse); // 이 오브젝트의 rigidbody에 y축 힘을 가함(점프력만큼, 2D 형태로 순각적인)
        }
    }

    void Crouch()
    {
        if (Input.GetKey(KeyCode.S))            // 만약 S 키를 눌렀다면
        {
            animator.SetBool("isCrouch", true); // 애니메이터에 isCrouch bool값을 참으로 함
            moveSpeed = 5f;                     // 이동속도를 5로 함
            isCrouch = true;                    // 스크립트의 isCrouch bool값을 참으로 함
        }
        else                                        // 아니라면
        {
            animator.SetBool("isCrouch", false);    // 애니메이터에 isCrouch bool값을 거짓으로 함
            moveSpeed = 7f;                         // 이동속도를 7로 함
            isCrouch = false;                       // 스크립트의 isCrouch bool값을 거짓으로 함
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))    // 만약 좌측 쉬프트 키를 눌렀다면
        {
            if (!isAttack)                          // 만약 isAttack bool값이 거짓일 때
            {
                isAttack = true;                    // 스크립트의 isAttack bool값을 참으로 함
                atkDamage = 3f;                     // 공격력을 3으로 함
                animator.SetTrigger("Attack");      // 애니메이터의 "Attack" 트리거 활성화
            }
            else                                    // 아니라면
                isCombo = true;                     // isCombo bool값을 참으로 함
        }
    }

    public void WaitCombo()                     // 애니메이터의 WaitCombo()가 활성화되면
    {
        if (isCombo)                            // 만약 isCombo bool값이 참이라면
        {
            atkDamage = 5f;                     // 공격력을 5로 함
            animator.SetBool("isCombo", true);  // 애니메이터에 isCombo bool값을 참으로 함
        }
        else                                    // 아니라면
        {
            isAttack = false;                   // 스크립트의 isAttack bool값을 거짓으로 함
            animator.SetBool("isCombo", false); // 애니메이터에 isCombo bool값을 거짓으로 함
        }
    }

    public void EndCombo()                      // 애니메이터의 EndCombo()가 활성화되면
    {
        isAttack = false;                       // 스크립트의 isAttack bool값을 거짓으로 함
        isCombo = false;                        // 스크립트의 isCombo bool값을 거짓으로 함
        animator.SetBool("isCombo", false);     // 애니메이터에 isCombo bool값을 거짓으로 함
    }

    public void TakeDamage(float damage)    // 입력받은 damage값을 넣고 실행
    {
        currHp -= damage;                   // 현재 체력에서 damage만큼 뺌

        hpBar.fillAmount = currHp/hp;       // 체력바를 최대체력분에 현재체력만큼 체움 (업데이트에 넣는게 낫지 않나?)

        if (currHp <= 0f)                   // 만약 현재 체력이 0보다 작거나 같아지면
            Death();                        // Death 함수 실행
    }

    public void Death()
    {
        animator.SetTrigger("Death");   // 애니메이터에 Death 트리거 실행
        knightCol.enabled = false;      // 이 오브젝트의 콜라이더를 끔
        knightRb.gravityScale = 0f;     // 이 오브젝트의 rigidbody의 중력값을 0으로 함
    }
}