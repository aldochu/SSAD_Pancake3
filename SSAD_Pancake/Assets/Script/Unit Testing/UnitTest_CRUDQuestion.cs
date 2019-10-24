using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTest_CRUDQuestion : MonoBehaviour
{
    private CRUDquestion crudQuestion;
    private string world, invalidworld , chap, difficulty, gameID, invalidGameID;


    // Start is called before the first frame update
    void Start()
    {
        crudQuestion = GetComponent<CRUDquestion>();
        world = "world1";
        invalidworld = "wowowowow";
        chap = "chap1";
        difficulty = "easy";
        gameID = "3405934";
        invalidGameID = "1";
        Test_getQuestion_WithValidValue(world, chap, difficulty);
        Test_getQuestion_WithInvalidValue(invalidworld, chap, difficulty);
        Test_getStudentGameIDList();
        Test_getStudentGameQuestion_WithValidValue(gameID);
        Test_getStudentGameQuestion_WithInvalidValue(invalidGameID);
    }

    public void Test_getQuestion_WithValidValue(string world, string chap, string difficulty)
    {
        crudQuestion.getQuestion( world,  chap,  difficulty, CallBackFunction_WithTrue);
    }

    public void Test_getQuestion_WithInvalidValue(string world, string chap, string difficulty)
    {
        crudQuestion.getQuestion(world, chap, difficulty, CallBackFunction_WithFalse);
    }

    public void Test_getStudentGameIDList()
    {
        crudQuestion.getStudentGameIDList(CallBackFunction_WithTrue);
    }

    public void Test_getStudentGameQuestion_WithValidValue(string gameID)
    {
        crudQuestion.getStudentGameQuestion(gameID,CallBackFunction_WithTrue);
    }

    public void Test_getStudentGameQuestion_WithInvalidValue(string gameID)
    {
        crudQuestion.getStudentGameQuestion(gameID, CallBackFunction_WithFalse);
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



    public void CallBackFunction_WithTrue(string[] sc)
    {
        assert((sc[0] != null), true);
    }

    public void CallBackFunction_WithTrue(GetQuestion[] sc)
    {
        assert((sc[0] != null), true);
    }

    public void CallBackFunction_WithFalse(GetQuestion[] sc)
    {
        assert((sc[0] != null), false);
    }

    public void CallBackFunction_WithTrue(GetQuestion[] sc, string id)
    {
        assert((sc[0] != null), true);
    }

    public void CallBackFunction_WithFalse(GetQuestion[] sc, string id)
    {
        assert((sc[0] != null), false);
    }

}
