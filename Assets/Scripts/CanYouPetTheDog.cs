using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanYouPetTheDog : MonoBehaviour
{
    public GameObject hand;
    public GameObject dog;
    public SpriteRenderer sparkle;
    private AudioSource sound;
    private Collider2D dogBox;
    private Collider2D handBox;
    private bool hasCollided = false;
    private Minigame mini;
    private int numPets = 0;
    private float handPos = 4;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        dogBox = dog.GetComponent<BoxCollider2D>();
        handBox = hand.GetComponent<BoxCollider2D>();
        sparkle.enabled = false;
        mini = GetComponent<Minigame>();
        hand.transform.localPosition = new Vector3(1.0f, 4.0f, 1.0f);
        numPets = 0;
        handPos = 4;
        hasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mini.timerGet <= 0)
        {
            Debug.Log("Resetting: Dog");
            Reset();
        }
        handPos = Mathf.Clamp(handPos, 2.25f, 4f);
        hand.transform.localPosition = new Vector3(1.0f, handPos, 1.0f);
        if (mini.finish)
        {
            sparkle.enabled = true;
        }
        else
        {
            sparkle.enabled = false;
        }
        if (Physics2D.IsTouching(dogBox, handBox) && !hasCollided)
        {
            sound.Play();
            Debug.Log("barlk bark");
            numPets++;
            hasCollided = true;
        }
        if (!Physics2D.IsTouching(dogBox, handBox))
        {
            hasCollided = false;
        }
        if (numPets >= 5)
        {
            mini.finish = true;
        }
        if (Input.GetButton(mini.button))
        {
            handPos -= 5f * Time.deltaTime;
            //numPets++;
        }
        else
        {
            handPos += 4f * Time.deltaTime;
        }
    }
    private void Reset()
    {
        numPets = 0;
        handPos = 4;
        hasCollided = false;
        hand.transform.localPosition = new Vector3(1.0f, 4.0f, 1.0f);
        sparkle.enabled = false;
    }
}
