using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public void Work()
    {
        EventManager.instance.Working();
    }

    public void Eat()
    {
        EventManager.instance.Eating();
    }

    public void Exercise()
    {
        EventManager.instance.Exercise();
    }

    public void Sleep()
    {
        EventManager.instance.Sleeping();
    }
}