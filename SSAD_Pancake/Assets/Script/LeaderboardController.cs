using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class LeaderboardController : MonoBehaviour {

    public List<HighscoreEntry> highscores;

    private string world = "world1";
    private string chapter = "chap1";
    private string mode = "easy";
    public CRUDScores dbClass;
    public AddUser addUser;
    public bool gotData = false;
    public Text userId;
    public Text userScore;
    public Text userRank;
    public Text userIdOnBoard;
    public HighscoreTableTransformer transformer;
    public string username;
    public string userscore;
    public string userrank;
    public bool gotUserScore = false;
    public StudentScores[] OrderedScoreList;

    private void Awake() {
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
        //For Testing only
        StaticVariable.UserProfile.avatar.headgear ="1";
        StaticVariable.UserProfile.avatar.head ="1";
        StaticVariable.UserProfile.avatar.body ="1";
        StaticVariable.UserID="userid9702";

        dbClass.getLeaderBoard(world, chapter, mode, callback);
        highscores= new List<HighscoreEntry>(11);
        for (int i = 0; i<11 ;i++){
            highscores.Add(new HighscoreEntry());
        }
        if (SceneManager.GetActiveScene().name =="NewLB"){
            transformer.ConstructTableForStudent(highscores);
            userId.text = StaticVariable.UserID;
            dbClass.getUserScore(world, chapter, mode, StaticVariable.UserID, getUserScoreCallback);
        }
        else{
            transformer.ConstructTable(highscores);
        }
    }

    public void getUserScoreCallback(StudentScores myScore, string world, string chap, string difficulty)
    {
        Debug.Log("call back executed");
        username = myScore.name;
        userscore = myScore.scores.ToString();
        dbClass.getLeaderBoard(world, chapter, mode, callback);
        gotUserScore = true;
    }

    public void DropdownValueChanged(Dropdown Dropdown) {
        Debug.Log(Dropdown.options[Dropdown.value].text);
        updateQueryString(Dropdown.options[Dropdown.value].text);
        dbClass.getLeaderBoard(world, chapter, mode, callback);
    }
    
    public void callback(StudentScores[] scores, int index){             
        OrderedScoreList = new StudentScores[11];
        for (int i = 0; i < 11; i++)
        {
            OrderedScoreList[i] = new StudentScores();
        }

        for (int i = 0; i < 11 && i<index; i++)
        {
            OrderedScoreList[i] = scores[index-i-1];
            //Debug.Log("Score: " + OrderedScoreList[i].name);
        }

        for (int i = 0; i<index; i++)
        {
            if (scores[index-i-1].name == username)
            {
                userrank = (i+1).ToString();
                break;
            }
        }
        gotData = true;
        Debug.Log(gotData);
    }

    void Update(){
        if (gotData) {
            int i = 0;
            Debug.Log(OrderedScoreList[0].scores);
            foreach (StudentScores s in OrderedScoreList) {
                Debug.Log(string.Format("Key = {0}, Value = {1}", s.scores,s.name));
                highscores[i].score = s.scores;
                highscores[i].name = s.name;
            
                transformer.ModifyTable(highscores[i], i);
                i++;
            }
            gotData = false;
            Debug.Log(gotData);
            if(userScore != null){
                Debug.Log(username);
                //userIdOnBoard.text = username;
                userScore.text = userscore;
                userRank.text = userrank;
                gotUserScore = false;
            }
        }
    }

    public void BackToLastScene()
    {
        Application.LoadLevel(StaticVariable.lastVisited);
    }

    public void GoToStudentGameLeaderboard()
    {
        StaticVariable.lastVisited = SceneManager.GetActiveScene().name;
        Application.LoadLevel("3rdLB");   
    }

    private void updateQueryString(string rawInput){
        switch(rawInput){
            case "Chapter 1": chapter = "chap1"; break;
            case "Chapter 2": chapter = "chap2"; break;
            case "Chapter 3": chapter = "chap3"; break;
            case "Chapter 4": chapter = "chap4"; break;
            case "World 1": world =  "world1"; break;
            case "World 2": world =  "world2"; break;
            case "World 3": world =  "world3"; break;
            case "World 4": world =  "world4"; break;
            case "Easy": mode = "easy"; break;
            case "Medium": mode = "mid"; break;
            case "Hard": mode = "hard"; break;
        }
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] 
    public class HighscoreEntry {
        public int score;
        public string name;
    }
}
