using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnMouseDown()
    {
        GlobalEventManager.SendClickOnGround();
        GlobalEventManager.SendEnemyKilled(1);
    }
}
