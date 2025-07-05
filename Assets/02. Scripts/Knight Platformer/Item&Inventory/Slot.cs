using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private IItemObject item;   // 슬롯에 들어올 아이템
    public Image itemImage;      // 먹은 아이템의 이미지가 들어갈 위치
    public Button slotButton;   // 아이템을 Use()하시 위한 버튼

    public bool isEmpty = true;

    private void Awake()
    {
        slotButton.onClick.AddListener(UseItem);
    }

    private void OnEnable() // 오브젝트가 on 될때마다 1번 실행
    {
        // if (isEmpty)
        // {
        //     slotButton.interactable = false;
        //     itemImage.gameObject.SetActive(false);
        // }
        // else
        // {
        //     slotButton.interactable = true;
        //     itemImage.gameObject.SetActive(true);
        // }

        // 위를 줄여 쓴 코드
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void AddItem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false;
        itemImage.sprite = newItem.Icon;
        itemImage.SetNativeSize();
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
}
