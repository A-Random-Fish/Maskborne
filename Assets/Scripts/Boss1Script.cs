using UnityEngine;

public class Boss1Script : MonoBehaviour
{
    GameObject Player;
    Rigidbody2D rb;

    [SerializeField] float sightRange;
    [SerializeField] float moveSpeed;

    float timer;

    [SerializeField] GameObject minion;

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
            timer += Time.deltaTime;
        }

        if (timer >= 2)
        {
            Instantiate(minion, transform.position, Quaternion.identity);
            timer = 0;
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
