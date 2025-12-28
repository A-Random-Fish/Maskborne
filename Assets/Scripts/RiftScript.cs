using UnityEngine;

public class RiftScript : MonoBehaviour
{
    public bool keyCollected;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (keyCollected)
        {
            anim.SetBool("Opened", true);
        }
    }
}
