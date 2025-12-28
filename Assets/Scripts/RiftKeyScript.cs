using UnityEngine;

public class RiftKeyScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            RiftScript rs = GameObject.Find("Rift").GetComponent<RiftScript>();
            rs.keyCollected = true;
            Destroy(gameObject);
        }
    }
}
