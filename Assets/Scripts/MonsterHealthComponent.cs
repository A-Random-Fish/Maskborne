using UnityEngine;

public class MonsterHealthComponent : MonoBehaviour
{ // I have no clue how any of this is supposed to work but it kinda does?
    PlayerController pc;
    public HealthComponent playerHealth;

    [SerializeField] int damage;
    float mHealth;
    [SerializeField] int maxMHealth = 10;

    float iFrames;

    [SerializeField] int soulCount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        playerHealth = GameObject.Find("Player").GetComponent<HealthComponent>();
        mHealth = maxMHealth;
    }

    void Update()
    {
        iFrames -= Time.deltaTime;
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

    public void Mdamage(float mDamage)
    {
        if (iFrames <= 0f)
        {
            iFrames = 0.5f;
            Debug.Log("Enemy hit");
            mHealth -= mDamage;
        }

        if (mHealth <= 0)
        {
            Invoke("Death", 0.25f);
        }
    }
    public void MdamageIgnoreIframes(float mDamage)
    {
        Debug.Log("Enemy hit");
        mHealth -= mDamage;
        if (mHealth <= 0)
        {
            Invoke("Death", 0.25f);
        }
    }

    void Death()
    {
        for (int i = 0; i < soulCount; i++)
        {
            Instantiate(Resources.Load("Soul") as GameObject, new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
        }

        if (gameObject.layer == 9)
        {
            Instantiate(Resources.Load("RiftKey") as GameObject, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
