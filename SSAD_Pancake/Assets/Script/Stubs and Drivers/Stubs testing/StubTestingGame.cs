using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StubTestingGame : MonoBehaviour
{
    private DummyCRUDScores crudscore;

    private DummySceneManager sceneManager;

    private DummyCRUDUser crudUser;

    private string world, chap, difficulty, userid, GameOwneruserid, UniqueQuestionId, scene;

    StudentScores studentscore = new StudentScores();

    // Start is called before the first frame update
    void Start()
    {
        crudscore = GetComponent<DummyCRUDScores>();
        sceneManager = GetComponent<DummySceneManager>();


        world = "world1";
        chap = "chap1";
        difficulty = "easy";
        userid = "user1";
        studentscore.attempt = 1;
        studentscore.name = "Sam";
        studentscore.scores = 123;
        GameOwneruserid = "user2";
        UniqueQuestionId = "q1234";
        scene = "scene1";


        AddNewScores(world, chap, difficulty, userid, studentscore);
        getUserScores(world, chap, difficulty, userid);
        updateUserScore(world, chap, difficulty, userid, studentscore);
        AddStudentGameNewScores(GameOwneruserid, userid, UniqueQuestionId, studentscore);
        getUserScoreForStudentGame(GameOwneruserid, userid, UniqueQuestionId);
        ChangeScene(scene);
    }

    public void AddNewScores(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {

        Debug.Log("Add user score into database");
        Debug.Log("Call Score manager to add data");
        bool score = crudscore.AddNewScores(world, chap, difficulty, userid, studentscore);

        if (score != false)
        {
            Debug.Log("Score Added");
        }
    }

 

    public void getUserScores(string world, string chap, string difficulty, string userid)
    {
        Debug.Log("Get user score for stage display");
        Debug.Log("Call Score manager to retrieve data");
        bool score = crudscore.getUserScore(world, chap, difficulty, userid);

        if (score != false)
        {
            Debug.Log("Score Retrieve");
        }
    }

    public void updateUserScore(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {


        Debug.Log("Update user score");
        Debug.Log("Call Score manager to update data");
        bool status = crudscore.updateUserScore(world, chap, difficulty, userid, studentscore);

        if (status != false)
        {
            Debug.Log("Score Updated");
        }

    }

    public void AddStudentGameNewScores(string GameOwneruserid, string userid, string UniqueQuestionId, StudentScores studentscore)
    {


        Debug.Log("Add student's game user score into database");
        Debug.Log("Call Score manager to add data");
        bool score = crudscore.AddStudentGameNewScores(GameOwneruserid, userid,UniqueQuestionId, studentscore);

        if (score != false)
        {
            Debug.Log("Score Added");
        }
    }

    public void getUserScoreForStudentGame(string GameOwneruserid, string userid, string UniqueQuestionId)
    {
        Debug.Log("Get student's game user score from database");
        Debug.Log("Call Score manager to get data");
        bool score = crudscore.getUserScoreForStudentGame(GameOwneruserid, userid, UniqueQuestionId);

        if (score != false)
        {
            Debug.Log("Score retrieved");
        }
    }

        public void ChangeScene(string scene)
    {
        Debug.Log("Change scene");
        Debug.Log("Call scene manager to change scene");
        bool change = sceneManager.changeScene(scene);

        if (change != false)
        {
            Debug.Log("Scene Changed");
        }
    }


}
