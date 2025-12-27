using UnityEngine;

public class GourdBoulder : MonoBehaviour
{
    PlayerController pc;

    Vector2 direction;

    float speed = 0.3f;

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
        transform.Translate(Vector2.up * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Gourd Smash");
        if (other.gameObject.GetComponent<MonsterHealthComponent>() != null)
            other.gameObject.GetComponent<MonsterHealthComponent>().Mdamage(1);

        if (other.gameObject != null)
            Destroy(this.gameObject);
    }
}
