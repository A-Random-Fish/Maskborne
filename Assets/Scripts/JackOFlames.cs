using UnityEngine;

public class JackOFlames : MonoBehaviour
{
    PlayerController pc;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("EndFlames", 1f);
    }

    void EndFlames()
    {
        Destroy(this.gameObject);
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
