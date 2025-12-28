using Unity.Cinemachine;
using UnityEngine;

public class RiftScript : MonoBehaviour
{
    [SerializeField] public bool keyCollected;

    [SerializeField] bool tutorialRift;

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

            if (tutorialRift)
            {
                GameObject bossDeadText = GameObject.Find("BossDeadText");
                bossDeadText.SetActive(false);

                IntroText it = GameObject.Find("IntroText").GetComponent<IntroText>();
                it.RiftText();
            }
        }
    }
}
