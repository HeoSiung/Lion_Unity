using UnityEngine;

public interface IItem
{
    GameObject Obj { get; set; } // Inventory에 GameObject 타입이 필요해서 추가

    void Get(); // 모든 아이템은 획득이 가능해야한다
}
