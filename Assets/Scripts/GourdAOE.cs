using UnityEngine;

public class GourdAOE : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyAOE", 0.5f);
    }

    void DestroyAOE()
    {
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            MonsterHealthComponent mhc = other.gameObject.GetComponent<MonsterHealthComponent>();
            mhc.MdamageIgnoreIframes(0.1f);
        }
    }
}
