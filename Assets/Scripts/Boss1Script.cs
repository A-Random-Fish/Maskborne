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

    void FixedUpdate()
    {
        if (Vector2.Distance (Player.transform.position, transform.position) < sightRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed);
            timer += Time.deltaTime;
        }
    }

    void Update()
    {
        if (timer >= 3)
        {
            Instantiate(minion, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
