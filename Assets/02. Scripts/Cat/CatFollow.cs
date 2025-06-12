using UnityEngine;

public class CatFollow : MonoBehaviour
{
    public Transform cat;

    public Vector3 offset;

    void Update()
    {
        transform.position = cat.transform.position + offset;
    }
}
