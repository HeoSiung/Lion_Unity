using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public SpawnManager spawner;

    private SpriteRenderer sRenderer;
    private Animator animator;

    [SerializeField] protected float hp = 3f;
    [SerializeField] protected float moveSpeed = 3f;

    private int dir = 1;
    private bool isMove = true; // 맞을때 멈추기
    private bool isHit = false; // 연속 클릭 금지

    public abstract void Init();

    void Start()
    {
        spawner = FindFirstObjectByType<SpawnManager>();

        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        Init();
    }

    void OnMouseDown() // 클릭하면 한대맞음
    {
        // Hit(1);  (IEnumerator 써서 못씀)
        StartCoroutine(Hit(1)); // 코루틴 호출법
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!isMove) // 맞을때 멈칫
            return;

        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            dir = -1;
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }        
    }

    IEnumerator Hit(float damage)
    {
        if (isHit) // 연속 클릭 금지
            yield break; // IEnumerator라 이거 쓴거
                         // 밑에 내용 { }로 감싸도 됨, { }로 return 감싸는 것도 됨

        isHit = true;
        isMove = false;        

        hp -= damage;

        if (hp <= 0)
        {
            animator.SetTrigger("Death");

            spawner.DropCoin(transform.position); // 코인 생성

            yield return new WaitForSeconds(3f);
            // Destroy(gameObject);
            gameObject.SetActive(false);

            yield break;
        }

        animator.SetTrigger("Hit");

        yield return new WaitForSeconds(0.65f); // ()초 만큼 기다려야 다시 맞음
        isMove = true;
        isHit = false;
    }
}