using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledText : MonoBehaviour
{
    private int killed = 0;
    private int _prev;
    private void Awake()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(EnemyKilled);
       // GlobalEventManager.OnEnemyKilled.AddListener(MouseEvent);
    }

    private void OnMouseDown()
    {
        //Debug.Log("MOUSE_DOWN");
    }

    private void EnemyKilled(int remainingEnemies)
    {
        killed++;
        GetComponent<Text>().text = "Remain: " + killed;
        Debug.Log($"Remain: {killed}");
    }

    private void MouseEvent(int m)
    {
        if (_prev != m)
        {
            //GlobalEventManager.SendEnemyKilled(m);
        }
        _prev = m;
    }
}
