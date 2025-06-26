using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] turretPrefabs;

    private void OnMouseDown()
    {
        Instantiate(turretPrefabs[0], transform.position, Quaternion.identity);
    }
}
