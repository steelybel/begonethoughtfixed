using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Player[] players;
    public GameObject[] minigames;
    public static GameObject encIntro;
    public static AudioClip minigameWinSnd;
    public static AudioClip minigameLoseSnd;
    public Text winTxt;
    int whoWon = 0;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            foreach (Player p in players)
            {
                p.end = true;
            }
            winTxt.text = $"GAME HAS BEEN WON!";
        }
        //Freeze stun players
        if (players[0].pickedUpPowerUpSlow == true)
        {

            Debug.Log("Player1 slow manager??");
            players[1].stun = 3f;
            players[2].stun = 3f;
            players[3].stun = 3f;

            players[0].pickedUpPowerUpSlow = false;
        }

        //Bomb Play mini
        if (players[0].pickedUpPowerUpMini == true )
        {
            
            Debug.Log("Player1 slow manager??");
            players[0].inMinigame = true;
            if(!players[1].inMinigame== true)
            {
            AssignMinigame(1);
            }
            if (!players[2].inMinigame == true)
            {
                AssignMinigame(2);
            }
            if (!players[3].inMinigame == true)
            {
                AssignMinigame(3);
            }
            players[0].pickedUpPowerUpMini = false;
        }

        //Trigger encounter
        if (players[0].encounterTrigger == true)
        {
            if (!players[0].inMinigame)
            {
                AssignMinigame(0);
                players[0].encounterTrigger = false;
            }
        }


        if (players[1].pickedUpPowerUpSlow == true)
        {
            Debug.Log("Player1 slow manager??");
            players[2].stun = 3f;
            players[3].stun = 3f;
            players[0].stun = 3f;

            players[1].pickedUpPowerUpSlow = false;
        }

        if (players[1].pickedUpPowerUpMini == true)
        {
            if (!players[0].inMinigame == true)
            {
                AssignMinigame(0);
            }
            if (!players[2].inMinigame == true)
            {
                AssignMinigame(2);
            }
            if (!players[3].inMinigame == true)
            {
                AssignMinigame(3);
            }
            players[1].pickedUpPowerUpMini = false;
        }
        if (players[1].encounterTrigger == true)
        {
            if (!players[1].inMinigame)
            {
                AssignMinigame(1);
                players[1].encounterTrigger = false;
            }
        }

        if (players[2].pickedUpPowerUpSlow == true)
        {
            Debug.Log("Player1 slow manager??");
            players[2].stun = 3f;
            players[3].stun = 3f;
            players[0].stun = 3f;

            players[2].pickedUpPowerUpSlow = false;
        }

        if (players[2].pickedUpPowerUpMini == true)
        {
            if (!players[0].inMinigame == true)
            {
                AssignMinigame(0);
            }
            if (!players[1].inMinigame == true)
            {
                AssignMinigame(1);
            }
            if (!players[3].inMinigame == true)
            {
                AssignMinigame(3);
            }
            players[2].pickedUpPowerUpMini = false;
        }
        if (players[2].encounterTrigger == true)
        {
            if (!players[2].inMinigame)
            {
                AssignMinigame(2);
                players[2].encounterTrigger = false;
            }
        }


        if (players[3].pickedUpPowerUpSlow == true)
        {
            Debug.Log("Player1 slow manager??");
            players[0].stun = 3f;
            players[1].stun = 3f;
            players[2].stun = 3f;

            players[3].pickedUpPowerUpSlow = false;
        }
        if (players[3].pickedUpPowerUpMini == true)
        {
            if (!players[0].inMinigame == true)
            {
                AssignMinigame(0);
            }
            if (!players[2].inMinigame == true)
            {
                AssignMinigame(2);
            }
            if (!players[1].inMinigame == true)
            {
                AssignMinigame(1);
            }
            players[3].pickedUpPowerUpMini = false;
        }
        if (players[3].encounterTrigger == true)
        {
            if (!players[3].inMinigame)
            {
                AssignMinigame(3);
                players[3].encounterTrigger = false;
            }
        }
    }
    void AssignMinigame(int player)
    {
        int butt;
        butt = (int)Random.Range(0.0f, (float)minigames.Length);
        while (minigames[butt].activeSelf)
        {
            butt = (int)Random.Range(0.0f, (float)minigames.Length);
            Debug.Log(butt);
        }
        players[player].SetMini(minigames[butt].GetComponent<Minigame>());
        Vector3 pos = new Vector3(players[player].miniWindow.transform.position.x, players[player].miniWindow.transform.position.y, 1);
        minigames[butt].transform.position = pos;
    }
    public void Win()
    {
        gameOver = true;
    }
}
