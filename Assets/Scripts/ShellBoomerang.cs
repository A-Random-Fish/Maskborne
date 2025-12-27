using UnityEngine;

public class ShellBoomerang : MonoBehaviour
{
    Vector2 direction;

    float speed = 0.3f;

    bool returning;

    PlayerController pc;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }

    void FixedUpdate()
    {
        speed -= 0.01f;

        if (speed <= 0)
        {
            returning = true;
        }

        if (!returning)
        {
            transform.Translate(Vector2.up * speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, -speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            Destroy(this.gameObject);
            pc.snailAbilityOneActive = true;
        }
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
