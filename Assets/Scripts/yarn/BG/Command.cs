using UnityEngine;
using Yarn.Unity;

public class Command : MonoBehaviour
{
    [YarnCommand("EndOpening")]
    public void EndOpening()
    {
        FindObjectOfType<SceneLoader>()
            .LoadMeetingScene();
    }
}