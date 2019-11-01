using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StudentLBController : MonoBehaviour {
    public CRUDScores dbClass;
    public List<LeaderboardController.HighscoreEntry> highscores;
    public HighscoreTableTransformer transformer;
    public bool getLeaderboard;
    public Text selfname;
    public Text selfscore;
    private StudentScores[] leaderboardData;

    private void Awake() {
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
        highscores= new List<LeaderboardController.HighscoreEntry>(11);
        for (int i = 0; i<11 ;i++){
            highscores.Add(new LeaderboardController.HighscoreEntry());
        }
        transformer.ConstructTableForStudent(highscores);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(getLeaderboard){
            int i = 0;
            foreach (StudentScores s in leaderboardData) {
                Debug.Log(string.Format("Key = {0}, Value = {1}", s.scores,s.name));
                highscores[i].score = s.scores;
                highscores[i].name = s.name;
            
                transformer.ModifyTable(highscores[i], i);
                i++;
            }
            getLeaderboard = false;
        }

    }

    public void inputValueChanged(InputField InputField){
        Debug.Log(InputField.text);
        dbClass.getStudentGameLeaderBoard(InputField.text, leaderboardCallback);
    }

    public void leaderboardCallback(StudentScores[] scoresList, int listSize){
        StudentScores[] OrderedScoreList = new StudentScores[11];
        for (int i = 0; i < 11; i++)
        {
            OrderedScoreList[i] = new StudentScores();
        }
        //Debug.Log(index);
        //   StudentScores[] OrderedScoreList = new StudentScores[index];
        for (int i = 0; i < 11 && i < listSize; i++)
        {
            OrderedScoreList[i] = scoresList[listSize - i - 1];
            //Debug.Log("Score: " + OrderedScoreList[i].name);
        }
        leaderboardData = OrderedScoreList;

        // foreach (StudentScores s in scoresList)
        // {
        //     Debug.Log(s.name);
        //     Debug.Log(s.scores);
        //     if(s.name == StaticVariable.UserID){
        //         selfname.text = s.name;
        //         selfscore.text = s.scores.ToString();
        //     }
        //     Debug.Log("here");
        // }
        Debug.Log("hi4");
        getLeaderboard = true;

    }

    public void BackToLastScene()
    {
        Application.LoadLevel("Leaderboard");
    }
}
