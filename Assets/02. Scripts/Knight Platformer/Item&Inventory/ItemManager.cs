using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject inventoryUI; // 인벤토리 UI
    public Button inventoryButton; // 인벤토리 버튼

    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform slotGroup;
    public Slot[] slots;

    public void Start()
    {
        // 자신과 자식 중에서 Slot Component가 있는 대상을 모두 가져오는 기능
        slots = slotGroup.GetComponentsInChildren<Slot>(true);

        // 인벤토리 버튼을 눌렀을 때 OnInventory 함수 실행
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void OnInventory()
    {
        // activeSelf : 현재 Active 상태
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void DropItem(Vector3 dropPos)
    {
        // 랜덤 아이템 설정
        var randomIndex = Random.Range(0, items.Length);

        // 아이템 생성
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        // 랜덤한 방향으로 힘을 가하는 기능
        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        // 랜덤한 회전으로 힘을 가하는 기능
        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        // 인벤토리에 넣는 기능, 모든 슬롯 중에 빈 슬로을 찾아 AddItem
        foreach (var slot in slots) // 모든 슬롯에 대해
        {
            if(slot.isEmpty)        // 슬롯이 비어있을 경우
            {
                slot.AddItem(item); // 해당 슬롯에 아이템 추가
                break;              // 브릭 안 하면 모든 빈칸에 넣어버림
            }
        }
    }
}