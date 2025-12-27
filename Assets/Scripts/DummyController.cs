using UnityEngine;

public class DummyController : MonoBehaviour
{
    [SerializeField] int hp = 10;
    float Invulnerability = -0.1f;

    PlayerController pc;
    [SerializeField] GameObject Hitbox;


    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        Invulnerability -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Hitbox.CompareTag("PlayerDmg") && Invulnerability < 0f)
        {
            hp -= pc.playerCurrentDmg;
            Debug.Log("Hit");
            Invulnerability = 0.5f;
        }
    }
}
