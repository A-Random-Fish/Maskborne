using UnityEngine;

public class GourdBoulder : MonoBehaviour
{
    PlayerController pc;

    Vector2 direction;

    float speed = 0.3f;

    [SerializeField] GameObject gourdAOE;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        Invoke("Despawn", 0.5f);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("monster"))
        {
            Debug.Log("Gourd Smash");
            if (other.gameObject.GetComponent<MonsterHealthComponent>() != null)
                other.gameObject.GetComponent<MonsterHealthComponent>().Mdamage(1 + StaticData.damageIncrease);
                Instantiate(gourdAOE, transform.position,Quaternion.identity);

            if (other.gameObject != null)
                Destroy(this.gameObject);
        }
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
