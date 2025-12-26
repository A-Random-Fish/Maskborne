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
}
