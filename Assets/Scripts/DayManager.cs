using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager instance;

    public int currentDay = 1;

    private void Awake()
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

    public void NextDay()
    {
        currentDay++;

        Debug.Log("进入第 " + currentDay + " 天");
    }
}