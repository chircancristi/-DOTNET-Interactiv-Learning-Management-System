// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const courses = document.getElementsByClassName("course");
const rooms = document.getElementsByClassName("rooms");
const replys = document.getElementsByClassName("questions-answer__trigger");
const modal = document.getElementById("modalJS");
const modal_roomcode = document.getElementById("modalRoomcode")
const modalContainer = document.getElementById("containerJS");
const questionsContainer = document.getElementById("questions");
const closeRoom = document.getElementById("closeRoomJS");
document.getElementById("questionStudent").disabled = true;
document.getElementById("question").disabled = true;
let roomObj;
let parametersId;

for (let i = 0; i < courses.length; i++) {
    courses[i].addEventListener("click", function () {
        showRooms(courses[i]);
    })
}


function ShowReplies(question) {
    let id = question.id;
    var params = 'id=' + id;

    $.post('/StudentAnswers', params).done(function (response) {
        console.log(response);

        modal.style.display = "block";
        let content = response;

        modalContainer.innerHTML = " "
        modalContainer.innerHTML = "<div id='replyContentJS' class='modal-container__replyes'> </div >"
        const replyContentJS = document.getElementById("replyContentJS");
        let body = " ";
        replyContentJS.innerHTML = "";
        for (let i = 0; i < content.numberOfAnswers; i++)
            body = body + "<div class='answer'><h3 class='answer-author'>" + content.authors[i] + "</h3> <p class='answer-string'>" + content.answers[i] + "</p></div> "
        console.log(body);

        replyContentJS.innerHTML = body;
        body = " <form id='addAnswer' action='AddAnswer' method='post' class='modal-container__input'> <input for='answerProfessor' name='answerProfessor' id='answer'  class='chat-form__input chat-form__input--modal' type = 'text' name = 'answerProfessor' > <br><div class='buttons__container buttons__container--modal'><input class='chat-form__button' onclick='return SendAnswer()' type='submit' value='Submit'></div></form>"

        modalContainer.innerHTML = modalContainer.innerHTML + body;

    })

}

window.onclick = function (event) {
    if (event.target == modal || event.target == modal_roomcode) {
        modal.style.display = "none";
        modal_roomcode.style.display = "none";

    }
}

window.onload = function () {
    var objDiv = document.getElementById("questions");
    objDiv.scrollTop = objDiv.scrollHeight;
}
function SendAnswer() {
    let params = 'answer=' + $("#answer").val();

    $.post('/AddAnswerStudent', params).done(function (response) {
        const replyContentJS = document.getElementById("replyContentJS");
        let body = " ";
        body = body + "<div class='answer'><h3 class='answer-author'>" + response.answerAuthor + "</h3> <p class='answer-string'>" + response.answerContent + "</p></div> "

        replyContentJS.innerHTML = replyContentJS.innerHTML + body;
        var objDiv = document.getElementById("questions");
        objDiv.scrollTop = objDiv.scrollHeight;
        $("#answer").val("");

    });
    return false;
}
function SendQuestion() {

    let params = 'question=' + $("#question").val();

    $.post('/AddQuestionStudent', params).done(function (response) {
        var objDiv = document.getElementById("questions");

        let body = "<div class='question'> <h3 class='question-author'>" + response.questionAuthor + "</h3><p class=question-string'>" + response.questionContent + " </p><a class='questions-answer__trigger' id='" + response.questionId + "' href='#'> Vezi raspunsuri</a></div>"

        objDiv.innerHTML = objDiv.innerHTML + body;
        var objDiv = document.getElementById("questions");
        objDiv.scrollTop = objDiv.scrollHeight;
        $("#question").val("");
        for (let i = 0; i < replys.length; i++) {
            replys[i].removeEventListener("click", function () {
            });
            replys[i].addEventListener("click", function () {
                ShowReplies(replys[i]);
            })
        }

    });
    return false;
}

