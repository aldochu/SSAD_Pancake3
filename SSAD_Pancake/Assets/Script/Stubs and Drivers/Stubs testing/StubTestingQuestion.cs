using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StubTestingQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    private DummyCRUDQuestion crudQuestion;
    private string world, chap, difficulty, oldDifficulty, newDifficulty, gameID, userid;
    private GetQuestion question;
    private GetQuestion[] questions;

    void Start()
    {
        crudQuestion = GetComponent<DummyCRUDQuestion>();

        world = "world1";
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
        studentAddNewQuestions(userid, questions, 2);
        getStudentGameIDList();
        getStudentGameQuestion(gameID);
        }


    public void AddNewQuestion(string world, string chap, string difficulty, UploadQuestion question)
    {

        Debug.Log("Add new question into database");
        Debug.Log("Call Question manager to add data");
        bool result = crudQuestion.AddNewQuestion(world, chap, difficulty, question);

        if (result != false)
        {
            Debug.Log("Question Added");
        }
    }

    public void UpdateQuestion(string world, string chap, string difficulty, GetQuestion question)
    {
        Debug.Log("Update question from database");
        Debug.Log("Call Question manager to update data");
        bool result = crudQuestion.UpdateQuestion(world, chap, difficulty, question);

        if (result != false)
        {
            Debug.Log("Question Updated");
        }

    }

    public void UpdateQuestionDifficulty(string world, string chap, string oldDifficulty, string newDifficulty, GetQuestion question)
    {
        Debug.Log("Update question difficulty from database");
        Debug.Log("Call Question manager to update data");
        bool result = crudQuestion.UpdateQuestionDifficulty(world, chap, oldDifficulty, newDifficulty, question);

        if (result != false)
        {
            Debug.Log("Question Updated");
        }
    }

    public void getQuestion(string world, string chap, string difficulty)
    {
        Debug.Log("retrieve questions from database");
        Debug.Log("Call Question manager to get data");
        bool result = crudQuestion.getQuestion(world, chap, difficulty);

        if (result != false)
        {
            Debug.Log("Question retrieved");
        }
    }


    public void studentAddNewQuestions(string userid, GetQuestion[] questions, int size)
    {

        Debug.Log("Add student choosen questions into database");
        Debug.Log("Call Question manager to add data");
        bool result = crudQuestion.studentAddNewQuestions(userid, questions, size);

        if (result != false)
        {
            Debug.Log("Question added");
        }

    }


    //this function will generate a list of game id that was created by all students
    public void getStudentGameIDList()
    {
        Debug.Log("Get a list of student made game id from database");
        Debug.Log("Call Question manager to get data");
        bool result = crudQuestion.getStudentGameIDList();

        if (result != false)
        {
            Debug.Log("game id retrieved");
        }

    }

    public void getStudentGameQuestion(string gameID)
    {
        Debug.Log("retrieve questions choosen by student from database");
        Debug.Log("Call Question manager to get data");
        bool result = crudQuestion.getStudentGameQuestion(gameID);

        if (result != false)
        {
            Debug.Log("Question retrieved");
        }
    }
}
