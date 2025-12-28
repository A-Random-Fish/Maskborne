using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    TextMeshProUGUI introText;

    [SerializeField] AudioSource ping;

    void Ping()
    {
        ping.Play();
    }

    void Start()
    {
        introText = this.gameObject.GetComponent<TextMeshProUGUI>();
        Invoke("Text1", 5f);
    }

    void Text1()
    {
        Ping();
        introText.text = "SOULS are indicated by the icon in the bottom right of your screen.";
        Invoke("Text2", 5f);
    }

    void Text2()
    {
        Ping();
        introText.text = "To gain SOULS you must kill MONSTERS - with harder MONSTERS dropping more SOULS";
        Invoke("Text3", 5f);
    }

    void Text3()
    {
        Ping();
        introText.text = "WASD to move, LMB and RMB to use abilities (shown on the left)";
        Invoke("Text4", 5f);
    }

    void Text4()
    {
        Ping();
        introText.text = "And Finally, hold down Space Bar, move your mouse over a MASK that appears, and release the space bar to swap out your MASK";
        Invoke("Text5", 8f);
    }

    void Text5()
    {
        Ping();
        introText.text = "Each MASK provides a different moveset, specialising against different types of enemies";
        Invoke("Text6", 6f);
    }

    void Text6()
    {
        Ping();
        introText.text = "Now go and find some MONSTERS and collect those SOULS!";
        Invoke("EndText", 5f);
    }

    void EndText()
    {
        Ping();
        introText.text = "";
    }

    public void RiftText()
    {
        Ping();
        introText.text = "Congrats on completing the Tutorial! Now, off to the mask shop you go!";
        Invoke("LoadMaskShop", 5f);
    }

    void LoadMaskShop()
    {
        SceneManager.LoadScene(2);
    }
}
