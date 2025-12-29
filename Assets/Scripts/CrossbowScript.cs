using UnityEngine;

public class CrossbowScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] float sightRange;
    float timer;
    
    [SerializeField] GameObject arrow;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < sightRange && timer <= 0f)
        {
            timer = 1f;
            Instantiate(arrow, transform.position, Quaternion.identity);
        }

        timer -= Time.deltaTime;
    }
}
