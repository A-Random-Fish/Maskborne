using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D rb;
    EnemyDetection ed;

    [SerializeField] float sightRange;
    [SerializeField] float normalSpeed;
    float moveSpeed;

    [SerializeField] GameObject crossbow;

    void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        ed = GetComponent<EnemyDetection>();

        int randInt = Random.Range(0,1);

        if (randInt == 1)
        {
            Instantiate(crossbow, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Vector2.Distance (Player.transform.position, transform.position) < sightRange && ed.playerInRoom)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Flames"))
        {
            moveSpeed = normalSpeed / 2f;
        }
        else
        {
            moveSpeed = normalSpeed;
        }
    }
}
