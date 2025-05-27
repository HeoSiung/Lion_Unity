using UnityEngine;

public class Material_LoopMap : MonoBehaviour
{
    private MeshRenderer renderer;

    public float offsetSpeed = 0.1f;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector2 offset = Vector2.right * offsetSpeed * Time.deltaTime;
        renderer.material.SetTextureOffset("_MainTex", renderer.material.mainTextureOffset + offset);
    }
}
