using UnityEngine;
using UnityEngine.SceneManagement;

public class AntiBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
