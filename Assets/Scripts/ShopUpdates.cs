using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soulsText;
    
    public int healthSoulsCost;
    public int damageSoulsCost;
    public int cooldownSoulsCost;

    void Update()
    {
        soulsText.text = StaticData.souls.ToString();
    }

    public void HealthUpgrade()
    {
        if (StaticData.souls >= healthSoulsCost)
        {
            StaticData.souls -= healthSoulsCost;
            StaticData.healthIncrease += 0.25f;
        }
    }

    public void DamageUpgrade()
    {
        if (StaticData.souls >= damageSoulsCost)
        {
            StaticData.souls -= damageSoulsCost;
            StaticData.damageIncrease += 0.25f;
        }
    }

    public void CooldownUpgrade()
    {
        if (StaticData.souls >= cooldownSoulsCost)
        {
            StaticData.souls -= cooldownSoulsCost;
            StaticData.cooldownDecrease += 0.25f;
        }
    }
}
