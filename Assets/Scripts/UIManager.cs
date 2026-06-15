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

    public static UIManager instance;

    public GameObject workPanel;
    public GameObject exercisePanel;
    public GameObject sleepPanel;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
    
        if (workPanel != null)
            workPanel.SetActive(false);

        if (exercisePanel != null)
            exercisePanel.SetActive(false);

        if (sleepPanel != null)
            sleepPanel.SetActive(false);

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
        if (PlayerStatus.instance == null)
            return;

        if (DayManager.instance != null && dayText != null)
            dayText.text = "Day " + DayManager.instance.currentDay;

        if (bloodSugarText != null)
            bloodSugarText.text = "血糖: " + PlayerStatus.instance.bloodSugar;

        if (pressureText != null)
            pressureText.text = "压力: " + PlayerStatus.instance.pressure;

        if (fatigueText != null)
            fatigueText.text = "疲惫: " + PlayerStatus.instance.fatigue;

        if (mentalText != null)
            mentalText.text = "精神: " + PlayerStatus.instance.mental;

        if (wealthText != null)
            wealthText.text = "财富: " + PlayerStatus.instance.wealth;
    }
}