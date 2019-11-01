using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class injectScore : MonoBehaviour
{
    private DatabaseReference mDatabaseRef;

    // Start is called before the first frame update

    void Awake()
    {
        // Set this before calling into the realtime database.
        /*FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");*/

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssad-c9270.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;


        ////////////////////////////This function will add a new score in the database//////////////////////////////////////
        ///Specify which world, chap and difficulty level of the question, student and the scores of the student into the function
        StudentScores sample = new StudentScores();
        sample.name = "Johnny pean";
        sample.scores = Random.Range(0, 100000);
        sample.attempt = Random.Range(1, 3);

        AddNewScores("world1", "chap1", "easy", "myuserid", sample);
    }


    public void AddNewScores(string world, string chap, string difficulty, string userid, StudentScores studentscore)
    {
        string json = JsonUtility.ToJson(studentscore);
        mDatabaseRef.Child("scores").Child(world).Child(chap).Child(difficulty).Child(userid).SetRawJsonValueAsync(json);
    }
}
