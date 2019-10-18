using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCRUDScores : MonoBehaviour
{
    public bool AddNewScores(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {


        if (world != null && chap != null && difficulty != null && userid != null && studentscore != null)
        {
            return true;
        }
        return false;
    }

    public bool getLeaderBoard(string world, string chap, string difficulty)
    {
        if (world != null && chap != null && difficulty != null)
        {
            return true;
        }
        return false;
    }


    public bool getUserScore(string world, string chap, string difficulty, string userid)
    {
        if (world != null && chap != null && difficulty != null && userid != null)
        {
            return true;
        }
        return false;
    }


    public bool updateUserScore(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {


        if (world != null && chap != null && difficulty != null && userid != null && studentscore!=null)
        {
            return true;
        }
        return false;
    }


    public bool AddStudentGameNewScores(string GameOwneruserid, string userid, string UniqueQuestionId, StudentScores studentscore)
    {


        if (GameOwneruserid != null && UniqueQuestionId != null && userid != null && studentscore != null)
        {
            return true;
        }
        return false;
    }

    public bool getUserScoreForStudentGame(string GameOwneruserid, string userid, string UniqueQuestionId)
    {
        if (GameOwneruserid != null && UniqueQuestionId != null && userid != null)
        {
            return true;
        }
        return false;
    }


    public bool getStatistics(string world)
    {
        if (world != null)
        {
            return true;
        }
        return false;
    }
}
