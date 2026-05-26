using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public GameObject MorningPanel;
    public GameObject NoonPanel;

    void Start()
    {
        MorningPanel.SetActive(true);
        NoonPanel.SetActive(false);
    }
    void Update()
    {
        if (EventManager.instance.eventNumber == 2)
        {
            MorningPanel.SetActive(false);
            NoonPanel.SetActive(true);
        }
            
        if(EventManager.instance.eventNumber == 4||EventManager.instance.isSleeping)
        {
            SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
            sceneLoader.LoadMeetingScene();
        }
    }
}
