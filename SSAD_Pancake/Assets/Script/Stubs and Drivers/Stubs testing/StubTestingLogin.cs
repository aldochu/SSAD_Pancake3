using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StubTestingLogin : MonoBehaviour
{
    // Start is called before the first frame update
    private DummyCRUDUser crudUser;

    private string userid, useremail;
    void Start()
    {
        crudUser = GetComponent<DummyCRUDUser>();
        userid = "user1";
        useremail = "email1234@gmail.com";

        CreateAcc(userid, useremail);
        getUserAvatar(null, null, null);
        getUser(userid);
        updateAvatar("1", "1", "1");
    }

    public void CreateAcc(string userid, string useremail)
    {
        Debug.Log("Add new user into database");
        Debug.Log("Call user manager to add data");
        bool result = crudUser.writeNewUser(userid, useremail);

        if (result != false)
        {
            Debug.Log("User Added");
        }

    }


    public void getUserAvatar(CustomizeAvatar headGear, CustomizeAvatar head, CustomizeAvatar body)
    {
        Debug.Log("Get user avatar date from database");
        Debug.Log("Call user manager to get data");
        bool result = crudUser.getUserAvatar(headGear, head, body);

        if (result != false)
        {
            Debug.Log("User avatar retrieved");
        }
    }

    public void getUser(string userid)
    {

        Debug.Log("Get user info from database");
        Debug.Log("Call user manager to get data");
        bool result = crudUser.getUser(userid);

        if (result != false)
        {
            Debug.Log("User info retrieved");
        }
    }

    public void updateAvatar(string headgear, string head, string body)
    {
        Debug.Log("update user avatar from database");
        Debug.Log("Call user manager to update data");
        bool result = crudUser.updateAvatar(headgear,head,body);

        if (result != false)
        {
            Debug.Log("User avatar updated");
        }
    }
}
