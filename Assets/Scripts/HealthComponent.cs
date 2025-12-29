using JetBrains.Annotations;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public float maxHealth = 10;
    [SerializeField] public float health;

    PlayerController pc;

    public float iFrames;

    void Start()
    {
        maxHealth = 10 + StaticData.healthIncrease;
        health = maxHealth;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {

        iFrames -= Time.deltaTime;
    }

    public void Damage(int damage)
    {
        if (!pc.invulnerable && iFrames <= 0f)
        {
            iFrames = 1f;
            Debug.Log("Hit");
            health -= damage;
        }
        if (health <= 0)
        {
            Invoke("Death", 0.25f);
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
