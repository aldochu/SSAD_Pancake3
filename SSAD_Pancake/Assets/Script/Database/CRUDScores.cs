﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class CRUDScores : MonoBehaviour
{
    private DatabaseReference mDatabaseRef;
    private int threshold = 10000;
    public StudentScores[] OrderedScoreList;
    public Dictionary<string, double> passingRateDict;
    public Dictionary<string, int> totalAttemptDict;
    public Dictionary<string, int> highestScoreDict;
    public Dictionary<string, int> lowestScoreDict;
    public Dictionary<string, double> averageScoreDict;
    // Start is called before the first frame update

    void Awake()
    {
        // Set this before calling into the realtime database.
        /*FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");*/

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssad-c9270.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        //StaticVariable.mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        //RandomlyGenerateScores("world3");
        //RandomlyGenerateStudentGameScores();
        //RandomlyGenerateScores("testworld2");
        getStudentGameLeaderBoard("45914933", printgetStudentGameLeaderBoard);
    }



    public void RandomlyGenerateScores(string world)
    {
        StudentScores newScore = new StudentScores();

        for (int k = 0; k < 20; k++)
        {
            newScore.name = "student" + Random.Range(0, 10000);
            newScore.scores = Random.Range(0, 100000);
            newScore.attempt = Random.Range(1, 3);
            AddNewScores(world, "chap1", "easy", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores(world, "chap1", "normal", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores(world, "chap1", "hard", "userid"+ Random.Range(0, 10000) , newScore);

            AddNewScores(world, "chap2", "easy", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores(world, "chap2", "normal", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores(world, "chap2", "hard", "userid" + Random.Range(0, 10000), newScore);

            AddNewScores(world, "chap3", "easy", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores(world, "chap3", "normal", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores(world, "chap3", "hard", "userid" + Random.Range(0, 10000), newScore);

            AddNewScores(world, "chap4", "easy", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores(world, "chap4", "normal", "userid" + Random.Range(0, 10000), newScore);
            AddNewScores(world, "chap4", "hard", "userid" + Random.Range(0, 10000), newScore);
        }
    }

    public void RandomlyGenerateStudentGameScores()
    {
        StudentScores newScore = new StudentScores();

        for (int k = 0; k < 5; k++)
        {
            newScore.name = "student" + Random.Range(0, 10000);
            newScore.scores = Random.Range(0, 100000);
            newScore.attempt = Random.Range(1, 3);

            AddStudentGameNewScores("student3", newScore.name, "84356", newScore);
    
        }
    }

    public void AddNewScores(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {
        string json = JsonUtility.ToJson(studentscore);
        mDatabaseRef.Child("scores").Child(world).Child(chap).Child(difficulty).Child(userid).SetRawJsonValueAsync(json);
    }

    public void getLeaderBoard(string world, string chap, string difficulty, System.Action<bool> callback)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("scores").Child(world).Child(chap).Child(difficulty).OrderByChild("scores")
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {

              Debug.Log("Code Runs");
              DataSnapshot snapshot = task.Result;

              
              OrderedScoreList = new StudentScores[11];
              for (int i = 0; i < 11; i++)
              {
                  OrderedScoreList[i] = new StudentScores();
              }

              int index = 0;
              //currently order is ascending
              StudentScores[] scoresList = new StudentScores[200];
              foreach (DataSnapshot s in snapshot.Children)
              {
                  //Debug.Log(index+s.GetRawJsonValue());
                  scoresList[index] = new StudentScores();
                  scoresList[index++] = JsonUtility.FromJson<StudentScores>(s.GetRawJsonValue());
              }
                //Debug.Log(index);
            //   StudentScores[] OrderedScoreList = new StudentScores[index];
              for (int i = 0; i < 11 && i<index; i++)
              {
                  OrderedScoreList[i] = scoresList[index-i-1];
                  //Debug.Log("Score: " + OrderedScoreList[i].name);
              }

              if (index == 0)
              {
                  callback(false);
              }
              else
              callback(true);
              //Debug.Log("Code End");
         }
      });
    }


    public void getUserScore(string world, string chap, string difficulty, string userid, System.Action<StudentScores> callback)
    {
        FirebaseDatabase.DefaultInstance
    .GetReference("scores").Child(world).Child(chap).Child(difficulty).Child(userid)
    .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;

            StudentScores studentScore = new StudentScores();

            studentScore = JsonUtility.FromJson<StudentScores>(snapshot.GetRawJsonValue());

            //need to check whether it exist in database
            if (studentScore == null)
            {
                //Debug.Log("it's null");
                callback(null);
            }
            else
            {
                //Debug.Log("attemp:" + studentScore.attempt + "  , name is: " + studentScore.name + "  , score: " + studentScore.scores);
                callback(studentScore);
            }
                
        }
      });

    }

    public void getUserScore(string world, string chap, string difficulty, string userid, System.Action<StudentScores,string,string,string> callback)
    {

        Debug.Log(world+chap+difficulty+userid);
        FirebaseDatabase.DefaultInstance
    .GetReference("scores").Child(world).Child(chap).Child(difficulty).Child(userid)
    .GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted)
        {
            Debug.Log("Failed to connect");
            // Handle the error...
        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;

            StudentScores studentScore = new StudentScores();
            
            studentScore = JsonUtility.FromJson<StudentScores>(snapshot.GetRawJsonValue());
            Debug.Log("here1");
            Debug.Log(studentScore.scores);
            Debug.Log("here2");
            //need to check whether it exist in database
            if (studentScore == null)
            {
                Debug.Log("it's null");
                callback(null, null, null, null);
            }
            else
            {
                Debug.Log("attemp:" + studentScore.attempt + "  , name is: " + studentScore.name + "  , score: " + studentScore.scores);
                callback(studentScore,world,chap,difficulty);
            }

        }
    });

    }

    public void updateUserScore(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {


        string json = JsonUtility.ToJson(studentscore);


        mDatabaseRef.Child("scores").Child(world).Child(chap).Child(difficulty).Child(userid).SetRawJsonValueAsync(json);
    }


    public void AddStudentGameNewScores(string GameOwneruserid, string userid, string UniqueQuestionId, StudentScores studentscore)
    {


        string json = JsonUtility.ToJson(studentscore);


        mDatabaseRef.Child("studentGame").Child(GameOwneruserid).Child(UniqueQuestionId).Child("scores").Child(userid).SetRawJsonValueAsync(json); ;
    }

    public void getUserScoreForStudentGame(string GameOwneruserid, string userid, string UniqueQuestionId, System.Action<StudentScores> callback)
    {
        FirebaseDatabase.DefaultInstance
    .GetReference("studentGame").Child(GameOwneruserid).Child(UniqueQuestionId).Child("scores").Child(userid)
    .GetValueAsync().ContinueWith(task =>
    {
        if (task.IsFaulted)
        {
            Debug.Log("Failed to connect");
            // Handle the error...
        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;

            StudentScores studentScore = new StudentScores();

            studentScore = JsonUtility.FromJson<StudentScores>(snapshot.GetRawJsonValue());

            //need to check whether it exist in database
            if (studentScore == null)
            {
                //Debug.Log("it's null");
                callback(null);
            }
            else
            {
                //Debug.Log("attemp:" + studentScore.attempt + "  , name is: " + studentScore.name + "  , score: " + studentScore.scores);
                callback(studentScore);
            }

        }
    });
    }

    public void getStudentGameLeaderBoard(string gameID, System.Action<StudentScores[]> callback)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("studentGame")
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {

              Debug.Log("Code Runs");
              DataSnapshot snapshot = task.Result;



              int Scoreindex = 0;
              StudentScores[] scoresList = new StudentScores[100];
              foreach (DataSnapshot s in snapshot.Children)
              {

                  foreach (DataSnapshot ss in s.Children)
                  {

                      if (gameID == ss.Key)
                      {
                      
                          foreach (DataSnapshot sss in ss.Child("scores").Children)
                          {
                              
                              scoresList[Scoreindex] = new StudentScores();
                              scoresList[Scoreindex++] = JsonUtility.FromJson<StudentScores>(sss.GetRawJsonValue());
                              //Debug.Log("StudentName: " + scoresList[Scoreindex-1].name + " , Student Score: " + scoresList[Scoreindex-1].scores);
                          }

                          break;

                      }


                  }

              }


              OrderedScoreList = new StudentScores[11];
              for (int i = 0; i < 11; i++)
              {
                  OrderedScoreList[i] = new StudentScores();
              }

              //Debug.Log(index);
              //   StudentScores[] OrderedScoreList = new StudentScores[index];
              for (int i = 0; i < 11 && i < Scoreindex; i++)
              {
                  OrderedScoreList[i] = scoresList[Scoreindex - i - 1];
                  //Debug.Log("Score: " + OrderedScoreList[i].name);
              }

              if (Scoreindex == 0)
              {
                  callback(null);
              }
              else
                  callback(OrderedScoreList);
              //Debug.Log("Code End");
          }
      });
    }

    public void printgetStudentGameLeaderBoard(StudentScores[] OrderedStudentScores)
    {
        foreach(StudentScores s in OrderedStudentScores)
        {
            if(s.name != null)
            Debug.Log("StudentName: " + s.name + " , Student Score: " + s.scores);
        }
    }



    public void getStatistics(string world)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("scores").Child(world)
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {

              Debug.Log("Code Runs");
              DataSnapshot snapshot = task.Result;
              
              passingRateDict = new Dictionary<string, double>();
              totalAttemptDict = new Dictionary<string, int>();

              foreach (DataSnapshot chapter in snapshot.Children)
              {
                foreach (DataSnapshot mode in chapter.Children ){
                    int passCount = 0;
                    int totalCount = 0;
                    int totalAttempt = 0;
                    foreach (DataSnapshot s in mode.Children ){
                        Debug.Log(s.Key);
                        Debug.Log(s.GetRawJsonValue());
                        if (System.Convert.ToInt32(s.Child("scores").GetRawJsonValue()) > threshold){
                            passCount ++;
                        }
                        totalCount ++;
                        totalAttempt += System.Convert.ToInt32(s.Child("attempt").GetRawJsonValue());   
                    }
                    Debug.Log(chapter.Key+mode.Key);
                    passingRateDict[chapter.Key+mode.Key] = (double) passCount / (double) totalCount;
                    totalAttemptDict[chapter.Key+mode.Key] = totalAttempt;
                  }
                }

              Debug.Log("Code End");
         }
      });
    }

    public void getStatistic2(string world)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("scores").Child(world)
      .GetValueAsync().ContinueWith(task =>
      {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {

              Debug.Log("Code Runs");
              DataSnapshot snapshot = task.Result;
              
              averageScoreDict = new Dictionary<string, double>();
              highestScoreDict = new Dictionary<string, int>();
              lowestScoreDict = new Dictionary<string, int>();              

              foreach (DataSnapshot chapter in snapshot.Children)
              {
                foreach (DataSnapshot mode in chapter.Children ){
                    int highestScore = 0;
                    int lowestScore = 0;
                    int count = 0;
                    int totalScore= 0;
                    foreach (DataSnapshot s in mode.Children ){
                        Debug.Log(s.Key);
                        Debug.Log(s.GetRawJsonValue());
                        int score = System.Convert.ToInt32(s.Child("scores").GetRawJsonValue());
                        if (score > highestScore){
                            highestScore = score;
                        } else if (score < lowestScore || lowestScore == 0){
                            lowestScore = score;
                        }
                        count ++;
                        totalScore +=score;
                    }
                    Debug.Log(chapter.Key+mode.Key);
                    highestScoreDict[chapter.Key+mode.Key] = highestScore;
                    lowestScoreDict[chapter.Key+mode.Key] = lowestScore;
                    averageScoreDict[chapter.Key+mode.Key] =(double) totalScore / (double) count;
                  }
                }

              Debug.Log("Code End");
         }
      });
    }
 }
