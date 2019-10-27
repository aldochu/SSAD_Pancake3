using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTest_CRUDScore : MonoBehaviour
{
    private CRUDScores crudscore;
    // Start is called before the first frame update
    private string world, chap, difficulty, userid, userid2, GameOwneruserid, UniqueQuestionId;
    void Start()
    {
        crudscore = GetComponent<CRUDScores>();

        world = "world1";
        chap = "chap1";
        difficulty = "easy";
        userid = "userid1159";
        userid2 = "user1";
        GameOwneruserid = "student1";
        UniqueQuestionId = "3405934";

        Preformancetest_getLeaderBoard(world, chap, difficulty);
        Preformancetest_getUserScores(world, chap, difficulty, userid);
        Preformancetest_getUserScoreForStudentGame(GameOwneruserid, userid2, UniqueQuestionId);
    }

    public void Preformancetest_getLeaderBoard(string world, string chap, string difficulty)
    {
        Debug.Log("Calling getLeaderBoard at: " + System.DateTime.Now);
        crudscore.getLeaderBoard(world, chap, difficulty, printgetLeaderBoardTime);
    }

    public void printgetLeaderBoardTime(StudentScores[] dummy,int dummyy)
    {
        Debug.Log("Getting getLeaderBoard data at: " + System.DateTime.Now);
    }

    public void Preformancetest_getUserScores(string world, string chap, string difficulty, string userid)
    {
        Debug.Log("Calling getUserScores at: " + System.DateTime.Now);
        crudscore.getUserScore(world, chap, difficulty, userid, printgetUserScoresTime);
    }

    public void printgetUserScoresTime(StudentScores dummy)
    {
        Debug.Log("Getting getUserScores data at: " + System.DateTime.Now);
    }

    public void Preformancetest_getUserScoreForStudentGame(string GameOwneruserid, string userid, string UniqueQuestionId)
    {
        Debug.Log("Calling getUserScoreForStudentGame at: " + System.DateTime.Now);
        crudscore.getUserScoreForStudentGame(GameOwneruserid, userid, UniqueQuestionId, printggetUserScoreForStudentGameTime);
    }

    public void printggetUserScoreForStudentGameTime(StudentScores dummy)
    {
        Debug.Log("Getting getUserScoreForStudentGame data at: " + System.DateTime.Now);
    }

}
