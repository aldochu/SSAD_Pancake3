using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTest_CRUDUser : MonoBehaviour
{
    private AddUser crudUser;
    private string userid, useremail, invalidUserid;
    // Start is called before the first frame update
    void Start()
    {
        crudUser = GetComponent<AddUser>();
        userid = "user1";
        invalidUserid = "user1234";
        useremail = "email1234@gmail.com";

        Test_getUser_WithValidValue(userid);
        Test_getUser_WithInvalidValue(invalidUserid);
        //
    }

    //need to have a delay for few second to retrieve data from database before checking the value
    IEnumerator TestCoroutine_fort_getUser_WithValidValue(string userid)
    {
        yield return new WaitForSeconds(0.5f);
        assert(StaticVariable.UserProfile.userid == userid && userid != null, true);
        yield break;
    }

    IEnumerator TestCoroutine_fort_getUser_WithInvalidValue(string userid)
    {
        yield return new WaitForSeconds(0.5f);
        assert(StaticVariable.UserProfile.userid == userid && userid != null, false);
        yield break;
    }

    public void Test_getUser_WithValidValue(string userid)
    {
        crudUser.getUser(userid);
        StartCoroutine(TestCoroutine_fort_getUser_WithValidValue(userid));
    }

    public void Test_getUser_WithInvalidValue(string userid)
    {
        crudUser.getUser(userid);
        StartCoroutine(TestCoroutine_fort_getUser_WithInvalidValue(userid));
    }

    public void assert(string input1, string input2)
    {
        if (input1 == input2)
            Debug.Log("Test passed");
        else
            Debug.Log("Test failed");
    }

    public void assert(bool input1, bool input2)
    {
        if (input1 == input2)
            Debug.Log("Test passed");
        else
            Debug.Log("Test failed");
    }

}
