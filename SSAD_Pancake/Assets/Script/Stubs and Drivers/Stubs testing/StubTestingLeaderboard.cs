using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StubTestingLeaderboard : MonoBehaviour
{
    private DummyCRUDScores crudscore;
    private string world, chap, difficulty;
    // Start is called before the first frame update
    void Start()
    {
        crudscore = GetComponent<DummyCRUDScores>();


        world = "world1";
        chap = "chap1";
        difficulty = "easy";

        getLeaderBoard(world,chap,difficulty);
        getStatistics(world);
    }

    public void getLeaderBoard(string world, string chap, string difficulty)
    {
        Debug.Log("Get leaderboard scores");
        Debug.Log("Call Score manager to get data");
        bool score = crudscore.getLeaderBoard(world, chap, difficulty);

        if (score != false)
        {
            Debug.Log("Score retrieved");
        }
    }


    public void getStatistics(string world)
    {
        Debug.Log("Get statistics");
        Debug.Log("Call Score manager to get data");
        bool score = crudscore.getStatistics(world);

        if (score != false)
        {
            Debug.Log("statistics retrieved");
        }
    }
}
