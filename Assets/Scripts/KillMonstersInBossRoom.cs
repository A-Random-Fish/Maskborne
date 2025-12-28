using UnityEngine;

public class KillMonstersInBossRoom : MonoBehaviour
{
    void Start()
    {
        Invoke("RemoveKillZone", 3f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("monster") && other.gameObject.layer != 9)
        {
            Destroy(other.gameObject);
        }
    }

    void RemoveKillZone()
    {
        Destroy(gameObject);
    }
}
