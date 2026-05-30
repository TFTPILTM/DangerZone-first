using UnityEngine;
using Yarn.Unity;

public class MeetingManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public InMemoryVariableStorage variableStorage;

    void Start()
    {
        // 传递属性给 Yarn
        variableStorage.SetValue(
            "$bloodSugar",
            PlayerStatus.instance.bloodSugar);

        variableStorage.SetValue(
            "$pressure",
            PlayerStatus.instance.pressure);

        variableStorage.SetValue(
            "$fatigue",
            PlayerStatus.instance.fatigue);

        variableStorage.SetValue(
            "$mental",
            PlayerStatus.instance.mental);

        // 开始对话
        dialogueRunner.StartDialogue("Start");
    }
}