using JetBrains.Annotations;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public int maxHealth = 10;
    [SerializeField] public int health;
    public int mDamage;

    PlayerController pc;
    public MonsterHealthComponent monsterHealth;

    void Start()
    {
        health = maxHealth;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        monsterHealth = GameObject.Find("Dummy").GetComponent<MonsterHealthComponent>();
    }

    private void Update()
    {
        mDamage = pc.playerCurrentDmg;
    }

    public void Damage(int damage)
    {
        Debug.Log("Hit");
        health -= damage;
        if (health <= 0)
        {
            Invoke("Death", 0.25f);
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void OnColliderEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "monster")
        {
            monsterHealth.Mdamage(mDamage); //Literally the opposite of the MHC one
        }
    }
}
