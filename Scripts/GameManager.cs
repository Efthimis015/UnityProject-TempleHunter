
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public void GameOver()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAMEOVER");
            Restart();
        }
    }

       void Restart()
    {
        SceneManager.LoadScene("DeathScreen");
    }
}
