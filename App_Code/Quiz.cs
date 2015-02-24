using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI.WebControls;
using Umbraco.Core;
using Umbraco.Core.Models;

/// <summary>
/// Summary description for Quiz
/// </summary>
public class Quiz : ContentItem
{
    public Quiz(IPublishedContent content) : base(content)
    {
    }

    public string Question
    {
        get { return Property("question"); }
    }

    public IEnumerable<Answer> Answers
    {
        get { return Children<Answer>(); }
    }

    public Answer CorrectAnswer
    {
        get { return PropertyOfType<Answer>("correctAnswer"); }
    }

    public bool IsPoll
    {
        get { return CorrectAnswer == null; }
    }


    public string CopyForCorrectAnswer
    {
        get { return Property("copyForCorrectAnswer"); }
    }

    public string CopyForIncorrectAnswer
    {
        get { return Property("copyForIncorrectAnswer"); }
    }

    public string ExplanatoryCopy
    {
        get { return Property("explanatoryCopy"); }
    }

    public bool Choose(int answerId)
    {
        var answer = Answers.First(x => x.Id == answerId);
        answer.Tally++;
        return answer.Equals(CorrectAnswer);
    }

    public int NumberOfVotes
    {
        get { return Answers.Sum(x => x.Tally); }
    }

    public int Percentage(Answer answer)
    {
        var total = NumberOfVotes;
        return (int) (Math.Round((decimal) answer.Tally/total, 2)*100);
    }

    public int PercentageCorrect
    {
        get
        {
            if (IsPoll)
                return 0;
            return Percentage(CorrectAnswer);
        }
    }

    public int PercentageIncorrect
    {
        get
        {
            if (IsPoll)
                return 0;
            return 100 - PercentageCorrect;
        }
    }

}

public class Answer : ContentItem
{
    public Answer(IPublishedContent content) : base(content)
    {
    }

    public string AnswerText
    {
        get { return Property("answer"); }
    }

    public int Tally
    {
        get { return Property<int>("tally"); }
        set
        {
            var content = ContentService.GetById(this.Id);
            content.SetValue("tally", value);
            ContentService.SaveAndPublishWithStatus(content);
        }
    }
}