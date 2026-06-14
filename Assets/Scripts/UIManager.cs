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
    public Text dayText;

    public Text bloodSugarChangeText;
    public Text pressureChangeText;
    public Text fatigueChangeText;
    public Text mentalChangeText;
    public Text wealthChangeText;
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
    public void ShowChange(
    int bloodSugar,
    int pressure,
    int fatigue,
    int mental,
    int wealth)
    {
        SetChangeText(bloodSugarChangeText, bloodSugar);
        SetChangeText(pressureChangeText, pressure);
        SetChangeText(fatigueChangeText, fatigue);
        SetChangeText(mentalChangeText, mental);
        SetChangeText(wealthChangeText, wealth);

        StopAllCoroutines();
        StartCoroutine(ClearChangeText());
    }

    void SetChangeText(Text text, int value)
    {
        if (value == 0)
        {
            text.text = "";
            return;
        }

        string color;

        if (text == mentalChangeText)
            color = value > 0 ? "green" : "red";
        else
            color = value > 0 ? "red" : "green";

        text.text =
            $"<color={color}>({(value > 0 ? "+" : "")}{value})</color>";
    }

    IEnumerator ClearChangeText()
    {
        yield return new WaitForSeconds(3f);

        bloodSugarChangeText.text = "";
        pressureChangeText.text = "";
        fatigueChangeText.text = "";
        mentalChangeText.text = "";
        wealthChangeText.text = "";
    }
    public void UpdateUI()
    {
        if (PlayerStatus.instance == null) return;
        dayText.text =
    "Day " + DayManager.instance.currentDay;
        bloodSugarText.text = "血糖: " + PlayerStatus.instance.bloodSugar;
        pressureText.text = "压力: " + PlayerStatus.instance.pressure;
        fatigueText.text = "疲惫: " + PlayerStatus.instance.fatigue;
        mentalText.text = "精神: " + PlayerStatus.instance.mental;
        wealthText.text = "财富: " + PlayerStatus.instance.wealth;
    }
}