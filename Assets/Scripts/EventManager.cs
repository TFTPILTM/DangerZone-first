using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public bool isSleeping = false;
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
    public int eventNumber;
    public void Working()
    {
        eventNumber++;

        PlayerStatus.instance.bloodSugar -= 5;
        PlayerStatus.instance.pressure += 10;
        PlayerStatus.instance.mental -= 5;
        PlayerStatus.instance.fatigue += 15;
        PlayerStatus.instance.wealth += 10;

        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null) ui.UpdateUI();

        Debug.Log("Working");
    }
    public void Exercise()
    {
        eventNumber++;

        PlayerStatus.instance.bloodSugar -= 10;
        PlayerStatus.instance.fatigue += 10;
        PlayerStatus.instance.mental += 15;
        PlayerStatus.instance.pressure -= 10;

        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null) ui.UpdateUI();

        Debug.Log("Exercise");
    }

    public void Eating()
    {
        eventNumber++;

        PlayerStatus.instance.bloodSugar += 15;
        PlayerStatus.instance.fatigue -= 5;

        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null) ui.UpdateUI();

        Debug.Log("Eating");
    }

    public void Sleeping()
    {
        eventNumber++;

        PlayerStatus.instance.bloodSugar -= 5;
        PlayerStatus.instance.fatigue -= 20;
        PlayerStatus.instance.mental += 10;
        PlayerStatus.instance.pressure -= 10;

        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null) ui.UpdateUI();

        isSleeping = true;
        Debug.Log("Sleeping");
    }
}
