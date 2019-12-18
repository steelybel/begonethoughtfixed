using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public Sprite win;
    public Sprite lose;
    public AudioClip wins;
    public AudioClip loses;
    private AudioSource snd;
    private SpriteRenderer spr;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        snd = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Win()
    {
        spr.sprite = win;
        snd.clip = wins;
        anim.Play("wl");
        snd.Play();
    }
    public void Lose()
    {
        spr.sprite = lose;
        snd.clip = loses;
        anim.Play("wl");
        snd.Play();
    }
}
