[System.Serializable]
public class GetQuestion 
{
    public string UniqueKey;
    public UploadQuestion question = new UploadQuestion();

    public GetQuestion()
    {
    }

    public void uploadQuestion(string question, string ans1, string ans2, string ans3, string ans4, string correctAns)
    {
        this.question.question = question;
        this.question.ans1 = ans1;
        this.question.ans2 = ans2;
        this.question.ans3 = ans3;
        this.question.ans4 = ans4;
        this.question.correctAns = correctAns;
    }
}
