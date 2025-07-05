using UnityEngine;

public interface IItemObject
{
    ItemManager Inventory { get; set; } // 프로퍼티
    GameObject Obj { get; set; }
    string ItemName { get; set; }   
    Sprite Icon { get; set; }

    void Get();
    void Use();
}
