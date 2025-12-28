using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soulsText;

    void Update()
    {
        soulsText.text = StaticData.souls.ToString();
    }
}
