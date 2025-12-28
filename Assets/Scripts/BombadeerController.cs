using UnityEngine;

public class BombadeerController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController pc;
    GameObject player;
    [SerializeField] GameObject rocketProjectile;

    bool rocketLaunched = false;
    float rocketCooldown = -0.1f;
    float playerToMeDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        rocketCooldown -= Time.deltaTime;

        playerToMeDistance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(playerToMeDistance);

        if (playerToMeDistance < 10f && !rocketLaunched && rocketCooldown < 0f)
        {
            rocketLaunched = true;
            Invoke("Attack", 1f);
        }
    }

    void Attack()
    {
        rocketCooldown = 5f;
        Instantiate(rocketProjectile, player.transform.position, Quaternion.identity);
        rocketLaunched = false;
    }
}
