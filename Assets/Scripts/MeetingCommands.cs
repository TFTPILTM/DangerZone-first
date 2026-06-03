using UnityEngine;
using Yarn.Unity;

public class MeetingCommands : MonoBehaviour
{
    [YarnCommand("EndMeeting")]
    public static void EndMeeting()
    {
        DayManager.instance.NextDay();

        EventManager.instance.eventNumber = 0;
        EventManager.instance.isSleeping = false;

        FindObjectOfType<SceneLoader>().LoadGameScene();
    }
}