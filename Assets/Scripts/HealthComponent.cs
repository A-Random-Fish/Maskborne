using JetBrains.Annotations;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] public int maxHealth = 10;
    [SerializeField] public int health;

    PlayerController pc;

    public float iFrames;

    void Start()
    {
        health = maxHealth;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {

        iFrames -= Time.deltaTime;
    }

    public void Damage(int damage)
    {
        if (iFrames <= 0f)
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
