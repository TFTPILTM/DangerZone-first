using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public Text bloodSugarText;
    public Text pressureText;
    public Text fatigueText;
    public Text mentalText;
    public Text wealthText;

    void Start()
    {
        StartCoroutine(InitUI());
    }

    IEnumerator InitUI()
    {
        // 等 PlayerStatus 初始化完成
        yield return null;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (PlayerStatus.instance == null) return;

        bloodSugarText.text = "血糖: " + PlayerStatus.instance.bloodSugar;
        pressureText.text = "压力: " + PlayerStatus.instance.pressure;
        fatigueText.text = "疲惫: " + PlayerStatus.instance.fatigue;
        mentalText.text = "精神: " + PlayerStatus.instance.mental;
        wealthText.text = "财富: " + PlayerStatus.instance.wealth;
    }
}