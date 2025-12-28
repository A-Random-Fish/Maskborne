using UnityEngine;

public class CollectableItemMoveTowards : MonoBehaviour
{

    [SerializeField] string CollectableType;

    float speed;
    Transform targetLoc;

    void FixedUpdate()
    {
        targetLoc = GameObject.Find("Player").transform;
        transform.position = Vector2.MoveTowards(transform.position, targetLoc.position, speed);
        if (Vector2.Distance(targetLoc.position, transform.position) < 5f)
            speed += 0.002f;
        else
            speed = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            StaticData.souls += 1;
            Destroy(this.gameObject);
        }
    }
}
