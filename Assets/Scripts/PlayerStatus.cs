using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    public int bloodSugar = 50;
    public int pressure = 50;
    public int fatigue = 50;
    public int mental = 50;
    public int wealth = 50;

    void Awake()
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
}