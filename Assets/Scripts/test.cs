using UnityEngine;
using Yarn.Unity;

public class TestDialogue : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    private bool started;

   void Start()
{
    dialogueRunner.StartDialogue("Start");
}
}