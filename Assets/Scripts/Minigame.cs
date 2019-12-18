using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public string xAxis;
    public string yAxis;
    public string button;
    public Sprite title;
    private float timer;
    public float timerGet { get { return timer; } }
    public bool finish = false;
    [SerializeField]
    private float timerSet = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        TimerSet();
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > 0f) timer -= Time.deltaTime;
    }
    public void TimerSet()
    {
        Debug.Log("Timer reset!");
        finish = false;
        timer = timerSet;
    }
}
