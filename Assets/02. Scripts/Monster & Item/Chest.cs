using UnityEngine;

public class Chest : MonoBehaviour, IItem
{
    private Inventory inventory;

    public enum ChsetType { Wood, Red }
    public ChsetType chestType;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();

        Obj = gameObject;
    }

    void OnMouseDown()
    {
        Get();
    }

    public GameObject Obj { get; set; }

    public void Get()
    {
        Debug.Log($"{this.name}À» È¹µæ!");

        inventory.AddItem(this);

        gameObject.SetActive(false);
    }
}
