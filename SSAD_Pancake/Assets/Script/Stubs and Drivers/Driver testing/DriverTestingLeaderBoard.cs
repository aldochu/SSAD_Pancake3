using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverTestingLeaderBoard : MonoBehaviour
{
    private CRUDScores crudscore;
    private string world, chap, difficulty;
    // Start is called before the first frame update
    void Start()
    {
        crudscore = GetComponent<CRUDScores>();


        world = "world1";
        chap = "chap1";
        difficulty = "easy";

        getLeaderBoard(world, chap, difficulty);
        getStatistics(world);
    }


    public void getLeaderBoard(string world, string chap, string difficulty)
    {
        Debug.Log("Get leaderboard scores");
        Debug.Log("Call Score manager to get data");
        crudscore.getLeaderBoard(world, chap, difficulty, printSuccessMsg);
    }


    public void getStatistics(string world)
    {
        Debug.Log("Get statistics");
        Debug.Log("Call Score manager to get data");
        crudscore.getStatistics(world);

        printSuccessMsg2(true);
    }

    public void printSuccessMsg(StudentScores[] dummy, int dummyy)
    {
        Debug.Log("CRUD called");
    }


    public void printSuccessMsg2(bool dummy)
    {
        Debug.Log("CRUD called");
    }
}
