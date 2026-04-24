using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
[SerializeField] PlayerController playerController;
[SerializeField] TMP_Text timeText;
[SerializeField] GameObject gameOverText;
[SerializeField] float startTime=5f;

float timeLeft;
public bool gameOver=false;

public bool GameOver
    {
        get{return gameOver;}
        set{gameOver=value;}
    }


    void Start()
    {
        timeLeft=startTime;
    }

    void Update()
    {
        bool flowControl = DecreaseTime();
        if (!flowControl)
        {
            return;
        }

    }
    private bool DecreaseTime()
    {
        if (gameOver) return false;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }

        return true;
    }

    void PlayerGameOver()
        {
            gameOver=true;
            playerController.enabled=false;
            gameOverText.SetActive(true);
            Time.timeScale=.1f;
        }
}
