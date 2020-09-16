using UnityEngine;

public class CositaBDetection:MonoBehaviour
{

    float timer = 0;
    float timeToScore = 1;
    bool isTouching;

    private void Update()
    {
        if (GameManager.Instance.GameState == EGameState.ONGOING)
        {
            if (isTouching)
            {
                timer += Time.deltaTime;
                if (timer > timeToScore)
                {
                    GameManager.Instance.ScoreAdd(1);
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Palito"))
        {
            isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Palito"))
        {
            isTouching = false;
            timer = 0;
        }
    }
}
