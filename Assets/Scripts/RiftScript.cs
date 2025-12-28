using Unity.Cinemachine;
using UnityEngine;

public class RiftScript : MonoBehaviour
{
    [SerializeField] public bool keyCollected;

    Animator anim;
    GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (keyCollected)
        {
            anim.SetBool("Opened", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player") && keyCollected)
        {
            Destroy(player);
        }
    }
}
