using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Animator anim;
    [SerializeField] private GameObject bot;
    private UpdatingValue updatingLazy;
    private float angle;
    [SerializeField] private float speed;
    [SerializeField] private float rotationAxisSpeed;
    private float step;
    private float deltaAngle;
    private Vector3 mousePos;
    private Vector3 botPos;
    private bool FirstRunning = false;
    private float distanceToTarget;
    private float countSteps;
    RunMethodJ<Vector3> rm;
    RunMethod cb, run;
    RunMethodV runV;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        GlobalEventManager.OnGroundClicked.AddListener(Test);
    }

    void Test()
    {
        Debug.Log("Robot is sending event");
    }
    void Start()
    {
        GameObject bot = GetComponent<GameObject>();
        updatingLazy = new UpdatingValue();
        // rm = new RunMethodJ<Vector3>(Move);
        //rm(Vector3.left);
        cb = Move_2;
        run = hh;
        runV = Move_3;
    }

    void hh()
    {
        anim.SetBool("Run", true);
        distanceToTarget = Vector3.Distance(mousePos, botPos);
        countSteps = distanceToTarget / step;
        deltaAngle = angle / countSteps;

        if (distanceToTarget > 50.0f)
        {
            rotationAxisSpeed = 12.0f;
        }

        if (!FirstRunning)
        {
            Move_2();
            FirstRunning = true;
            Debug.Log("hh");
        }
    }

    private void Move_3(Vector3 v)
    {
        Debug.Log($"RunV: {v}");
    }
    private void Move_2()
    {
        botPos = bot.transform.position;
        Vector3 targetDir = mousePos - botPos;
        Vector3 botForward = bot.transform.forward;
        step = speed * Time.deltaTime;
        bot.transform.position = Vector3.MoveTowards(botPos, mousePos, step);
        angle = Vector3.SignedAngle(targetDir, botForward, Vector3.up);

        bot.transform.Rotate(0, -deltaAngle * rotationAxisSpeed, 0);

        //if (Vector3.Distance(mousePos, botPos) > 20)
        //{
        //    GlobalEventManager.SendEnemyKilled(34);
        //}
    }

    private void FixedUpdate()
    {
        Debug.DrawLine(botPos, mousePos, Color.red);
    }
    void Update()
    {
        mousePos = MouseHitting.mouseHit;
        updatingLazy.CheckingValue(mousePos.x, 0.001f, run);
        updatingLazy.CheckingValueV(mousePos.x, 0.001f, delegate { runV(Vector3.left); }) ;
        updatingLazy.CheckingValue(botPos.x, 0.001f, cb);

        if (Vector3.Distance(mousePos, botPos) < 0.2f)
        {
            anim.SetBool("Run", false);
        }
    }
}
