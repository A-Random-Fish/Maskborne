using UnityEngine;

public class RocketProj : MonoBehaviour
{
    float projectileLifetime = 1.5f;
    int damage = 2;
    Animator anim;

    public HealthComponent playerHealth;
    PlayerController pc;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        playerHealth = GameObject.Find("Player").GetComponent<HealthComponent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Active", true);
    }

    private void Update()
    {
        projectileLifetime -= Time.deltaTime;

        if (projectileLifetime < 0 )
        {
            anim.SetBool("Active", false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (playerHealth.iFrames <= 0f)
                StartCoroutine(pc.Knockback(1, 100, transform));

            playerHealth.Damage(damage); //If the player collides with the enemy the player will have a function initiated to be dealt damage
        }
    }
}
