using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public abstract class MonsterCore : MonoBehaviour, IDamageable
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monsterState = MonsterState.IDLE;

    public ItemManager itemManager;

    public Transform target;
    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;
    public Image hpBar;

    public float hp;
    public float currHp;

    public float speed;
    public float attackTime;
    public float atkDamage;

    protected float moveDir;
    protected float targetDist;

    protected bool isTrace;
    private bool isDead;

    protected virtual void Init(float hp, float speed, float attackTime, float atkDamage)
    {

        itemManager = FindFirstObjectByType<ItemManager>();

        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;
        this.atkDamage = atkDamage;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();

        currHp = hp;
        hpBar.fillAmount = currHp / hp;
    }

    void Update()
    {
        if (isDead)
            return;

        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }

        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(atkDamage);
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if (monsterState != newState)
            monsterState = newState;
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;
        hpBar.fillAmount = currHp / hp; // 현재체력 / 최대체력
        if (currHp <= 0f)
            Death();
    }

    public void Death()
    {
        isDead = true;
        animator.SetTrigger("Death"); // Death 애니메이션
        monsterColl.enabled = false; // 또 공격받으면 안되기 때문에 Collider Off
        monsterRb.gravityScale = 0f; // 아래로 떨어지지 않기 위해서 중력 0

        int itemCount = Random.Range(0, 3); // 0, 1, 2
        if (itemCount > 0) // 혹시나 0이 나오면 에러가 발생하기 때문에 예외처리
        {
            for (int i = 0; i < itemCount; i++) // itemCount 값으로 반복문 실행
            {
                itemManager.DropItem(transform.position); // 드롭 아이템 생성
            }
        }
    }
}