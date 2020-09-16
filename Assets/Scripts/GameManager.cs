using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public enum EGameState {ONGOING, PAUSED,}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public EGameState GameState = EGameState.PAUSED;

    public TextMeshProUGUI currentScoretxt;
    public TextMeshProUGUI hiScoretxt;
    public GameObject blackOverlay;
    public GameObject startButton;
    public GameObject endButton;
    public GameObject quitButton;

    int score;
    int hiScore = -1;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        hiScore = PlayerPrefs.GetInt("HighScore");
        UpdateScore();
    }

    public void ScoreAdd(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void UpdateScore()
    {
        currentScoretxt.SetText(score.ToString());
        Debug.Log(hiScore.ToString());
        if (score > hiScore)
        {   
            Debug.Log("Score is higher");
            hiScore = score;
        }

        hiScoretxt.SetText(hiScore.ToString());
    }

    public void BeginGame()
    {
        blackOverlay.SetActive(false);
        GameState = EGameState.ONGOING;
    }

    public void EndGame()
    {
        blackOverlay.SetActive(true);
        GameState = EGameState.PAUSED;
        PlayerPrefs.SetInt("HighScore", hiScore);
        startButton.SetActive(false);
        endButton.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
