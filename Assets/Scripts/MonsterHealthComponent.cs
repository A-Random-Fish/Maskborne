using UnityEngine;

public class MonsterHealthComponent : MonoBehaviour
{ // I have no clue how any of this is supposed to work but it kinda does?
    PlayerController pc;
    public HealthComponent playerHealth;

    int damage;
    int mDamage;
    int mHealth;
    int maxMHealth = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        playerHealth = GameObject.Find("Player").GetComponent<HealthComponent>();
        mHealth = maxMHealth;
    }

    private void OnColliderEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "player")
        {
            playerHealth.Damage(damage); //If the player collides with the enemy the player will have a function initiated to be dealt damage
        }
    }

    public void Mdamage(int mDamage)
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
