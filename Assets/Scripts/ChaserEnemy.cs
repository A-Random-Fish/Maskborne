using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D rb;

    [SerializeField] float sightRange;
    [SerializeField] float moveSpeed;

    void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Vector2.Distance (Player.transform.position, transform.position) < sightRange)
        {
            rb.MovePosition(Player.transform.position);
        }
    }
}
