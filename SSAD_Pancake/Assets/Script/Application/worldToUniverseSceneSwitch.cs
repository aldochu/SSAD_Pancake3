using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class worldToUniverseSceneSwitch : MonoBehaviour
{
    public void GoToLogOut()
    {
        StaticVariable.UserID = null;
        StaticVariable.UserProfile = null;
        SceneManager.LoadScene("Login");
    }
    public void GotoUniverseScene()
    {
		StaticVariable.lastVisited = "Universe";
		Debug.Log(StaticVariable.lastVisited);
		SceneManager.LoadScene("Universe");
    }

    public void GotoWorld1Scene()
    {
		Debug.Log("Executed?" + StaticVariable.lastVisited);
		StaticVariable.lastVisited = "World1";
		StaticVariable.world = "world1";
        SceneManager.LoadScene("World1");
    }

    public void GotoWorld2Scene()
    {
		StaticVariable.lastVisited = "World2";
		StaticVariable.world = "world2";
        SceneManager.LoadScene("World2");
    }

    public void GotoGame1Easy()
    {
		StaticVariable.game = 1;
        StaticVariable.difficulty = "easy";
        StaticVariable.chapter = "chap1";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame1Medium()
    {
		StaticVariable.game = 1;
        StaticVariable.difficulty = "medium";
        StaticVariable.chapter = "chap1";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame1Hard()
    {
		StaticVariable.game = 1;
        StaticVariable.difficulty = "hard";
        StaticVariable.chapter = "chap1";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame2Easy()
    {
		StaticVariable.game = 2;
        StaticVariable.difficulty = "easy";
        StaticVariable.chapter = "chap2";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame2Medium()
    {
		StaticVariable.game = 2;
        StaticVariable.difficulty = "medium";
        StaticVariable.chapter = "chap2";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame2Hard()
    {
		StaticVariable.game = 2;
        StaticVariable.difficulty = "hard";
        StaticVariable.chapter = "chap2";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame3Easy()
    {
		StaticVariable.game = 3;
        StaticVariable.difficulty = "easy";
        StaticVariable.chapter = "chap3";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame3Medium()
    {
		StaticVariable.game = 3;
        StaticVariable.difficulty = "medium";
        StaticVariable.chapter = "chap3";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame3Hard()
    {
		StaticVariable.game = 3;
        StaticVariable.difficulty = "hard";
        StaticVariable.chapter = "chap3";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame4Easy()
    {
		StaticVariable.game = 4;
        StaticVariable.difficulty = "easy";
        StaticVariable.chapter = "chap4";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame4Medium()
    {
		StaticVariable.game = 4;
        StaticVariable.difficulty = "medium";
        StaticVariable.chapter = "chap4";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GotoGame4Hard()
    {
		StaticVariable.game = 4;
        StaticVariable.difficulty = "hard";
        StaticVariable.chapter = "chap4";
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GoToLeaderBoard()
    {
        StaticVariable.lastVisited = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("NewLB");
    }

	public void GoToAvatar()
	{
		Debug.Log("why am i here" + StaticVariable.lastVisited);
		StaticVariable.lastVisited = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Avatar");
	}
	public void GoToCreateLevel()
    {
        SceneManager.LoadScene("PlayerGame1");
    }
}
