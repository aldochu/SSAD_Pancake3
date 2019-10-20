using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    public CRUDquestion crudQuestion;

    private GetQuestion[] questionlist;
    private string difficulty;
    private string world = "world1";
    private string chap = "chap1";
    private bool listGot = false;
    private string chapter;

    private int numQuestions = 10;

    private void Start()
    {
        chapter = QuestionData.chapter.ToString();
        crudQuestion.getQuestion("world1", "chap"+chapter, difficulty = "easy", callbackFunc);
        crudQuestion.getQuestion("world1", "chap" + chapter, difficulty = "hard", callbackFunc);
        crudQuestion.getQuestion("world1", "chap" + chapter, difficulty = "normal", callbackFunc);
        



    }

    private void Update()
    {
        if (listGot)
        {
            for (int i = 1; i < numQuestions + 1; i++)
            {
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);
                button.GetComponent<ButtonListButton>().SetText(questionlist[i].question.question, i);
                button.transform.SetParent(buttonTemplate.transform.parent, false);
            }
            listGot = false;
        }
    }

    public void callbackFunc(GetQuestion[] questionList)
    {
        this.questionlist = questionList;
        //this.numQuestions = questionList.Length;
        listGot = true;
    }

    public void ButtonClicked(int questionId)
    {
        GameObject.Find("SceneController").GetComponent<ModifyChapter>().changeScene("EditQandA", world, chap, difficulty, questionlist[questionId], questionlist[questionId].UniqueKey);
    }
}
