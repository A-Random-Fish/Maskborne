using UnityEngine;

public class CollectableItemMoveTowards : MonoBehaviour
{
    PlayerController pc;

    [SerializeField] string CollectableType;

    float speed;
    Transform targetLoc;

    void Awake()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        targetLoc = GameObject.Find("Player").transform;
        transform.position = Vector2.MoveTowards(transform.position, targetLoc.position, speed);
        speed += 0.0005f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            pc.souls += 1;
            Destroy(this.gameObject);
        }
    }
}
