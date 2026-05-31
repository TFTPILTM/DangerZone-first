using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventPopupUI : MonoBehaviour
{
    public static EventPopupUI instance;

    [Header("UI")]
    public GameObject panelRoot;
    public Text eventTitleText;
    public Text eventDescriptionText;
    public Text effectText;
    public Button confirmButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        panelRoot.SetActive(false);
    }

    void Start()
    {
        confirmButton.onClick.AddListener(Hide);
    }

    public void Show(string title, string description, string effect)
    {
        eventTitleText.text = title;
        eventDescriptionText.text = description;
        effectText.text = effect;

        panelRoot.SetActive(true);
    }

    public void Hide()
    {
        panelRoot.SetActive(false);
    }
}