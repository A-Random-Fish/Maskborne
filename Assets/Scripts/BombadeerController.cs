using UnityEngine;

public class BombadeerController : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController pc;
    GameObject player;
    [SerializeField] GameObject rocketProjectile;

    bool rocketLaunched = false;
    float rocketCooldown = -0.1f;
    float barrageCooldown = -0.1f;
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
        barrageCooldown -= Time.deltaTime;

        playerToMeDistance = Vector2.Distance(transform.position, player.transform.position);

        if (playerToMeDistance < 12f && !rocketLaunched && rocketCooldown < 0f)
        {
            rocketLaunched = true;
            Invoke("Attack", 1f);
        }
        else if (playerToMeDistance < 12f && barrageCooldown < 0f)
        {
            Invoke("BarrageAttack", 0.5f);
        }
    }

    void Attack()
    {
        rocketCooldown = 2f;
        Instantiate(rocketProjectile, player.transform.position, Quaternion.identity);
        rocketLaunched = false;
    }

    void BarrageAttack()
    {
        barrageCooldown = 10f;
        Instantiate(rocketProjectile, player.transform.position, Quaternion.identity);
    }
}
