using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera miniWindow;
    public Animator introHead;
    public Animator introTitle;
    public SpriteRenderer m_introTitle;
    public WinLose wl;
    public bool end = false;
    public bool encounterTrigger = false;
    private PlayerManager plrMngr;
    private charController control;
    private Minigame minigame;
    public bool inMinigame;
    public float stun = 0f;
    private float coolDown;
    private float anotherTimer;
    public bool pickedUpPowerUpMini = false;
    public bool pickedUpPowerUpSlow = false;
    public bool playerWon = false;
    // Start is called before the first frame update
    void Start()
    {
        end = false;
        coolDown = 3;
        plrMngr = GetComponent<PlayerManager>();

        control = GetComponent<charController>();
        introHead.gameObject.SetActive(true);
        introTitle.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        inMinigame = (minigame != null);
        switch (inMinigame)
        {
            case false:
                if (stun <= 0f && !end) control.enabled = true;
                else control.enabled = false;
                break;
            case true:
                control.enabled = false;
                break;
            default:
                if (stun <= 0f && !end) control.enabled = true;
                else control.enabled = false;
                break;
        }
        if (stun > 0f)
        {
            stun -= Time.deltaTime;
        }
        if (minigame != null)
        {
            m_introTitle.sprite = minigame.title;
            if (!minigame.gameObject.activeSelf)
            {
                if (introHead.GetCurrentAnimatorStateInfo(0).IsName("blank"))
                {
                    introHead.Play("cantstop");
                    introTitle.Play("title");
                }
                if (introHead.GetCurrentAnimatorStateInfo(0).IsName("t"))
                {
                    minigame.gameObject.SetActive(true);
                    minigame.TimerSet();
                }
            }
            else
            {
                if (minigame.timerGet <= 0)
                {
                    if (!minigame.finish)
                    {
                        stun = 3.0f;
                        wl.Lose();
                    }
                    else
                    {
                        wl.Win();
                    }

                    minigame.gameObject.SetActive(false);
                    minigame = null;
                }
            }
            if (anotherTimer <= Time.time)
            {
                control.moveSpeed = control.startSpeed;
                anotherTimer = 0;
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PowerUpSlow")
        {
            Destroy(collision.gameObject);
            Debug.Log("picked up slow??");
            pickedUpPowerUpSlow = true;
        }
        if (collision.gameObject.tag == "PowerUpMini")
        {
            Destroy(collision.gameObject);
            Debug.Log("picked up mini??");
            pickedUpPowerUpMini = true;
        }
        if (collision.gameObject.tag == "PowerUpSpeed")
        {
            control.moveSpeed += 3;
            anotherTimer = Time.time + coolDown;
            if (control.moveSpeed > 6)
            {

                control.moveSpeed = 6;

            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Goal")
        {
            playerWon = true;
            plrMngr.Win();
        }
        if (collision.gameObject.tag == "Encounter")
        {
            bool yeahNah = (Random.value > 0.5f);
            //If the GameObject has the same tag as specified, output this message in the console
            //playermanager.players[0].A
            if (yeahNah) encounterTrigger = true;
            else encounterTrigger = false;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Encounter")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //playermanager.players[0].A
            encounterTrigger = false;
        }
    }

    public void SetMini(Minigame m)
    {
        minigame = m;
        minigame.xAxis = control.xAxis;
        minigame.yAxis = control.yAxis;
        minigame.button = control.button;
    }
}
