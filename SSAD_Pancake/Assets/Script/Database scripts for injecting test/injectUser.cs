using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;

public class injectUser : MonoBehaviour
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


        /////////////////////////////////This function will inject new user into the database////////////////////////////////////////
        writeNewUser("new user 1", "new user email");


    }

    public void writeNewUser(string userid, string useremail)
    {
        StaticVariable.UserProfile.userid = userid;
        StaticVariable.UserProfile.email = useremail;

        Debug.Log("New user created");


        string[] myusername = useremail.Split('@');

        Debug.Log(myusername[0] + useremail);
        User user = new User(myusername[0], useremail);
        string json = JsonUtility.ToJson(user);

        Avatar avatar = new Avatar("0", "0", "0");
        StaticVariable.UserProfile.avatar = avatar;
        string json2 = JsonUtility.ToJson(avatar);


        world world = new world("000", "000", "000", "000");
        Universe universe = new Universe();
        universe.world1 = world;
        universe.world2 = world;
        universe.world3 = world;
        universe.world4 = world;
        StaticVariable.UserProfile.universe = universe;
        string json3 = JsonUtility.ToJson(world);


        mDatabaseRef.Child("users").Child(userid).SetRawJsonValueAsync(json);
        mDatabaseRef.Child("users").Child(userid).Child("avatar").SetRawJsonValueAsync(json2);
        mDatabaseRef.Child("users").Child(userid).Child("universe").Child("world1").SetRawJsonValueAsync(json3);
        mDatabaseRef.Child("users").Child(userid).Child("universe").Child("world2").SetRawJsonValueAsync(json3);
        mDatabaseRef.Child("users").Child(userid).Child("universe").Child("world3").SetRawJsonValueAsync(json3);
        mDatabaseRef.Child("users").Child(userid).Child("universe").Child("world4").SetRawJsonValueAsync(json3);

    }
}
