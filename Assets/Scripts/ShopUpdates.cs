using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soulsText;

    [Header("Shop Pricing and Upgrades")]
    [SerializeField] TextMeshProUGUI healthAmount;
    [SerializeField] TextMeshProUGUI healthCost;
    [SerializeField] TextMeshProUGUI damageAmount;
    [SerializeField] TextMeshProUGUI damageCost;
    [SerializeField] TextMeshProUGUI cooldownAmount;
    [SerializeField] TextMeshProUGUI cooldownCost;

    void Update()
    {
        soulsText.text = StaticData.souls.ToString();

        StaticData.healthSoulsCost = 10 + StaticData.healthIncrease * 20;
        StaticData.damageSoulsCost = 10 + StaticData.damageIncrease * 12;
        StaticData.cooldownSoulsCost = 10 + StaticData.cooldownDecrease;

        healthAmount.text = (10 + StaticData.healthIncrease).ToString() + " -> " + (10 + 0.25f + StaticData.healthIncrease).ToString();
        healthCost.text = "Cost: " + StaticData.healthSoulsCost.ToString() + " Souls";
        damageAmount.text = (1 + StaticData.damageIncrease).ToString() + " -> " + (1.25f + StaticData.damageIncrease).ToString();
        damageCost.text = "Cost: " + StaticData.damageSoulsCost.ToString() + " Souls";
        cooldownAmount.text = (100 - StaticData.cooldownDecrease).ToString() + "% -> " + (95 - StaticData.cooldownDecrease).ToString() + "% Cooldown Length";
        cooldownCost.text = "Cost: " + StaticData.cooldownSoulsCost.ToString() + " Souls";
    }

    public void HealthUpgrade()
    {
        if (StaticData.souls >= StaticData.healthSoulsCost)
        {
            StaticData.souls -= StaticData.healthSoulsCost;
            StaticData.healthIncrease += 0.25f;
        }
    }

    public void DamageUpgrade()
    {
        if (StaticData.souls >= StaticData.damageSoulsCost)
        {
            StaticData.souls -= StaticData.damageSoulsCost;
            StaticData.damageIncrease += 0.25f;
        }
    }

    public void CooldownUpgrade()
    {
        if (StaticData.souls >= StaticData.cooldownSoulsCost)
        {
            StaticData.souls -= StaticData.cooldownSoulsCost;
            StaticData.cooldownDecrease += 5;
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene(3);
    }
}
