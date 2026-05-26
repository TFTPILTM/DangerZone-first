using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public bool isSleeping = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int eventNumber;
    public void Walking()
    {
        eventNumber++;
        Debug.Log("Walking");
    }
    public void Exercise()
    {
        eventNumber++;
        Debug.Log("Exercise");
    }

    public void Eating()
    {
        eventNumber++;
        Debug.Log("Eating");
    }

    public void Sleeping()
    {
        eventNumber++;
        isSleeping = true;
        Debug.Log("Sleeping");
    }
}