function showRooms(course) {
    const room = document.getElementById("room " + course.id);
    const arrow = document.getElementById(course.id + " arrow")

    if (room.style.display === "block") {
        room.style.display = "none";
        arrow.classList.remove('fa-arrow-down');
        arrow.classList.add('fa-arrow-up');
        course.style.backgroundColor = "#6CD6CE";

        questionsContainer.innerHTML = "<div class='question'> <h1 class='question-string' > Please select a course </h1 ></div >";
        document.getElementById("questionStudent").disabled = true;
        document.getElementById("question").disabled = true;
    }
    else {
        for (let i = 0; i < courses.length; i++) {
            document.getElementById("room " + courses[i].id).style.display = "none";
            document.getElementById(courses[i].id + " arrow").classList.remove('fa-arrow-down');
            document.getElementById(courses[i].id + " arrow").classList.add('fa-arrow-up');
            courses[i].style.backgroundColor = "#6CD6CE";
        }

        room.style.display = "block";
        arrow.classList.remove('fa-arrow-up');
        arrow.classList.add('fa-arrow-down');
        course.style.backgroundColor = "rgba(128, 128, 128, 0.6)";
        param = "id=" + course.id;
        $.post('/StudentEnterCourse', param).done(function (response) {
            let roomsContainer = document.getElementById("room " + course.id);
            roomsContainer.innerHTML = "";
            questionsContainer.innerHTML = "";
            let body = "";
            for (let i = 0; i < response.numberOfRooms; i++) {
             body = body+ "<div class='room'><span> Room "+  (i+1)  +"</span><button class='rooms' id="+response.roomsId[i] +">Join room</button ></div >";
            }
            roomsContainer.innerHTML = body;
            body = " ";
            for (let i = 0; i < response.numberOfQuestion; i++) {
                body = body+"<div class='question'><h3 class='question-author' >"+response.owners[i]+"</h3 ><p class='question-string'>"+ response.questionsContent[i]+" </p><a class='questions-answer__trigger' id='"+response.questionId[i]+"' href='#'> Vezi raspunsuri</a></div >"
            }
            questionsContainer.innerHTML = body;
            document.getElementById("questionStudent").disabled = false;
            document.getElementById("question").disabled = false;
            for (let i = 0; i < replys.length; i++) {
                replys[i].removeEventListener("click", function () {
                });
                replys[i].addEventListener("click", function () {
                    ShowReplies(replys[i]);
                })          
            }
            for (let i = 0; i < rooms.length; i++) {
                rooms[i].addEventListener("click", function () {
                    roomState(rooms[i]);                  
                })
            }
        });
    }
}

function roomState(room) {
    console.log(room.innerHTML)
    roomObj = room;
    if (room.innerHTML === "Join room") {

        let id = room.id;
        var params = 'id=' + id;
        $.post("/CheckRoomExpiration", params).done(function (response) {
            if (response.opened == false) {
                JoinRoom(id);
            }
            else {

                modal_roomcode.style.display = "block";  
                parametersId = id;
            }
        });
   }
    else {
        $.post('/LeaveRoomStudent').done(function (response) {
            var objDiv = document.getElementById("questions");

            console.log(response);
            objDiv.innerHTML = "";
            let body = " ";
            for (let i = 0; i < response.numberOfQuestion; i++) {
                body = body + "<div class='question'> <h3 class='question-author'>" + response.questionAuthor[i] + "</h3><p class=question-string'>" + response.questionContent[i] + " </p><a class='questions-answer__trigger' id='" + response.questionId[i] + "' href='#'> Vezi raspunsuri</a></div>"
            }
            console.log(body);
            objDiv.innerHTML = body;

            objDiv.scrollTop = objDiv.scrollHeight;
            closeRoom.style.display = "none";
            room.innerHTML = "Join room";

        })
    }
        
}
function CheckToken()
{
  
    
    $.post('/CheckToken', { token: $("#token").val(), id: parametersId } ).done(function (response) {
        $("#token").val("");
        if (response.valid == true) {
            JoinRoom(parametersId);
            modal_roomcode.style.display = "none"; 
        }
        else
        {
            document.getElementById("tokenButton").value = "Token gresit";
        }
       
    });
    return false;

}
function JoinRoom(id)
{
    params = "id=" + id;
    $.post('/JoinRoomStudent', params).done(function (response) {
        var objDiv = document.getElementById("questions");

        console.log(response);
        objDiv.innerHTML = "";
        let body = " ";
        for (let i = 0; i < response.numberOfQuestion; i++) {
            body = body + "<div class='question'> <h3 class='question-author'>" + response.questionAuthor[i] + "</h3><p class=question-string'>" + response.questionContent[i] + " </p><a class='questions-answer__trigger' id='" + response.questionId[i] + "' href='#'> Vezi raspunsuri</a></div>"
        }
        console.log(body);
        objDiv.innerHTML = body;

        for (let i = 0; i < replys.length; i++) {
            replys[i].removeEventListener("click", function () {
            });
            replys[i].addEventListener("click", function () {
                ShowReplies(replys[i]);
            })
        }

        closeRoom.style.display = "Block";
        for (let j = 0; j < rooms.length; j++)
            rooms[j].innerHTML = "Join room";
        roomObj.innerHTML = "Leave room";

        objDiv.scrollTop = objDiv.scrollHeight;
    })
}