using UnityEngine;

public class MonsterHealthComponent : MonoBehaviour
{ // I have no clue how any of this is supposed to work but it kinda does?
    PlayerController pc;
    public HealthComponent playerHealth;

    [SerializeField] int damage;
    float mHealth;
    int maxMHealth = 10;

    float iFrames;


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
        Destroy(gameObject);
    }
}
