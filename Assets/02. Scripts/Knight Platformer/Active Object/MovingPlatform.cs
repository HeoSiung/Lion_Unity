using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MoveType { Horizontal, Vertical }   // enum 열거형 (여러 값에 이름을 붙여 묶어두는 것), 수평과 수직 MoveType을 생성, 에디터에서 선택 가능
    public MoveType moveType;   // 어떤 값이 선택됐는지 저장하는 것, public이라 유니티 내에서 지정 가능

    public float theta;         // 각도, Mathf.Sin에 대입해서 부드러운 움직임을 주기 위해 활용
    public float power = 0.1f;  // 폭 (얼마나 강하게 흔들릴지)
    public float speed = 1f;    // 속도

    private Vector3 initPos;    // initPos 변수 내에 Vector3 기반 위치값을 저장해 놓는 것

    void Start()
    {
        initPos = transform.position;   // 시작될 때 initPos에 현재 위치를 대입함
    }

    void Update()
    {
        theta += Time.deltaTime * speed;    // theta값이 매 프레임마다 증가, Time.deltaTime으로 프레임이 달라도 일정한 수준으로 움직이게 해줌, 결과적으로 부드럽게 움직임

        if (moveType == MoveType.Horizontal)    // if와 else if로 방향에 맞춰 움직임, 
            transform.position = new Vector3(initPos.x + power * Mathf.Sin(theta), initPos.y, initPos.z);
            // 현재 오브젝트 위치 = 새 위치(처음x좌표 + 진폭 * -1 ~ 1 의 왕복값, 처음y좌표, 처음z좌표);  =>  y와 z는 유지한체 x가 왕복
        else if (moveType == MoveType.Vertical)
            transform.position = new Vector3(initPos.x, initPos.y + power * Mathf.Sin(theta), initPos.z);
            // 현재 오브젝트 위치 = 새 위치(처음x좌표, 처음y좌표 + 진폭 * -1 ~ 1 의 왕복값, 처음z좌표);  =>  x와 z는 유지한체 y가 왕복
    }

    void OnCollisionEnter2D(Collision2D other)  // 이 오브젝트가 다른 오브젝트와 닿으면
    {
        if (other.gameObject.CompareTag("Player"))  // 만약 다른 오브젝트의 태그가 Player면
        {
            other.transform.SetParent(transform);   // 자신과 다른 오브젝트를 부모-자식 관계로 만든다
        }
    }

    void OnCollisionExit2D(Collision2D other)   // 이 오브젝트와 닿은 오브젝트가 떨어지면
    {
        if (other.gameObject.CompareTag("Player"))  // 만약 다른 오브젝트의 태그가 Player면
        {
            other.transform.SetParent(null);        // 다른 오브젝트의 부모를 지움
        }
    }
}