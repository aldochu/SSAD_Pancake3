using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverTestingLogin : MonoBehaviour
{
    // Start is called before the first frame update
    private AddUser crudUser;

    private string userid, useremail;
    void Start()
    {
        crudUser = GetComponent<AddUser>();
        userid = "user1";
        useremail = "email1234@gmail.com";

        CreateAcc(userid, useremail);
        getUser(userid);
        updateAvatar("2", "2", "2");

    }


    public void CreateAcc(string userid, string useremail)
    {
        Debug.Log("Add new user into database");
        Debug.Log("Call user manager to add data");
        crudUser.writeNewUser(userid, useremail);

        if (StaticVariable.UserID == userid)
        {
            Debug.Log("Account Created");
        }

    }


    public void getUser(string userid)
    {

        Debug.Log("Get user info from database");
        Debug.Log("Call user manager to get data");
        crudUser.getUser(userid);

        if (StaticVariable.UserID == userid)
        {
            Debug.Log("User info retrieved");
        }

        
    }

    public void updateAvatar(string headgear, string head, string body)
    {
        Debug.Log("update user avatar from database");
        Debug.Log("Call user manager to update data");
        crudUser.updateAvatar(headgear, head, body);

        if (StaticVariable.UserProfile.avatar.headgear == headgear && StaticVariable.UserProfile.avatar.head == head && StaticVariable.UserProfile.avatar.body == body)
        {
            Debug.Log("User avatar updated");
        }
    }
}
