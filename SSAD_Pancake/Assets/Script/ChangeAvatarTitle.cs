using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAvatarTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text title = GetComponent<Text>();
        if (StaticVariable.lastVisited != null)
        {
            title.text = "Update Avatar";
        }
    }

    // Update is called once per frame
}
