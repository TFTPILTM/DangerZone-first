using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

public class ClickContinue : MonoBehaviour
{
    public LineView lineView;
    void Start()
    {
        Debug.Log("ClickContinue alive");
        if (lineView == null)
        {
            Debug.LogError("LineView reference not set on ClickContinue script.");
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lineView.UserRequestedViewAdvancement();
        }
    }
}