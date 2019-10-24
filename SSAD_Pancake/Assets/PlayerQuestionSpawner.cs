using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.SceneManagement;

public class PlayerQuestionSpawner : MonoBehaviour
{
    public AudioSource point;
    public AudioSource fail;
    int NumQuestions;
    public Text question;
    public Text answer1;
    public Text answer2;
    public Text answer3;
    public Text answer4;
    public Text Score;
    private DatabaseReference mDatabaseRef;
    int userChoice = 1;
    int score = 0;
    private IEnumerator coroutine;
    public GameObject startButton;
    public GameObject hero1;
    public GameObject hero1fall;
    public GameObject hero2;
    public GameObject hero2fall;
    public GameObject hero3;
    public GameObject hero3fall;
    StudentScores scoreList;
    bool call = false;
    int character;
    CRUDScores crudscore;
    CRUDquestion crudquestion;
    GetQuestion[] questionList;

    string userID = StaticVariable.UserID;//"userid1159";
    string gameID = StaticVariable.gameID;//"userid1159";
    string ownerID = StaticVariable.ownerID;//"userid1159";
    

    // Start is called before the first frame update
    IEnumerator Start()
    {
        character = StaticVariable.characterSelect;
        setCharacterMovement(character, false);
        Time.timeScale = 0;
        crudscore = GetComponent<CRUDScores>();
        crudquestion = GetComponent<CRUDquestion>();
        crudscore.getUserScoreForStudentGame(ownerID, userID, gameID, callbackFunc);
        yield return new WaitUntil(() => call == true);
        // Set this before calling into the realtime database.
        // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssad-c9270.firebaseio.com/");
        // Get the root reference location of the database.
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        Score.text = "0";
        // point = GetComponent<AudioSource>();

        coroutine = GenerateQuestions();
        StartCoroutine(coroutine);
    }
    public void BackToCharacterSelection()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void setCharacterMovement(int heroNumber, bool falldown)
    {
        hero1.SetActive(false);
        hero1fall.SetActive(false);
        hero2.SetActive(false);
        hero2fall.SetActive(false);
        hero3.SetActive(false);
        hero3fall.SetActive(false);
        if (heroNumber == 1)
        {
            if (falldown)
            {
                hero1.SetActive(false);
                hero1fall.SetActive(true);
            }
            else
            {
                hero1.SetActive(true);
                hero1fall.SetActive(false);
            }

        }
        else if (heroNumber == 2)
        {
            if (falldown)
            {
                hero2.SetActive(false);
                hero2fall.SetActive(true);
            }
            else
            {
                hero2.SetActive(true);
                hero2fall.SetActive(false);
            }
        }
        else
        {
            if (falldown)
            {
                hero3.SetActive(false);
                hero3fall.SetActive(true);
            }
            else
            {
                hero3.SetActive(true);
                hero3fall.SetActive(false);
            }
        }

    }
    public void startGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
    }
    public void playerMoveQn1()
    {
        userChoice = 1;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = new Vector3(-7f, -1.6f, 0);
        }
        hero1fall.transform.position = new Vector3(-7f, -1.6f, 0);
        hero2fall.transform.position = new Vector3(-7f, -1.6f, 0);
        hero3fall.transform.position = new Vector3(-7f, -1.6f, 0);
        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7f, -1.6f, 0);
        HeroFall.transform.position = new Vector3(-7f, -1.6f, 0);*/
    }
    public void playerMoveQn2()
    {
        userChoice = 2;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = new Vector3(-7f, -2.7f, 0);
        }
        hero1fall.transform.position = new Vector3(-7f, -2.7f, 0);
        hero2fall.transform.position = new Vector3(-7f, -2.7f, 0);
        hero3fall.transform.position = new Vector3(-7f, -2.7f, 0);
        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7f, -2.7f, 0);
        HeroFall.transform.position = new Vector3(-7f, -2.7f, 0);
        */
    }
    public void playerMoveQn3()
    {
        userChoice = 3;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = new Vector3(-7f, -3.8f, 0);
        }
        hero1fall.transform.position = new Vector3(-7f, -3.8f, 0);
        hero2fall.transform.position = new Vector3(-7f, -3.8f, 0);
        hero3fall.transform.position = new Vector3(-7f, -3.8f, 0);

        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7f, -3.8f, 0);
        HeroFall.transform.position = new Vector3(-7f, -3.8f, 0);*/
    }
    public void playerMoveQn4()
    {
        userChoice = 4;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            player.transform.position = new Vector3(-7f, -4.9f, 0);
        }
        hero1fall.transform.position = new Vector3(-7f, -4.9f, 0);
        hero2fall.transform.position = new Vector3(-7f, -4.9f, 0);
        hero3fall.transform.position = new Vector3(-7f, -4.9f, 0);


        /*
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7f, -4.9f, 0);
        HeroFall.transform.position = new Vector3(-7f, -4.9f, 0);*/
    }
    // Update is called once per frame
    void Update()
    {

    }
    bool CheckIfQuestionInArray(int question, int[] array)
    {
        foreach (var item in array)
        {
            if (question == item)
            {
                return true;
            }
        }
        return false;
    }


    public void callbackFunc(StudentScores scList)
    {
        scoreList = scList;
        call = true;
    }

    public void callbackFunc2(GetQuestion[] scList, string userID)
    {
        questionList = scList;
        call = true;
    }
    IEnumerator GenerateQuestions()
    {
        call = false;
        crudquestion.getStudentGameQuestion(gameID, callbackFunc2);

        yield return new WaitUntil(() => call==true);
       

        int totalQuestion = questionList.Length;
        NumQuestions = 10;
        if (NumQuestions > totalQuestion) //If not enough questions from the database
        {
            question.text = "Not enough question set for this chapter.";
            Time.timeScale = 0;
        }
        else
        {
            int rightOption = 0;
            for (int i = 0; i < NumQuestions; i++)
            {

                question.text = questionList[i].question.question;
                int random = Random.Range(1, 4);
                if (random == 1)
                {
                    answer1.text = questionList[i].question.ans1;
                    answer2.text = questionList[i].question.ans2;
                    answer3.text = questionList[i].question.ans3;
                    answer4.text = questionList[i].question.ans4;
                }
                else if (random == 2)
                {
                    answer1.text = questionList[i].question.ans2;
                    answer2.text = questionList[i].question.ans3;
                    answer3.text = questionList[i].question.ans1;
                    answer4.text = questionList[i].question.ans4;
                }
                else if (random == 3)
                {
                    answer1.text = questionList[i].question.ans3;
                    answer2.text = questionList[i].question.ans2;
                    answer3.text = questionList[i].question.ans4;
                    answer4.text = questionList[i].question.ans1;
                }
                else
                {
                    answer1.text = questionList[i].question.ans3;
                    answer2.text = questionList[i].question.ans1;
                    answer3.text = questionList[i].question.ans4;
                    answer4.text = questionList[i].question.ans2;
                }

                string rightAnswer = questionList[i].question.correctAns;

                if (rightAnswer == answer1.text)
                {
                    rightOption = 1;
                }
                else if (rightAnswer == answer2.text)
                {
                    rightOption = 2;
                }
                else if (rightAnswer == answer3.text)
                {
                    rightOption = 3;
                }
                else if (rightAnswer == answer4.text)
                {
                    rightOption = 4;
                }
                yield return new WaitForSeconds(4.2f);
                if (rightOption == userChoice)
                {
                    Debug.Log("Correct.");
                    score++;
                    Score.text = score.ToString();
                    point.Play();
                    yield return new WaitForSeconds(1.8f);
                }
                else
                {
                    Debug.Log("Wrong. Right Option " + rightOption);
                    setCharacterMovement(character, true);

                    fail.Play();
                    yield return new WaitForSeconds(0.6f);
                    setCharacterMovement(character, false);
                    yield return new WaitForSeconds(1.2f);
                }
                Debug.Log("Total Marks " + score);

            }
            // GETTING attempt  from scores

            int latestAttempt = 0;

            // To Insert student score into DB
            //
            if (scoreList != null)
            {
                Debug.Log(scoreList.scores);
                if (scoreList.scores > score)
                {
                    score = scoreList.scores;
                }
                latestAttempt = scoreList.attempt;
            }

            StudentScores sc = new StudentScores();

            sc.name = "";
            sc.attempt = latestAttempt + 1;
            sc.scores = score;
            crudscore.AddStudentGameNewScores(ownerID, userID, gameID, sc);

            Time.timeScale = 0;
            question.text = "Game Completed! Click back to attempt another game!";
        }

    }




}
