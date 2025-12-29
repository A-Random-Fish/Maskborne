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
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed);
    }
}
