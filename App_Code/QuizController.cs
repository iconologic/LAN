using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.WebApi;

/// <summary>
/// Summary description for QuizController
/// </summary>
public class QuizController : UmbracoApiController
{
    public QuizController()
    {
        
    }

    public object Get(int quizId, int answerId)
    {
        var quiz = new Quiz(Umbraco.TypedContent(quizId));
        var isCorrect = quiz.Choose(answerId);
        quiz = new Quiz(Umbraco.TypedContent(quizId));
        return
            new
            {
                isPoll = quiz.IsPoll,
                correct = isCorrect,
                percentageCorrect = quiz.PercentageCorrect,
                percentageIncorrect = quiz.PercentageIncorrect,
                copy = isCorrect ? quiz.CopyForCorrectAnswer : quiz.CopyForIncorrectAnswer,
                explanatoryCopy = quiz.ExplanatoryCopy,
                answers = quiz.Answers
                    .Select(
                        x =>
                            new AnswerDto()
                            {
                                id = x.Id,
                                tally = x.Tally,
                                percentage = quiz.Percentage(x),
                                answer = x.AnswerText
                            })
            };


    }

    class AnswerDto
    {
        public int id { get; set; }
        public int tally { get; set; }
        public int percentage { get; set; }
        public string answer { get; set; }

    }
}