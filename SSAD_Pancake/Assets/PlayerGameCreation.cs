using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameCreation : MonoBehaviour
{
    // Start is called before the first frame update
    public Text errorList;
    public Text success;
    public Canvas view;
    public Canvas successCanvas;
    public Dropdown worldList;
    public Dropdown chapterList;
    public Dropdown difficultyList;
    public Dropdown questionDropdown;
    public Dropdown selectedDropDown;
    CRUDquestion crudqn;
    bool callback = false;
    string[] idList = null;
    static string[] worlds = { "world1", "world2" };
    static string[] chapters = { "chap1", "chap2", /*"chap3", */"chap4" };
    static string[] difficulty = { "easy", "normal", "hard" };
    List<GetQuestion>[][][] fullArray;
    GetQuestion[] array;
    List<string> selectedQuestions = new List<string>();
    private IEnumerator coroutine;
    IEnumerator Start()
    {
        successCanvas.enabled = false;
        errorList.enabled = false;
        crudqn = GetComponent<CRUDquestion>();
        worldList.options.Clear();
        foreach (var item in worlds)
        {
            worldList.options.Add(new Dropdown.OptionData() { text = item });

        }
        worldList.RefreshShownValue();

        chapterList.options.Clear();
        foreach (var item in chapters)
        {
            chapterList.options.Add(new Dropdown.OptionData() { text = item });
        }
        chapterList.RefreshShownValue();

        difficultyList.options.Clear();
        foreach (var item in difficulty)
        {
            difficultyList.options.Add(new Dropdown.OptionData() { text = item });
        }
        difficultyList.RefreshShownValue();


        fullArray = new List<GetQuestion>[worlds.Length][][];
        for (int a = 0; a < worlds.Length; a++)
        {
            fullArray[a] = new List<GetQuestion>[chapters.Length][];
            for (int b = 0; b < chapters.Length; b++)
            {
                fullArray[a][b] = new List<GetQuestion>[difficulty.Length];
                for (int c = 0; c < difficulty.Length; c++)
                {
                    callback = false;
                    Debug.Log(worlds[a] + " " + chapters[b] + " " + difficulty[c]);
                    crudqn.getQuestion(worlds[a], chapters[b], difficulty[c], callbackFunc);
                    
                    yield return new WaitUntil(() => callback == true);
                    fullArray[a][b][c] = new List<GetQuestion>();
                    if (array != null)
                    {
                        foreach (var item in array)
                        {
                            if (item != null)
                            {

                                fullArray[a][b][c].Add(item);
                            }
                        }
                    }
                }
            }

        }
        callback = false;

        updateQuestion();
    }



    public void CreateGame()
    {
        if (selectedQuestions.Count < 10)
        {
            errorList.text = "Please select at least 10 questions";
            errorList.enabled = true;
        }
        else
        {
            GetQuestion[] allQuestions = new GetQuestion[selectedQuestions.Count];
            int i = 0;
            bool found;
            foreach (var item in selectedQuestions)
            {
                found = false;
                foreach (var world in fullArray)
                {
                    if (found) break;
                    foreach (var chapter in world)
                    {
                        if (found) break;
                        foreach (var diff in chapter)
                        {
                            if (found) break;
                            foreach (var record in diff)
                            {
                                if (record != null && record.question.question == item)
                                {
                                    found = true;
                                    allQuestions[i] = record;
                                    i++;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            view.enabled = false;
            successCanvas.enabled = true;
            errorList.text = "testing 1 2 3";
            errorList.enabled = true;
            string returnValue = crudqn.studentAddNewQuestions("userid1159", allQuestions, selectedQuestions.Count);
            
            
            success.text = "GGame ID: '" + returnValue + "'.";
            
        }
    }
    public void updateQuestion()
    {
        /*coroutine = updateQuestionList();
        StartCoroutine(coroutine);*/
        int world = 0;
        int chapter = 0;
        int diff = 0;
        for (int i = 0; i < worlds.Length; i++)
        {
            if (worlds[i] == worldList.options[worldList.value].text)
            {
                world = i; break;
            }
        }

        for (int i = 0; i < chapters.Length; i++)
        {
            if (chapters[i] == chapterList.options[chapterList.value].text)
            {
                chapter = i; break;
            }
        }

        for (int i = 0; i < difficulty.Length; i++)
        {
            if (difficulty[i] == difficultyList.options[difficultyList.value].text)
            {
                diff = i; break;
            }
        }
        List<string> options = new List<string>();
        foreach (var item in fullArray[world][chapter][diff])
        {
            bool found = false;
            foreach (var selecteditem in selectedQuestions)
            {
                if (item.question.question.Equals(selecteditem))
                {
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                options.Add(item.question.question);
            }
        }
        questionDropdown.ClearOptions();
        questionDropdown.AddOptions(options);
        questionDropdown.RefreshShownValue();
    }

    IEnumerator updateQuestionList()
    {
        string world = worldList.options[worldList.value].text;
        string chapter = chapterList.options[chapterList.value].text;
        string difficulty = difficultyList.options[difficultyList.value].text;
        Debug.Log(world + chapter + difficulty);

        if (world != "" && chapter != "" && difficulty != "")
        {
            crudqn.getQuestion(world, chapter, difficulty, callbackFunc);
            yield return new WaitUntil(() => callback == true);
            questionDropdown.ClearOptions();
            List<string> options = new List<string>();
            foreach (var item in array)
            {
                bool found = false;
                if (item != null)
                {
                    foreach (var questionItem in selectedQuestions)
                    {
                        if (questionItem.Contains(item.question.question))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        options.Add(item.UniqueKey + ": " + item.question.question);
                    }
                }
                // questionDropdown.options.Add(new Dropdown.OptionData(item.question.question));
            }
            questionDropdown.AddOptions(options);
            questionDropdown.RefreshShownValue();
        }
    }

    public void addItem()
    {
        string item = questionDropdown.options[questionDropdown.value].text;
        selectedQuestions.Add(item);

        selectedDropDown.ClearOptions();
        selectedDropDown.AddOptions(selectedQuestions);
        selectedDropDown.RefreshShownValue();
        updateQuestion();
    }

    public void remoteItem()
    {
        string item = selectedDropDown.options[selectedDropDown.value].text;

        selectedQuestions.Remove(item);
        Debug.Log(item);

        selectedDropDown.ClearOptions();
        if (selectedQuestions.Count > 0)
        {
            selectedDropDown.AddOptions(selectedQuestions);
        }
        selectedDropDown.RefreshShownValue();
        updateQuestion();

    }

    public void callbackFunc(GetQuestion[] IdList)
    {
        array = IdList;
        callback = true;
        //yield return new WaitUntil(() => callback == true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
