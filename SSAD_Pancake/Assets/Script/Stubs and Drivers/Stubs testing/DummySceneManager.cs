using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool changeScene(string scene)
    {
        if (scene != null)
        {
            return true;
        }
        else return false; 
    }
}
