using UnityEngine;

public class ThornyShell : MonoBehaviour
{
    PlayerController pc;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("EndShell", 1.16f);
    }

    void EndShell()
    {
        pc.canMove = true;
        Destroy(this.gameObject);
    }
}
