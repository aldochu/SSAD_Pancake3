using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Text error;
    public InputField textbox;
    CRUDquestion crudqn;
    bool callback = false;
    GetQuestion[] qns = null;
    string userID = null;
    IEnumerator couroutine;
    void Start()
    {
        error.enabled = false;
        crudqn = GetComponent<CRUDquestion>();
    }

    public void checkGame()
    {
        
        couroutine = checkGameID();
        StartCoroutine(couroutine);



    }

    IEnumerator checkGameID()
    {
        string gameID = textbox.text;
        crudqn.getStudentGameQuestion(gameID, callbackFunc);
        yield return new WaitUntil(() => callback == true);


        if (userID == null)
        {
            error.text = "Invalid Game ID";
            error.enabled = true;
        }
        else
        {
            StaticVariable.gameID = gameID;
            StaticVariable.ownerID = userID;
            StaticVariable.game = 5;
            SceneManager.LoadScene("CharacterSelection");
        }
    }

    public void callbackFunc(GetQuestion[] IdList, string UserID)
    {
        userID = UserID;
        qns = IdList;
        callback = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
