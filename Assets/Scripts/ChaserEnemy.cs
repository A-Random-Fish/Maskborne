using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D rb;

    [SerializeField] float sightRange;
    [SerializeField] float moveSpeed;
    bool moving;

    void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Vector2.Distance (Player.transform.position, transform.position) < sightRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed);
            moving = true;
        }
    }
}
