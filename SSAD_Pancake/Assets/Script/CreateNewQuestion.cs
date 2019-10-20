using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewQuestion : MonoBehaviour
{
    [SerializeField]
    public CRUDquestion crudQuestion;

    public InputField q, a1, a2, a3, a4, correctA;
    public System.String question, ans1, ans2, ans3, ans4, correctAns;
    public Dropdown dropdown;
    public string dropValue;
    public int dropIndex;
    public int chapter;
    public string chapterString;

    private GameObject infoText;

    // Start is called before the first frame update
    void Start()
    {
        chapter = QuestionData.chapter;
        chapterString = chapter.ToString();
        dropdown = GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>();
        infoText = GameObject.Find("InfoText");
        infoText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createQuestion()
    {
        q = GameObject.Find("InputQuestion").GetComponent<InputField>();
        a1 = GameObject.Find("InputAnswer1").GetComponent<InputField>();
        a2 = GameObject.Find("InputAnswer2").GetComponent<InputField>();
        a3 = GameObject.Find("InputAnswer3").GetComponent<InputField>();
        a4 = GameObject.Find("InputAnswer4").GetComponent<InputField>();
        correctA = GameObject.Find("CorrectAnswer").GetComponent<InputField>();

        dropIndex = dropdown.value;
        dropValue = dropdown.options[dropIndex].text;

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

        if (comp1 == true)
        {
            UploadQuestion uploadQuestion = new UploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
            crudQuestion.GetComponent<CRUDquestion>().AddNewQuestion("world1", chapterString, dropValue, uploadQuestion);
            setText();
        }
        else if (comp2 == true)
        {
            UploadQuestion uploadQuestion = new UploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
            crudQuestion.GetComponent<CRUDquestion>().AddNewQuestion("world1", chapterString, dropValue, uploadQuestion);
            setText();
        }
        else if(comp3 == true)
        {
            UploadQuestion uploadQuestion = new UploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
            crudQuestion.GetComponent<CRUDquestion>().AddNewQuestion("world1", chapterString, dropValue, uploadQuestion);
            setText();
        }
        else if(comp4 == true)
        {
            UploadQuestion uploadQuestion = new UploadQuestion(question, ans1, ans2, ans3, ans4, correctAns);
            crudQuestion.GetComponent<CRUDquestion>().AddNewQuestion("world1", chapterString, dropValue, uploadQuestion);
            setText();
        }
        else {
            infoText.SetActive(true);
        }
    }

    public void setText() {
        infoText.GetComponent<Text>().color = Color.white;
        infoText.GetComponent<Text>().text = "Question successfully created";
    }
}
