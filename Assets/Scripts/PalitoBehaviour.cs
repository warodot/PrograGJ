using UnityEngine;

public class PalitoBehaviour:MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {

        if (GameManager.Instance.GameState == EGameState.ONGOING)
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            gameObject.transform.position = pz;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ExitGame();
        }
    }


}
