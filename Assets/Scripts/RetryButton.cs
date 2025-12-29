using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        StaticData.cooldownDecrease = 0;
        StaticData.cooldownSoulsCost = 10;
        StaticData.damageIncrease = 0;
        StaticData.damageSoulsCost = 10;
        StaticData.healthIncrease = 0;
        StaticData.healthSoulsCost = 10;
        StaticData.souls = 0;

        SceneManager.LoadScene(3);
    }
}
