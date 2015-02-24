    $(function() {
        $('#quiz input[type=radio]').change(function() {
            var answer = $(this).val();
            var quiz = $(this).closest('form').find('input[name=QuizId]').val();


            $.getJSON('/umbraco/api/quiz/Get',
               { quizId: quiz, answerId: answer },
               function (data) {
                   $('#answer-copy').html(data.explanatoryCopy);
                   var list = $('#answers-list');
                   list.addClass('list-unstyled');
                   if (data.isPoll) {
                       $.each(data.answers, function(i, result) {
                           var item = $('<li></li>');
                           item.text(result.percentage + '% - ' + result.answer);
                           list.append(item);
                       });
                   } else {
                        $('#quiz-result').html(data.correct ? "<span style='color:#00aeef;'>" + data.copy + "</span>" : "<span style='color:#9c3022;'>" + data.copy + "</span>");
                       list.append('<li><span class="stat">' + data.percentageCorrect + '%</span><span class="small text-uppercase">Correct</span></li>');
                       list.append('<li><span class="stat">' + data.percentageIncorrect + '%</span><span class="small text-uppercase">Incorrect</span></li>');
                   }

                   $('.qa_question').fadeOut(function() {
                       $('.qa_answer').fadeIn();
                       $('.qa-q, .qa-a').toggleClass('on');
                   });

               });

        });
    });