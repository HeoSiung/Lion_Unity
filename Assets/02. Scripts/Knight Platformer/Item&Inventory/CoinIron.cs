using UnityEngine;

public class CoinIron : MonoBehaviour, IItemObject
{
    public ItemManager Inventory { get; set; }

    public GameObject Obj { get; set; }
    public string ItemName { get; set; }
    public Sprite Icon { get; set; }

    void Start()
    {
        Inventory = FindFirstObjectByType<ItemManager>();

        Obj = this.gameObject;
        ItemName = this.gameObject.name;
        Icon = this.GetComponent<SpriteRenderer>().sprite;
    }

    // 무엇인가 충돌됐을 때 실행되는 이벤트
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Tag == Player 인지 확인하는 조건문
        {
            Get();
        }
    }

    public void Get()
    {
        gameObject.SetActive(false); // 아이템 먹은 것처럼 보여주기 위해 오브젝트 Off

        Inventory.GetItem(this); // 인벤토리에게 아이템 획득을 알리는 기능
    }

    public void Use()
    {
        Debug.Log("아이템 사용");
    }
}