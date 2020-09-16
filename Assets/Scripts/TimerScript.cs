using TMPro;
using UnityEngine;

public class TimerScript:MonoBehaviour
{
    public TextMeshProUGUI timertext;
    public float timer;
    public float startTime;

    private void Awake()
    {
        timer = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == EGameState.ONGOING)
        {
            timer -= Time.deltaTime;
            timertext.SetText(timer.ToString("000"));

            if (timer <= 0)
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}
