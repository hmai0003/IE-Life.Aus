(function () {
    let allQuestions = [{
        question: "What is your country of origin?",
        options: ["India", "China", "England", "Other countries"],
        answer: 2,
        info: "no info",
        picture: ""
    }, {
        question: "Which statement does not belong to Australian drinking culture?",
        options: ["People sometimes relax with alcohol.", "Alcohol can occur in some social situations.",
                "Drinking is never allowed.", "Alcohol provides opportunities for employment."],
        answer: 2,
        info: "Alcohol plays an important role in Australian culture. It usually appears in social activities, celebrations, and people's daily relaxation. At the same time, alcohol also provides tremendous power in terms of taxes and job opportunities.",
        picture: ""
    }, {
        question: "What is the legal drinking age in Australian? ",
        options: ["21", "18", "16", "14"],
        answer: 1,
        info: "The legal drinking age in Australia is 18 years old, so if you are visiting from a legally older country, you might be drinking the first cup here.",
            picture: "../Images/legalAge.png"
    }, {
        question: "Name a high risk of mental health disorder due to heavy drinking. ",
        options: ["Intermittent explosive disorder", "Dysthymia (persistent, mild depression)",
                "Oppositional defiant disorder", "Bipolar disorder"],
        answer: 0,
        info: "Frequent heavy drinking can cause many mental health problems, but the risk of being most affected by alcohol is Intermittent explosive disorder. In addition, there are other diseases that may be caused by alcohol on the table.",
        picture: ""
    }, {
        question: "Which one is the effect of heavy drinking on the brain?",
        options: ["Learning ability decline", "Reduced memory", "Poor balance ability", "All the above"],
        answer: 3,
        info: "The brain of adolescents is still in the developmental stage. Drinking at this stage will affect the mood, sleep and other aspects of adolescents, which will further lead to memory, learning ability and motor skill weakness, and even lead to incomplete brain development.",
        picture: "../Images/brain.jpg"
    }, {
        question: "Which is the most occurring crime incidents in Melbourne?",
        options: ["Breach bail conditions", "Drug use", "Drunk and disorderly in public", "Begging"],
        answer: 2,
            info: "2649 Crime Incidents recorded for Drunk and Disorderly in Public, which is highest in Melborune CBD as compared to other suburbs.",
        picture: ""
    }, {
        question: "Which is not a good way to say “no” to your friends when they persuade you to drink?",
        options: ["“I’m driving.” ", "“I’ve got to get up early tomorrow.”", "“I do not want to drink with you.”",
                "“I’ve reached my limit for tonight.”"],
        answer: 2,
        info: "The desire to refuse a friend or family member to ask you to drink is difficult when you live in Australia. However, you can reject them by these several methods and will not earn strange looks.",
        picture: ""
    }];

    var quesCounter = 0;
    var selectOptions = [];
    var quizSpace = $('#quiz');
    var data = $('#viz1566969250254'); 
    nextQuestion();

    $('#next').click(function () {
        chooseOption();
        if (isNaN(selectOptions[quesCounter])) {
            alert('Please select an option !');
        }
        else if (quesCounter !== 0 & 5) {
            displayInfo();
        }
        else {
            quesCounter++;
            nextQuestion();
        }
    });

    $('#nextQues').click(function () {
        quesCounter++;
        nextQuestion();
    });

    $('#prev').click(function () {
        chooseOption();
        quesCounter--;
        nextQuestion();
    });

    function presentInfo(index) {
        var information = $('<div>', { id: 'info' });

        if (selectOptions[quesCounter] === allQuestions[index].answer) {
            var ans = $('<h2>Your answer is correct!</h2>', { id: 'correct' });
            information.append(ans);
        }
        else {
            ans = $('<h2>Wrong!</h2>', { id: 'wrong' });
            //document.getElementById("wrong").style.fgColor = "red";
            information.append(ans);
        }
       
        var text = $('<p>').append(allQuestions[index].info);
        information.append(text);

        if (quesCounter === 3) {
            information.append(data).fadeIn();
        }

        if (allQuestions[index].picture.length !== 0) {
            var picSrc = allQuestions[index].picture;
            var pic = $('<img>', { src: picSrc, class: 'img-fluid' });
            information.append(pic);
        }

        return information;
    }

    function displayInfo() {
        quizSpace.fadeOut(function () {
            $('#question').remove();
            var displayInfo = presentInfo(quesCounter);
            quizSpace.append(displayInfo).fadeIn();         
            $('#next').hide();
            $('#prev').hide();
            $('#nextQues').show();      
        });
           
    }

    function createElement(index) {
        var element = $('<div>', { id: 'question' });
        var header = $('<h2>Question No. ' + (index + 1) + ' :</h2>');
        element.append(header);

        var question = $('<p>').append(allQuestions[index].question);
        element.append(question);

        var radio = radioButtons(index);
        element.append(radio);

        return element;
    }

    function radioButtons(index) {
        var radioItems = $('<ul>', { style: '~/Content/quiz.css' });
        var item;
        var input = '';
        for (var i = 0; i < allQuestions[index].options.length; i++) {
            item = $('<li>', { style: '~/Content/quiz.css' });
            input = '<input type="radio" name="answer" value=' + i + ' />';
            input += allQuestions[index].options[i];
            item.append(input);
            radioItems.append(item);
        }
        return radioItems;
    }

    function chooseOption() {
        selectOptions[quesCounter] = +$('input[name="answer"]:checked').val();
    }

    function nextQuestion() {
        data.remove();
        quizSpace.fadeOut(function () {
            $('#question').remove();
            $('#info').remove();
            //data.remove();
     
            if (quesCounter < allQuestions.length) {
                var nextQuestion = createElement(quesCounter);
                quizSpace.append(nextQuestion).fadeIn();
                $('#flipcard').show();
                if (!(isNaN(selectOptions[quesCounter]))) {
                    $('input[value=' + selectOptions[quesCounter] + ']').prop('checked', true);
                }
                if (quesCounter === 1) {
                    $('#prev').show();
                    $('#nextQues').hide();
                }
                else if (quesCounter === 0) {
                    $('#prev').hide();
                    $('#next').show();
                    $('#nextQues').hide();
                }
                else {
                    $('#prev').show();
                    $('#next').show();
                    $('#nextQues').hide();
                }
            }
            else {
                var scoreRslt = displayResult();
                quizSpace.append(scoreRslt).fadeIn();
                $('#next').hide();
                $('#prev').hide();
                $('#nextQues').hide();
            }
        });
    }

    function displayResult() {
        var score = $('<p>', { id: 'question' });
        var correct = 0;
        for (var i = 0; i < selectOptions.length; i++) {
            if (selectOptions[i] === allQuestions[i].answer) {
                correct++;
            }
        }
        score.append('You scored ' + correct + ' out of ' + allQuestions.length);
        //var sum = $('<h2>Summary:</h2>');
        //score.append(sum);
        //var firstP = $('<p>Alcohol plays a significant role in Australian social activities and relaxation. Going out for a drink to celebrate with friends or family is quite common. Alcohol generates a certain amount of tax revenue, also helps with employment and exports. Lots of young people are quite happy to drink or to get drunk. Due to the elevated cost of alcohol purchased at venues, many people are used to pre-drinking (i.e. consuming a large amount of alcohol before reaching public venues for socialising). In Australia, alcohol is the second leading preventable cause of death and hospitalisation after tobacco.</p>');
        //score.append(firstP);
        //var secondP = $('<p>Alcohol causes you more likely to get cancer, diabetes, liver cirrhosis, and high blood pressure. Your odds of injury by accident or violence will be increased as well. The risk of a driver with 0.05 blood alcohol concentration (BAC) suffering a road crash is about double compared with the ones with zero BAC. Generally, females, smaller people, and people with more body fat will have a higher BAC. Drinking and taking drugs/medications at the same time may also affect awareness. On average, approximately 40% of prisoners imprisoned for violent crimes are affected by alcohol during the crime. Many of the criminals are estimated to have a BAC more than three times the legal limit at the time of their arrest.</p>');
       // score.append(secondP);
        //var thirdP = $('<p>On average, approximately 40% of prisoners imprisoned for violent crimes are affected by alcohol during the crime. Many of the criminals are estimated to have a BAC more than three times the legal limit at the time of their arrest. Around 20% of Australian people consider alcohol as a   consumption. Moreover, Australians who live in the urban have more serious drinking issues compared to those who live in the suburbs. Some local governments prohibit alcohol on designated streets, parks, and other areas within their jurisdictions. For the offences related to underage drinking, an on-the-spot fine or a summons to appear in court might be issued. </p>');
        //score.append(thirdP);
        return score;
    }
})();