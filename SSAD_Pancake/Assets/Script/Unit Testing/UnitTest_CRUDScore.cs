using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTest_CRUDScore : MonoBehaviour
{
    private CRUDScores crudscore;
    // Start is called before the first frame update
    private string world, invalidworld, chap, difficulty,userid, userid2, GameOwneruserid, InvalidGameOwneruserid, UniqueQuestionId;

    private StudentScores studentscore;
    void Start()
    {
        crudscore = GetComponent<CRUDScores>();

        studentscore = new StudentScores();

        world = "world1";
        chap = "chap1";
        difficulty = "easy";

        invalidworld = "testingworld123";
        userid = "userid1159";
        userid2 = "user1";
        studentscore.attempt = 1;
        studentscore.name = "Sam";
        studentscore.scores = 123;
        GameOwneruserid = "student1";
        InvalidGameOwneruserid = "testinguser1234";
        UniqueQuestionId = "3405934";

        
        Test_getLeaderBoard_WithValidValue(world, chap, difficulty);
        Test_getLeaderBoard_WithInvalidValue(invalidworld, chap, difficulty);

        Test_getUserScores_WithValidValue(world, chap, difficulty, userid);
        Test_getUserScores_WithInvalidValue(invalidworld, chap, difficulty, userid);

        Test_getUserScoreForStudentGame_WithValidValue(GameOwneruserid, userid2, UniqueQuestionId);
        Test_getUserScoreForStudentGame_WithInvalidValue(InvalidGameOwneruserid, userid2, UniqueQuestionId);
        

    }


    public void Test_getLeaderBoard_WithValidValue(string world, string chap, string difficulty)
    {
        crudscore.getLeaderBoard(world, chap, difficulty, CallBackFunction_WithTrue);
    }

    public void Test_getLeaderBoard_WithInvalidValue(string world, string chap, string difficulty)
    {
        crudscore.getLeaderBoard(world, chap, difficulty, CallBackFunction_WithFalse);
    }

    public void Test_getUserScores_WithValidValue(string world, string chap, string difficulty, string userid)
    {
        crudscore.getUserScore(world, chap, difficulty, userid, CallBackFunction_WithTrue);
    }

    public void Test_getUserScores_WithInvalidValue(string world, string chap, string difficulty, string userid)
    {
        crudscore.getUserScore(world, chap, difficulty, userid, CallBackFunction_WithFalse);
    }

    public void Test_getUserScoreForStudentGame_WithValidValue(string GameOwneruserid, string userid, string UniqueQuestionId)
    {
        crudscore.getUserScoreForStudentGame(GameOwneruserid, userid, UniqueQuestionId, CallBackFunction_WithTrue);
    }

    public void Test_getUserScoreForStudentGame_WithInvalidValue(string GameOwneruserid, string userid, string UniqueQuestionId)
    {
        crudscore.getUserScoreForStudentGame(GameOwneruserid, userid, UniqueQuestionId, CallBackFunction_WithFalse);
    }



    public void assert(string input1, string input2)
    {
        if (input1 == input2)
            Debug.Log("Test passed");
        else
            Debug.Log("Test failed");
    }

    public void assert(bool input1, bool input2)
    {
        if (input1 == input2)
            Debug.Log("Test passed");
        else
            Debug.Log("Test failed");
    }

    public void CallBackFunction_WithTrue(StudentScores[] scores,int size)
    {
        assert(size>0, true);
    }

    public void CallBackFunction_WithFalse(StudentScores[] scores,int size) 
    {
        assert(size==0, false);
    }

    public void CallBackFunction_WithTrue(StudentScores sc)
    {
        assert((sc != null), true);
    }

    public void CallBackFunction_WithFalse(StudentScores sc)
    {
        assert((sc != null), false);
    }
}
