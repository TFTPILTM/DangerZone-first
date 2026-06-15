using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public bool isSleeping = false;

    [System.Serializable]
    public class RandomEventData
    {
        public string eventName;
        public string description;

        public int bloodSugar;
        public int pressure;
        public int fatigue;
        public int mental;
    }



    public List<RandomEventData> eventList = new List<RandomEventData>();

    public int eventNumber;
  

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {


        if (eventList.Count == 0)
        {
            eventList.Add(new RandomEventData
            {
                eventName = "加班",
                description = "主管突然要求你今晚留下来加班。",
                bloodSugar = 5,
                pressure = 20,
                fatigue = 15,
                mental = -10
            });

            eventList.Add(new RandomEventData
            {
                eventName = "奶茶",
                description = "同事请你喝了一杯奶茶。",
                bloodSugar = 20,
                pressure = -5,
                fatigue = 0,
                mental = 10
            });

            eventList.Add(new RandomEventData
            {
                eventName = "散步",
                description = "下班后你出去散了会儿步。",
                bloodSugar = -5,
                pressure = -10,
                fatigue = -5,
                mental = 10
            });
        }
    }
    // 显示操作面板的协程
    IEnumerator ShowActionPanel(GameObject panel)
    {
        panel.SetActive(true);

        yield return new WaitForSeconds(3f);

        panel.SetActive(false);
    }

    public void TriggerRandomEvent()
    {
        if (eventList == null || eventList.Count == 0)
        {
            Debug.LogWarning("eventList 为空，无法触发随机事件");
            return;
        }

        int index = Random.Range(0, eventList.Count);
        RandomEventData e = eventList[index];

        PlayerStatus.instance.bloodSugar += e.bloodSugar;
        PlayerStatus.instance.pressure += e.pressure;
        PlayerStatus.instance.fatigue += e.fatigue;
        PlayerStatus.instance.mental += e.mental;

        UIManager ui = FindObjectOfType<UIManager>();

        if (ui != null)
        {
            ui.UpdateUI();

            ui.ShowChange(
                e.bloodSugar,
                e.pressure,
                e.fatigue,
                e.mental,
                0
            );
        }

        string effect = "";

        if (e.bloodSugar != 0)
        {
            string color = e.bloodSugar > 0 ? "red" : "green";

            effect += $"<color={color}>血糖 {(e.bloodSugar > 0 ? "+" : "")}{e.bloodSugar}</color>\n";
        }

        if (e.pressure != 0)
        {
            string color = e.pressure > 0 ? "red" : "green";

            effect += $"<color={color}>压力 {(e.pressure > 0 ? "+" : "")}{e.pressure}</color>\n";
        }

        if (e.fatigue != 0)
        {
            string color = e.fatigue > 0 ? "red" : "green";

            effect += $"<color={color}>疲劳 {(e.fatigue > 0 ? "+" : "")}{e.fatigue}</color>\n";
        }

        if (e.mental != 0)
        {
            string color = e.mental > 0 ? "green" : "red";

            effect += $"<color={color}>精神 {(e.mental > 0 ? "+" : "")}{e.mental}</color>\n";
        }

        if (EventPopupUI.instance != null)
        {
            EventPopupUI.instance.Show(e.eventName, e.description, effect);
        }
        else
        {
            Debug.LogWarning("找不到 EventPopupUI");
        }

        
        if (ui != null) ui.UpdateUI();

        Debug.Log("随机事件：" + e.eventName);
    }

    public void Working()
    {
        StartCoroutine(WorkingProcess());
    }

    IEnumerator WorkingProcess()
    {
        UIManager.instance.workPanel.SetActive(true);

        yield return new WaitForSeconds(2f);
        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null)
        {
            ui.UpdateUI();

            ui.ShowChange(
                -5,
                10,
                15,
                -5,
                10
            );
        }
            ui.UpdateUI();

        yield return new WaitForSeconds(1f);

        UIManager.instance.workPanel.SetActive(false);

        eventNumber++;

        PlayerStatus.instance.bloodSugar -= 5;
        PlayerStatus.instance.pressure += 10;
        PlayerStatus.instance.mental -= 5;
        PlayerStatus.instance.fatigue += 15;
        PlayerStatus.instance.wealth += 10;

        TriggerRandomEvent();

        
    }

    public void Exercise()
    {
        StartCoroutine(ExerciseProcess());
    }

    IEnumerator ExerciseProcess()
    {
        UIManager.instance.exercisePanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        UIManager ui = FindObjectOfType<UIManager>();

        if (ui != null)
        {
            ui.ShowChange(
             -10,
             -10,
             10,
             15,
             0
             );
        }
        ui.UpdateUI();

        yield return new WaitForSeconds(1f);

        UIManager.instance.exercisePanel.SetActive(false);

        eventNumber++;

        PlayerStatus.instance.bloodSugar -= 10;
        PlayerStatus.instance.fatigue += 10;
        PlayerStatus.instance.mental += 15;
        PlayerStatus.instance.pressure -= 10;

       

            TriggerRandomEvent();

      

        Debug.Log("Exercise");
    }
    //public void Eating()
    //{
    //    eventNumber++;

    //    PlayerStatus.instance.bloodSugar += 15;
    //    PlayerStatus.instance.fatigue -= 5;

    //    TriggerRandomEvent();

    //    UIManager ui = FindObjectOfType<UIManager>();
    //    if (ui != null) ui.UpdateUI();

    //    Debug.Log("Eating");
    //}
    public void Eating()
    {
        FindObjectOfType<SceneLoader>().LoadEatingScene();
    }

    public void Sleeping()
    {
        StartCoroutine(SleepingProcess());
    }

    IEnumerator SleepingProcess()
    {
        UIManager.instance.sleepPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null)
        {
            ui.ShowChange(
                    -5,
                    -10,
                    -20,
                    10,
                    0
                );
        }
        ui.UpdateUI();

        yield return new WaitForSeconds(1f);

        UIManager.instance.sleepPanel.SetActive(false);

       

        eventNumber++;

        PlayerStatus.instance.bloodSugar -= 5;
        PlayerStatus.instance.fatigue -= 20;
        PlayerStatus.instance.mental += 10;
        PlayerStatus.instance.pressure -= 10;

        isSleeping = true;

       

        

        Debug.Log("Sleeping");
    }
}