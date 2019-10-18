using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCRUDUser : MonoBehaviour
{
    public bool writeNewUser(string userid, string useremail)
    {

        if (userid != null && useremail != null)
        {
            return true;
        }
        return false;
    }

    public bool updateUser()
    {
        return true;

    }

    public bool getUserAvatar(CustomizeAvatar headGear, CustomizeAvatar head, CustomizeAvatar body)
    {
        return true;
    }

    public bool getUser(string userid)
    {

        if (userid != null)
        {
            return true;
        }
        return false;
    }

    public bool updateUserWorld(string world, string chap, string value)
    {
        if (world != null && chap != null && value != null)
        {
            return true;
        }
        return false;
    }

    public bool updateAvatar(string headgear, string head, string body)
    {
        if (headgear != null && head != null && body != null)
        {
            return true;
        }
        return false;
    }
}
