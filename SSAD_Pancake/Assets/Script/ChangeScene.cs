using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
     // Start is called before the first frame update
    public string sceneName;

    public void changeScene(string sceneName)
    {
        Debug.Log(sceneName);
        Application.LoadLevel(sceneName);
    }
    void OnMouseDown()
    {
        Application.LoadLevel(sceneName);  
    }
}

