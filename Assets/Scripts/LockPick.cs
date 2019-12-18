using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
    public GameObject lockPicker;
    public GameObject lockPad;
    public SpriteRenderer sparkle;
    private Minigame mini;
    private int pickCount;
    bool stickUpDown;


    // Start is called before the first frame update
    void Start()
    {
        mini = GetComponent<Minigame>();
        stickUpDown = false;
        pickCount = 0;
        sparkle.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (mini.timerGet <= 0)
        {
            Reset();
        }
        if (Input.GetAxis(mini.yAxis) >= 0.25f && stickUpDown == false)
        {
            Debug.Log("Stick Up");
            pickCount++;
            stickUpDown = true;
            lockPicker.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -12.5f));
        }

        if (Input.GetAxis(mini.yAxis) <= -0.25f && stickUpDown == true)
        {
            Debug.Log("Stick Down");
            pickCount++;
            stickUpDown = false;
            lockPicker.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 12.5f));
        }
        if (Input.GetAxis(mini.yAxis) == 0f)
        {
            lockPicker.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if(pickCount >= 10)
        {
            sparkle.enabled = true;
            mini.finish = true;
        }
        else
        {
            sparkle.enabled = false;
        }
    }
    private void Reset()
    {
        stickUpDown = false;
        pickCount = 0;
        sparkle.enabled = false;
    }
}
