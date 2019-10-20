using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateQuestion : MonoBehaviour
{

    [SerializeField]
    public CRUDquestion crudQuestion;

    public InputField q, a1, a2, a3, a4, correctA;
    public System.String question, ans1, ans2, ans3, ans4, correctAns;
    public Dropdown dropdown;
    public string dropValuebefore;
    public string dropValueafter;
    public int dropIndex;
    public int chapter;
    public string chapterString;
    public string id;

    private GameObject infoText;

    // Start is called before the first frame update
    void Start()
    {
        chapter = QuestionData.chapter;
        chapterString = chapter.ToString();
        dropdown = GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>();
        dropValuebefore = dropdown.options[dropdown.value].text;
        infoText = GameObject.Find("InfoText");
        infoText.SetActive(false);
        id = GameObject.Find("SceneController").GetComponent<ModifyChapter>().id;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateQuestion()
    {
        q = GameObject.Find("InputQuestion").GetComponent<InputField>();
        a1 = GameObject.Find("InputAnswer1").GetComponent<InputField>();
        a2 = GameObject.Find("InputAnswer2").GetComponent<InputField>();
        a3 = GameObject.Find("InputAnswer3").GetComponent<InputField>();
        a4 = GameObject.Find("InputAnswer4").GetComponent<InputField>();
        correctA = GameObject.Find("CorrectAnswer").GetComponent<InputField>();

        dropIndex = dropdown.value;
        dropValueafter = dropdown.options[dropIndex].text;

        question = q.text;
        ans1 = a1.text;
        ans2 = a2.text;
        ans3 = a3.text;
        ans4 = a4.text;
        correctAns = correctA.text;

        bool comp1 = correctAns.Equals(ans1);
        bool comp2 = correctAns.Equals(ans2);
        bool comp3 = correctAns.Equals(ans3);
        bool comp4 = correctAns.Equals(ans4);
        
        if (dropValuebefore.Equals(dropValueafter))
        {
            if (comp1 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
                getQuestion.UniqueKey = id;
                crudQuestion.GetComponent<CRUDquestion>().UpdateQuestion("world1", chapterString, dropValueafter, getQuestion);
                setText();
            }
            else if (comp2 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
                getQuestion.UniqueKey = id;
                crudQuestion.GetComponent<CRUDquestion>().UpdateQuestion("world1", chapterString, dropValueafter, getQuestion);
                setText();
            }
            else if (comp3 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
                getQuestion.UniqueKey = id;
                crudQuestion.GetComponent<CRUDquestion>().UpdateQuestion("world1", chapterString, dropValueafter, getQuestion);
                setText();
            }
            else if (comp4 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
                getQuestion.UniqueKey = id;
                crudQuestion.GetComponent<CRUDquestion>().UpdateQuestion("world1", chapterString, dropValueafter, getQuestion);
                setText();
            }
            else
            {
                infoText.SetActive(true);
            }
        } else
        {
            if(comp1 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
                getQuestion.UniqueKey = id;
                crudQuestion.GetComponent<CRUDquestion>().UpdateQuestionDifficulty("world1", chapterString, dropValuebefore, dropValueafter, getQuestion);
                setText();
            }
            else if (comp2 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
                getQuestion.UniqueKey = id;
                crudQuestion.GetComponent<CRUDquestion>().UpdateQuestionDifficulty("world1", chapterString, dropValuebefore, dropValueafter, getQuestion);
                setText();
            }
            else if (comp3 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
                getQuestion.UniqueKey = id;
                crudQuestion.GetComponent<CRUDquestion>().UpdateQuestionDifficulty("world1", chapterString, dropValuebefore, dropValueafter, getQuestion);
                setText();
            }
            else if (comp4 == true)
            {
                GetQuestion getQuestion = new GetQuestion();
                getQuestion.uploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
                getQuestion.UniqueKey = id;
                crudQuestion.GetComponent<CRUDquestion>().UpdateQuestionDifficulty("world1", chapterString, dropValuebefore, dropValueafter, getQuestion);
                setText();
            }
            else
            {
                infoText.SetActive(true);
            }
        }
        Debug.Log("ID: " + id);
        Debug.Log("question: " + question);
        Debug.Log("Difficulty: " + dropValuebefore);
        Debug.Log("Difficulty: after: " + dropValueafter);
    }
    

        
    
    public void setText()
    {
        infoText.GetComponent<Text>().color = Color.white;
        infoText.GetComponent<Text>().text = "Question successfully updated";
    }
}
