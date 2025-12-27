using UnityEngine;

public class ClawArcScript : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ResetAnim()
    {
        anim.SetBool("Active", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            MonsterHealthComponent mhc = other.gameObject.GetComponent<MonsterHealthComponent>();
            mhc.Mdamage(1);
        }
    }
}
