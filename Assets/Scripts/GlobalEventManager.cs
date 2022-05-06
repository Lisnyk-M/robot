using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent<int> OnEnemyKilled = new UnityEvent<int>();
    public static UnityEvent OnGroundClicked = new UnityEvent();
    public static UnityEvent<string> OnGetWeb = new UnityEvent<string>();
    public static void SendEnemyKilled(int remainingCount)
    {
        OnEnemyKilled.Invoke(remainingCount);
    }

    public static void SendClickOnGround()
    {
        OnGroundClicked.Invoke();
    }

    public static void SendTextOnGetWeb(string str)
    {
        OnGetWeb.Invoke(str);
    }
}
