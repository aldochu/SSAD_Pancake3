using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverTestingQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    private CRUDquestion crudQuestion;
    private string world, chap, difficulty, oldDifficulty, newDifficulty, gameID, userid;
    private GetQuestion question;
    private GetQuestion[] questions;

    void Start()
    {
        crudQuestion = GetComponent<CRUDquestion>();

        world = "testworld";
        chap = "chap1";
        difficulty = "easy";
        oldDifficulty = "easy";
        newDifficulty = "hard";
        gameID = "1234";
        question = new GetQuestion();
        question.UniqueKey = "123";
        question.question.question = "1+1=?";
        question.question.ans1 = "1";
        question.question.ans2 = "2";
        question.question.ans3 = "3";
        question.question.ans4 = "4";
        question.question.correctAns = "2";
        userid = "user123";
        questions = new GetQuestion[1];
        questions[0] = question;
        AddNewQuestion(world, chap, difficulty, question.question);
        UpdateQuestion(world, chap, difficulty, question);
        UpdateQuestionDifficulty(world, chap, oldDifficulty, newDifficulty, question);
        getQuestion(world, chap, difficulty);
        studentAddNewQuestions(userid, questions, 1);
        getStudentGameIDList();
        getStudentGameQuestion(gameID);
    }

    public void AddNewQuestion(string world, string chap, string difficulty, UploadQuestion question)
    {

        Debug.Log("Add new question into database");
        Debug.Log("Call Question manager to add data");
        crudQuestion.AddNewQuestion(world, chap, difficulty, question);


        Debug.Log("Data Added");
    }

    public void UpdateQuestion(string world, string chap, string difficulty, GetQuestion question)
    {
        Debug.Log("Update question from database");
        Debug.Log("Call Question manager to update data");
        crudQuestion.UpdateQuestion(world, chap, difficulty, question);

        Debug.Log("Data Updated");
    }

    public void UpdateQuestionDifficulty(string world, string chap, string oldDifficulty, string newDifficulty, GetQuestion question)
    {
        Debug.Log("Update question difficulty from database");
        Debug.Log("Call Question manager to update data");
        crudQuestion.UpdateQuestionDifficulty(world, chap, oldDifficulty, newDifficulty, question);


        Debug.Log("Data Updated");
    }

    public void getQuestion(string world, string chap, string difficulty)
    {
        Debug.Log("retrieve questions from database");
        Debug.Log("Call Question manager to get data");
        crudQuestion.getQuestion(world, chap, difficulty, GetQuestionsSuccessfully);

    }


    public void GetQuestionsSuccessfully(GetQuestion[] getQuestions)
    {
        Debug.Log("Questions retrieved");
    }

    public void GetQuestionsSuccessfully(GetQuestion[] getQuestions, string GameOwnerID)
    {
        Debug.Log("Questions retrieved");
    }


    public void studentAddNewQuestions(string userid, GetQuestion[] questions, int size)
    {

        Debug.Log("Add student choosen questions into database");
        Debug.Log("Call Question manager to add data");
        crudQuestion.studentAddNewQuestions(userid, questions, size);

        Debug.Log("Data Added");
    }


    //this function will generate a list of game id that was created by all students
    public void getStudentGameIDList()
    {
        Debug.Log("Get a list of student made game id from database");
        Debug.Log("Call Question manager to get data");
        crudQuestion.getStudentGameIDList(getStudentGameIDListSuccessfully);

    }

    public void getStudentGameIDListSuccessfully(string[] getID)
    {
        Debug.Log("ID retrieved");
    }

    public void getStudentGameQuestion(string gameID)
    {
        Debug.Log("retrieve questions choosen by student from database");
        Debug.Log("Call Question manager to get data");
        crudQuestion.getStudentGameQuestion(gameID, GetQuestionsSuccessfully);
    }
}
