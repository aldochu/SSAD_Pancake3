using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTest_CRUDQuestion : MonoBehaviour
{
    private CRUDquestion crudQuestion;
    private string world, chap, difficulty, gameID;

    // Start is called before the first frame update
    void Start()
    {
        crudQuestion = GetComponent<CRUDquestion>();
        world = "world1";
        chap = "chap1";
        difficulty = "easy";
        gameID = "3405934";

        PerformanceTest_getQuestion(world, chap, difficulty);
        PerformanceTest_getStudentGameIDList();
        PerformanceTest_getStudentGameQuestion(gameID);
    }

    public void PerformanceTest_getQuestion(string world, string chap, string difficulty)
    {
        Debug.Log("Calling GetQuestion at: "+System.DateTime.Now);
        crudQuestion.getQuestion(world, chap, difficulty, printGetQuestionTime);
    }



    public void printGetQuestionTime(GetQuestion[] dummy)
    {
        Debug.Log("Getting GetQuestion data at: " + System.DateTime.Now);
    }

    public void PerformanceTest_getStudentGameIDList()
    {
        Debug.Log("Calling GetStudentGameIDList at: " + System.DateTime.Now);
        crudQuestion.getStudentGameIDList(printgetStudentGameIDListTime);
    }

    public void printgetStudentGameIDListTime(string[] dummy)
    {
        Debug.Log("Getting GetStudentGameIDList data at: " + System.DateTime.Now);
    }

    public void PerformanceTest_getStudentGameQuestion(string gameID)
    {
        Debug.Log("Calling GetStudentGameIDQuestion at: " + System.DateTime.Now);
        crudQuestion.getStudentGameQuestion(gameID, printgetStudentGameQuestionTime);
    }

    public void printgetStudentGameQuestionTime(GetQuestion[] dummy, string dummyy)
    {
        Debug.Log("Getting GetStudentGameIDQuestion data at: " + System.DateTime.Now);
    }

}
