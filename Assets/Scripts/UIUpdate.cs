using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soulsText;
    [SerializeField] TextMeshProUGUI healthText;

    HealthComponent pc;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<HealthComponent>();
    }

    void Update()
    {
        soulsText.text = StaticData.souls.ToString();
        healthText.text = pc.health.ToString();
    }
}
