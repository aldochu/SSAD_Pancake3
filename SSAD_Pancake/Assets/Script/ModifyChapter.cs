using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ModifyChapter : MonoBehaviour
{
    [SerializeField]
    public CRUDquestion crudQuestion;

    [SerializeField]
    public ButtonListControl buttonListControl;
    
    // needed to store value of the input fields from the scene "EditQAndA"
    public InputField question, a1, a2, a3, a4, correctAns;
    public string q, ans1, ans2, ans3, ans4, correctA;
    public Dropdown dropdown;
    public string dropValuebefore;
    public string dropValueafter;
    public int dropIndex;
    public string chapterString;
    public GameObject infoText;
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        chapterString = QuestionData.chapter;
        dropdown = GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>();
        dropValuebefore = dropdown.options[dropdown.value].text;
        infoText = GameObject.Find("InfoText");
        infoText.SetActive(false);
        
        try
        {
            GameObject.Find("InputQuestion").GetComponent<InputField>().text = PlayerPrefs.GetString("qn");
            GameObject.Find("InputAnswer1").GetComponent<InputField>().text = PlayerPrefs.GetString("a1");
            GameObject.Find("InputAnswer2").GetComponent<InputField>().text = PlayerPrefs.GetString("a2");
            GameObject.Find("InputAnswer3").GetComponent<InputField>().text = PlayerPrefs.GetString("a3");
            GameObject.Find("InputAnswer4").GetComponent<InputField>().text = PlayerPrefs.GetString("a4");
            GameObject.Find("CorrectAnswer").GetComponent<InputField>().text = PlayerPrefs.GetString("ca");
            GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>().value = PlayerPrefs.GetString("difficulty") == "easy" ? 0 : PlayerPrefs.GetString("difficulty") == "medium" ? 1 : 2;
        } catch { }

    }

    //change scene
    public void changeScene(string sceneName, string world, string chap, string difficulty, GetQuestion questionObj, string id)
    {
        SceneManager.LoadScene(sceneName);

        PlayerPrefs.SetString("qn", questionObj.question.question);
        PlayerPrefs.SetString("a1", questionObj.question.ans1);
        PlayerPrefs.SetString("a2", questionObj.question.ans2);
        PlayerPrefs.SetString("a3", questionObj.question.ans3);
        PlayerPrefs.SetString("a4", questionObj.question.ans4);
        PlayerPrefs.SetString("ca", questionObj.question.correctAns);
        PlayerPrefs.SetString("difficulty", difficulty);

        StaticVariable.id = id;
        Debug.Log("ID: " + StaticVariable.id);
    }

    public void changeChapter(int chapter)
    {
        QuestionData.chapter = "chap" + chapter.ToString();
    }

    //going a page back
    public void goBack(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DropdownIndexChanged(int index)
    {
        QuestionData.difficulty = index == 0 ? "easy" : index == 1 ? "normal" : "hard";
        GameObject.Find("ButtonScrollList").GetComponent<ButtonListControl>().refreshList();
    }

    public void setText()
    {
        infoText.GetComponent<Text>().color = Color.white;
        infoText.GetComponent<Text>().text = "Question successfully updated";
        infoText.SetActive(true);
    }

    // gets current value of input fields and updates the database (either just the questions or also the difficulty)
    public void updateQuestion()
    {
        question = GameObject.Find("InputQuestion").GetComponent<InputField>();
        a1 = GameObject.Find("InputAnswer1").GetComponent<InputField>();
        a2 = GameObject.Find("InputAnswer2").GetComponent<InputField>();
        a3 = GameObject.Find("InputAnswer3").GetComponent<InputField>();
        a4 = GameObject.Find("InputAnswer4").GetComponent<InputField>();
        correctAns = GameObject.Find("CorrectAnswer").GetComponent<InputField>();

        dropIndex = dropdown.value;
        dropValueafter = dropdown.options[dropIndex].text;

        q = question.text;
        ans1 = a1.text;
        ans2 = a2.text;
        ans3 = a3.text;
        ans4 = a4.text;
        correctA = correctAns.text;

        bool comp1 = correctA.Equals(ans1);
        bool comp2 = correctA.Equals(ans2);
        bool comp3 = correctA.Equals(ans3);
        bool comp4 = correctA.Equals(ans4);

        Debug.Log("Question: " + q);
        Debug.Log("ans1 : " + ans1);
        Debug.Log("ans2 : " + ans2);
        Debug.Log("ans3 : " + ans3);
        Debug.Log("ans4 : " + ans4);
        Debug.Log("correctA : " + correctA);
        Debug.Log("Difficulty: " + dropValueafter);
        Debug.Log("ID: " + StaticVariable.id);

        
        // checks if the difficulty remained the same
        if (dropValuebefore.Equals(dropValueafter))
        {
            if (comp1 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(q, ans1, ans2, ans3, ans4, correctA, StaticVariable.id);
                crudQuestion.UpdateQuestion(QuestionData.world, chapterString, dropValueafter, getQuestion);
                setText();
            }
            else if (comp2 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(q, ans1, ans2, ans3, ans4, correctA, StaticVariable.id);
                crudQuestion.UpdateQuestion(QuestionData.world, chapterString, dropValueafter, getQuestion);
                setText();
            }
            else if (comp3 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(q, ans1, ans2, ans3, ans4, correctA, StaticVariable.id);
                crudQuestion.UpdateQuestion(QuestionData.world, chapterString, dropValueafter, getQuestion);
                setText();
            }
            else if (comp4 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(q, ans1, ans2, ans3, ans4, correctA, StaticVariable.id);
                crudQuestion.UpdateQuestion(QuestionData.world, chapterString, dropValueafter, getQuestion);
                setText();
            }
            else
            {
                infoText.SetActive(true);
            }
        } else
        {
            if (comp1 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(q, ans1, ans2, ans3, ans4, correctA, StaticVariable.id);
                crudQuestion.UpdateQuestionDifficulty(QuestionData.world, chapterString, dropValuebefore, dropValueafter, getQuestion);
                setText();
            }
            else if (comp2 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(q, ans1, ans2, ans3, ans4, correctA, StaticVariable.id);
                crudQuestion.UpdateQuestionDifficulty(QuestionData.world, chapterString, dropValuebefore, dropValueafter, getQuestion);
                setText();
            }
            else if (comp3 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(q, ans1, ans2, ans3, ans4, correctA, StaticVariable.id);
                crudQuestion.UpdateQuestionDifficulty(QuestionData.world, chapterString, dropValuebefore, dropValueafter, getQuestion);
                setText();
            }
            else if (comp4 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(q, ans1, ans2, ans3, ans4, correctA, StaticVariable.id);
                crudQuestion.UpdateQuestionDifficulty(QuestionData.world, chapterString, dropValuebefore, dropValueafter, getQuestion);
                setText();
            }
            else
            {
                infoText.SetActive(true);
            }
            
        }
    }

    public void deleteQuestion()
    {
        Debug.Log("World: " + QuestionData.world);
        Debug.Log("Chapter: " + chapterString);
        Debug.Log("Difficulty: " + dropValuebefore);
        Debug.Log("ID: " + StaticVariable.id);
        
        crudQuestion.DeleteQuestion("world1", "chap" + chapterString, dropValuebefore, StaticVariable.id);
        GameObject.Find("SceneController").GetComponent<ModifyChapter>().goBack("QuestionOverview");
        buttonListControl.refreshList();
        
    }
}