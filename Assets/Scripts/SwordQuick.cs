using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordQuick : MonoBehaviour
{
    public GameObject swordGuy;
    public GameObject Enemy;
    public Animator blackScreen;
    public GameObject motion;
    public Animator exclamation;
    public Sprite[] guySpr;
    public Sprite[] enemySpr;
	public AudioClip cueSound;
	public AudioClip slashSound;
	private AudioSource sound;
    private SpriteRenderer _guy;
    private SpriteRenderer _enemy;
    private bool hitEnemy = false;
    private bool uSuck = false;
    private Minigame mini;
    private int setTimer;
    private float swingTiming = 0;


    // Start is called before the first frame update
    void Start()
    {
		sound = GetComponent<AudioSource>();
        mini = GetComponent<Minigame>();
        swordGuy.transform.localPosition = new Vector3(1.25f, 0.25f, 0.0f);
        _guy = swordGuy.GetComponent<SpriteRenderer>();
        _enemy = Enemy.GetComponent<SpriteRenderer>();
        swingTiming = Random.Range(2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitEnemy)
        {
            motion.SetActive(true);
        }
        else
        {
            motion.SetActive(false);
        }
        if (mini.timerGet > swingTiming && Input.GetButtonDown(mini.button))
        {
            if (!uSuck)
            {
                exclamation.Play("exc2");
                blackScreen.Play("slash");
                sound.clip = slashSound;
                sound.Play();
                uSuck = true;
            }
            _enemy.sprite = enemySpr[1];
            _guy.sprite = guySpr[2];
        }
        if (mini.timerGet <= swingTiming && mini.timerGet >= (swingTiming-Time.deltaTime) && !uSuck)
        {
            Debug.Log("Can swing");
            exclamation.Play("exc");
			sound.clip = cueSound;
			sound.Play();
        }
        if(mini.timerGet <= swingTiming && mini.timerGet >= (swingTiming-1) && !uSuck)
        {

            if (Input.GetButtonDown(mini.button) && !hitEnemy)
            {
                Debug.Log("You hit the enemy");
				sound.clip = slashSound;
				sound.Play();
                exclamation.Play("exc2");
                blackScreen.Play("slash");
                _guy.sprite = guySpr[1];
                _enemy.sprite = enemySpr[2];
                hitEnemy = true;
                mini.finish = true;

            }
        }
        if (mini.timerGet <= (swingTiming - 0.5f) && !hitEnemy && !uSuck)
        {
            if (!uSuck)
            {
				exclamation.Play("exc2");
                blackScreen.Play("slash");
				sound.clip = slashSound;
				sound.Play();
                uSuck = true;
            }
            _enemy.sprite = enemySpr[1];
            _guy.sprite = guySpr[2];
        }
        if (mini.timerGet <= 0)
        {
            Reset();
        }

    }
    private void Reset()
    {
        hitEnemy = false;
        uSuck = false;
        _guy.sprite = guySpr[0];
        _enemy.sprite = enemySpr[0];
        swingTiming = Random.Range(2f, 3f);
    }
}
