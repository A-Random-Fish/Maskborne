using UnityEngine;

public class ChaserNoRoomRestriction : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D rb;
    EnemyDetection ed;

    [SerializeField] float sightRange;
    [SerializeField] float moveSpeed;

    void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance (Player.transform.position, transform.position) < sightRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Flames"))
        {
            moveSpeed = moveSpeed / 2f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }
}
