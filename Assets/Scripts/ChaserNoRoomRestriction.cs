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
}
