using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
public class injectQuestion : MonoBehaviour
{
    private DatabaseReference mDatabaseRef;
    void Awake()
    {
        // Set this before calling into the realtime database.
        /*FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");*/

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssad-c9270.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;



        ////////////////////////////This function will create a new question in the database//////////////////////////////////////
        ///Specify which world, chap and difficulty level of the question into the function
        GetQuestion sample = new GetQuestion();
        sample.question.question = "22+20=?";
        sample.question.ans1 = "39";
        sample.question.ans2 = "40";
        sample.question.ans3 = "41";
        sample.question.ans4 = "42";
        sample.question.correctAns = "42";
        sample.UniqueKey = "1114554";

        AddNewQuestion("world1", "Chap1", "easy", sample.question);
    }


    public void AddNewQuestion(string world, string chap, string difficulty, UploadQuestion question)
    {

        string UniqueKey = Random.Range(0, 10000).ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString();

        string json = JsonUtility.ToJson(question);


        mDatabaseRef.Child("question").Child(world).Child(chap).Child(difficulty).Child(UniqueKey).SetRawJsonValueAsync(json);
    }
}
