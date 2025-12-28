using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
