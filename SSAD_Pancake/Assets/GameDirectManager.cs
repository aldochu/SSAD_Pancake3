using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirectManager : MonoBehaviour
{
    // Start is called before the first frame update
    int game = StaticVariable.game;
    void Start()
    {
        
    }

    public void startGame()
    {
        if (game==1)
        {
            SceneManager.LoadScene("Game1");
        }
        else if (game==2)
        {
            SceneManager.LoadScene("Game2");
        }
        else if (game == 3)
        {
            SceneManager.LoadScene("Game3");
        }
        else if (game == 4)
        {
            SceneManager.LoadScene("Game4");
        }
        else if (game == 5)
        {
            SceneManager.LoadScene("PlayerGame");
        }
    }

    public void goToCustomGame()
    {
        SceneManager.LoadScene("PlayerGame1");
    }
    public void goBackToWorld()
    {
        SceneManager.LoadScene(StaticVariable.world);
    }

    public void GoToMakeGameScreen()
    {
        SceneManager.LoadScene("PlayerCreateGame1");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
