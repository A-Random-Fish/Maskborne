using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject player;
    Vector2 direction;

    [SerializeField] float speed;

    void Start()
    {
        player = GameObject.Find("Player");

        direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        Invoke("Despawn", 0.75f);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("player"))
        {
            Debug.Log("Gourd Smash");
            if (other.gameObject.GetComponent<HealthComponent>() != null)
                other.gameObject.GetComponent<HealthComponent>().health -= 1;

            Destroy(this.gameObject);
                
        }
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
