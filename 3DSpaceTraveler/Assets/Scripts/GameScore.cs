using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public GameObject menu;
    public Button startButton;
    public Text scoreLabel;
    public static int score;
    public static bool isStart,pause;

    void Start()
    {
        pause = false;
        score = 0;
        startButton.onClick.AddListener(delegate{
            menu.SetActive(false);
            isStart = true;
            });
    }

    
    void Update()
    {
        scoreLabel.text = "Score: " + score+"\n"+"HP: "+Player.hp;
    }
    public void Pause()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            pause = true;

        }
        else if (pause)
        {
            Time.timeScale = 1;
            pause = false;
        }
    }

}
