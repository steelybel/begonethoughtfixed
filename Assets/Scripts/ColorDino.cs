using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDino : MonoBehaviour
{
    public GameObject cursor;
    public GameObject dino;
    public Sprite dinoBlank;
    public Sprite dinoColor;
    private AudioSource sound;
    private SpriteRenderer dinoSpr;
    private Collider2D cursorBox;
    private BoxCollider2D dinoBox;
    private bool color = false;
    private Minigame mini;
    private float cursorPos = -4;
    private float cursorBound = 4;
    private float cursorSpeed = 16f;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        cursorBox = cursor.GetComponent<Collider2D>();
        dinoBox = dino.GetComponent<BoxCollider2D>();
        dinoSpr = dino.GetComponent<SpriteRenderer>();
        mini = GetComponent<Minigame>();
        color = false;
        cursorBound = 4;
        cursorPos = -4;
        cursorSpeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (mini.timerGet <= 0)
        {
            Debug.Log("Resetting: Dino");
            Reset();
        }
        if (color)
        {
            if (dinoSpr.sprite != dinoColor) sound.Play();
            mini.finish = true;
            dinoSpr.sprite = dinoColor;
        }
        else
        {
            dinoSpr.sprite = dinoBlank;
        }
        cursorPos += cursorSpeed * Time.deltaTime;
        cursor.transform.localPosition = new Vector3(cursorPos, 0.0f, 1.0f);
        if ((cursorPos >= cursorBound && cursorSpeed > 0f)||(cursorPos <= (cursorBound * -1) && cursorSpeed < 0f))
        {
            cursorSpeed *= -1;
        }
        if (Input.GetButtonDown(mini.button))
        {
            Debug.Log("Color them dinosaurs boyyyyy");
            cursorSpeed = 0;
            if (Physics2D.IsTouching(dinoBox,cursorBox))
            {
                color = true;
            }
        }
    }
    private void Reset()
    {
        color = false;
        cursorBound = 4;
        cursorPos = -4;
        cursorSpeed = 16f;
    }
}
