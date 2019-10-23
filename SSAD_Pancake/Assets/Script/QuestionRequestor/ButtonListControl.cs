using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    public CRUDquestion crudQuestion;

    private GetQuestion[] questionlist;
    public bool listGot;
    private List<GameObject> buttons = new List<GameObject>();
    private int numQuestions;

    private void Start()
    {
        try { crudQuestion.getQuestion(QuestionData.world, QuestionData.chapter, "easy", callbackFunc); QuestionData.difficulty = "easy"; } catch { }
        Debug.Log("$$$$$$" + QuestionData.difficulty);
    }

    private void Update()
    {
        if (listGot)
        {

            if (buttons.Count > 0)
            {
                foreach (GameObject button in buttons)
                {
                    Destroy(button.gameObject);
                }
                buttons.Clear();
            }

            for (int i = 1; i < numQuestions + 1; i++)
            {
               
                if (questionlist[i] == null)
                {
                    listGot = false;
                }
                else
                {
                    GameObject button = Instantiate(buttonTemplate) as GameObject;
                    button.SetActive(true);
                    button.GetComponent<ButtonListButton>().SetText(questionlist[i].question.question, i);
                    button.transform.SetParent(buttonTemplate.transform.parent, false);
                    buttons.Add(button);
                }
            }
            listGot = false;
        }
    }

    public void callbackFunc(GetQuestion[] questionList)
    {
        this.questionlist = questionList;
        this.numQuestions = questionList.Length;
        listGot = true;
    }

    public void ButtonClicked(int questionId)
    {
        GameObject.Find("SceneController").GetComponent<ModifyChapter>().changeScene("EditQandA", QuestionData.world, QuestionData.chapter, QuestionData.difficulty, questionlist[questionId], questionlist[questionId].UniqueKey);
    }

    public void refreshList()
    {
        Debug.Log("******************"+ QuestionData.difficulty);
        crudQuestion.getQuestion(QuestionData.world, QuestionData.chapter, QuestionData.difficulty, callbackFunc);
    }
}
