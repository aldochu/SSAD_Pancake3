using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCRUDQuestion : MonoBehaviour
{
    public bool AddNewQuestion(string world, string chap, string difficulty, UploadQuestion question)
    {

       if(world!=null && chap!=null && difficulty!=null && question !=null)
        {
            return true;
        }
        return false;
    }

    public bool UpdateQuestion(string world, string chap, string difficulty, GetQuestion question)
    {
        if (world != null && chap != null && difficulty != null && question != null)
        {
            return true;
        }
        return false;

    }

    public bool UpdateQuestionDifficulty(string world, string chap, string oldDifficulty, string newDifficulty, GetQuestion question)
    {
        if (world != null && chap != null && oldDifficulty != null && newDifficulty != null && question != null)
        {
            return true;
        }
        return false;
    }

    public bool getQuestion(string world, string chap, string difficulty)
    {
        if (world != null && chap != null && difficulty != null)
        {
            return true;
        }
        return false;
    }


    public bool studentAddNewQuestions(string userid, GetQuestion[] questions, int size)
    {

        if (userid != null && questions != null)
        {
            return true;
        }
        return false;

    }


    //this function will generate a list of game id that was created by all students
    public bool getStudentGameIDList()
    {
        return true;

    }

    public bool getStudentGameQuestion(string gameID)
    {
        if (gameID != null)
            return true;
        else
            return false;


    }

}
