using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Invoke("LoadShops", 5f);

            if (tutorialRift)
            {
                GameObject bossDeadText = GameObject.Find("BossDeadText");
                bossDeadText.SetActive(false);

                IntroText it = GameObject.Find("IntroText").GetComponent<IntroText>();
                it.RiftText();
            }
        }
    }

    void LoadShops()
    {
        SceneManager.LoadScene(2);
    }
}
