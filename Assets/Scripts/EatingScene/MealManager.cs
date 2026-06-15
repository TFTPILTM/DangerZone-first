using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MealManager : MonoBehaviour
{
    public static MealManager instance;

    public float gameTime = 60f;

    public Text timerText;
    public Text bloodSugarText;
    public Text pressureText;
    public Text fatigueText;
    public Text mentalText;

    int bloodSugar;
    int pressure;
    int fatigue;
    int mental;

    [Header("Result UI")]
    public GameObject resultPanel;

    public Text bloodSugarResult;
    public Text pressureResult;
    public Text fatigueResult;
    public Text mentalResult;

    public Button confirmButton;

    bool gameEnded = false;
    void Start()
    {
        resultPanel.SetActive(false);

        confirmButton.onClick.AddListener(ReturnToGame);
    }
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (gameEnded)
            return;

        gameTime -= Time.deltaTime;

        timerText.text =
            Mathf.CeilToInt(gameTime).ToString();

        if (gameTime <= 0)
        {
            gameEnded = true;
            EndMeal();
        }
    }

    public void AddFood(FoodItem food)
    {
        bloodSugar += food.bloodSugar;
        pressure += food.pressure;
        fatigue += food.fatigue;
        mental += food.mental;

        UpdateUI();

        Debug.Log("获得食物：" + food.foodName);
    }
    
    string FormatStat(string name, int value)
    {
        string color;

        if (name == "精神")
        {
            color = value >= 0 ? "green" : "red";
        }
        else
        {
            color = value <= 0 ? "green" : "red";
        }

        return $"{name}：<color={color}>{(value > 0 ? "+" : "")}{value}</color>";
    }
    void EndMeal()
    {
        Time.timeScale = 0f;

        resultPanel.SetActive(true);

        bloodSugarResult.text =
            FormatStat("血糖", bloodSugar);

        pressureResult.text =
            FormatStat("压力", pressure);

        fatigueResult.text =
            FormatStat("疲劳", fatigue);

        mentalResult.text =
            FormatStat("精神", mental);
    }
    public void ReturnToGame()
    {
        Time.timeScale = 1f;

        PlayerStatus.instance.bloodSugar += bloodSugar;
        PlayerStatus.instance.pressure += pressure;
        PlayerStatus.instance.fatigue += fatigue;
        PlayerStatus.instance.mental += mental;

        EventManager.instance.eventNumber++;

        FindObjectOfType<SceneLoader>().LoadGameScene();
    }
    public void UpdateUI()
    {
        bloodSugarText.text = "血糖：" + bloodSugar;
        pressureText.text = "压力：" + pressure;
        fatigueText.text = "疲劳：" + fatigue;
        mentalText.text = "精神：" + mental;
    }
}