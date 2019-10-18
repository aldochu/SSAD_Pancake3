using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverTestingGame : MonoBehaviour
{
    private CRUDScores crudscore;

    private AddUser crudUser;

    private string world, chap, difficulty, userid, GameOwneruserid, UniqueQuestionId;

    private StudentScores studentscore;

    // Start is called before the first frame update
    void Start()
    {
        crudscore = GetComponent<CRUDScores>();
        crudUser = GetComponent<AddUser>();

        studentscore = new StudentScores();

        world = "testworld";
        chap = "chap1";
        difficulty = "easy";
        userid = "user1";
        studentscore.attempt = 1;
        studentscore.name = "Sam";
        studentscore.scores = 123;
        GameOwneruserid = "student1";
        UniqueQuestionId = "3405934";

        AddNewScores(world, chap, difficulty, userid, studentscore);
        getUserScores(world, chap, difficulty, userid);
        updateUserScore(world, chap, difficulty, userid, studentscore);
        AddStudentGameNewScores(GameOwneruserid, userid, UniqueQuestionId, studentscore);
        getUserScoreForStudentGame(GameOwneruserid, userid, UniqueQuestionId);
    }

    public void AddNewScores(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {

        Debug.Log("Add user score into database");
        Debug.Log("Call Score manager to add data");
        crudscore.AddNewScores(world, chap, difficulty, userid, studentscore);

        crudscore.getUserScore(world, chap, difficulty, userid, printSuccessMsg);
    }


    public void printSuccessMsg(StudentScores sc)
    {
        Debug.Log("CRUD called");
    }





    public void getUserScores(string world, string chap, string difficulty, string userid)
    {
        Debug.Log("Get user score for stage display");
        Debug.Log("Call Score manager to retrieve data");
        crudscore.getUserScore(world, chap, difficulty, userid, printSuccessMsg);

    }

    public void updateUserScore(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {


        Debug.Log("Update user score");
        Debug.Log("Call Score manager to update data");
        crudscore.updateUserScore(world, chap, difficulty, userid, studentscore);

        crudscore.getUserScore(world, chap, difficulty, userid, printSuccessMsg);

    }

    public void AddStudentGameNewScores(string GameOwneruserid, string userid, string UniqueQuestionId, StudentScores studentscore)
    {


        Debug.Log("Add student's game user score into database");
        Debug.Log("Call Score manager to add data");
        crudscore.AddStudentGameNewScores(GameOwneruserid, userid, UniqueQuestionId, studentscore);

        crudscore.getUserScoreForStudentGame(GameOwneruserid, userid, UniqueQuestionId, printSuccessMsg);

    }

    public void getUserScoreForStudentGame(string GameOwneruserid, string userid, string UniqueQuestionId)
    {
        Debug.Log("Get student's game user score into database");
        Debug.Log("Call Score manager to add data");
        crudscore.getUserScoreForStudentGame(GameOwneruserid, userid, UniqueQuestionId, printSuccessMsg);
    }
}
