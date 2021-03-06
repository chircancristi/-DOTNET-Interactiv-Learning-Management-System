﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const courses = document.getElementsByClassName("course");
const rooms = document.getElementsByClassName("rooms");
const replys = document.getElementsByClassName("questions-answer__trigger");
const modal = document.getElementById("modalJS");
const addRoom = document.getElementById("addRoomJS");
const modalContainer = document.getElementById("containerJS");
const roomsContainer = document.getElementById("roomsContainer");
const closeRoom = document.getElementById("closeRoomJS");
const questionProfessor = document.getElementById("questionProfessor");
const bestAnswerButton = document.getElementsByClassName("best-answer");

window.onload = function () {
    var objDiv = document.getElementById("questions");
    objDiv.scrollTop = objDiv.scrollHeight;
}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
for (let i = 0; i < courses.length; i++) {
    courses[i].addEventListener("click", function () {
        showRooms(courses[i]);
    })
}

for (let i = 0; i < replys.length; i++) {
    replys[i].addEventListener("click", function () {
        ShowReplies(replys[i]);
    })
}
for (let i = 0; i < rooms.length; i++) {
    rooms[i].addEventListener("click", function () {
        RoomState(rooms[i])
    })
}

addRoom.addEventListener("click", function () {

    $.post('/AddRoom').done(function (response) {
        let body = "<div class='room'> <span>Room " + response.number + " - "+ response.token +"</span> <button class='rooms' id=" + response.id + ">Join room</button> </div>";
        roomsContainer.innerHTML = roomsContainer.innerHTML + body;
        for (let i = 0; i < rooms.length; i++) {
            rooms[i].removeEventListener("click", function () {
            });
            rooms[i].addEventListener("click", function () {
                RoomState(rooms[i]);
            })
        }        
    })
})
function closeRoomFunction() {
    
    $.post('/CloseRoom').done(function (response) {

        let roomContent = document.getElementById(response.id).innerText;
        

        var roomSpan = document.getElementById(response.id).parentNode.children;
        var partsArray = roomSpan[0].innerText.split(' ');
        roomSpan[0].innerText=partsArray[0] + ' ' + partsArray[1];
    })
    return false;
}

function ShowReplies(question) {
    let id = question.id;
    var params = 'id=' + id;

    $.post('/ProfessorAnswers', params).done(function (response) {
        console.log(response);

        modal.style.display = "block";
        let content = response;

        modalContainer.innerHTML = " "
        modalContainer.innerHTML = "<div id='replyContentJS' class='modal-container__replyes'> </div >"
        const replyContentJS = document.getElementById("replyContentJS");
        let body = " ";
        replyContentJS.innerHTML = "";
        console.log(content.inRoom);
        for (let i = 0; i < content.numberOfAnswers; i++)
            if (content.inRoom === false)
                body = body + "<div class='answer'><h3 class='answer-author'>" + content.authors[i] + "</h3> <p class='answer-string'>" + content.answers[i] + "</p></div> "
            else
            {
                if (content.bestAnswerPosition == i) {
                    body = body + "<div class='answer'><h3 class='answer-author'>" + content.authors[i] + "</h3> <p class='answer-string'>" + content.answers[i] + "</p> <button id='" + content.answersIds[i] + "' class='chat-form__button best-answer'>Cel mai bun raspuns</button></div> "
                }
                else {
                    body = body + "<div class='answer'><h3 class='answer-author'>" + content.authors[i] + "</h3> <p class='answer-string'>" + content.answers[i] + "</p> <button id='" + content.answersIds[i] + "' class='chat-form__button best-answer'>Selecteaza raspunsul</button></div> "
                }
            }
        
        

        replyContentJS.innerHTML = body;
        body = " <form id='addAnswer' action='AddAnswer' method='post' class='modal-container__input'> <input for='answerProfessor' name='answerProfessor' id='answer'  class='chat-form__input chat-form__input--modal' type = 'text' name = 'answerProfessor' > <br><div class='buttons__container buttons__container--modal'><input class='chat-form__button' onclick='return SendAnswer()' type='submit' value='Submit'></div></form>"

        modalContainer.innerHTML = modalContainer.innerHTML + body;
        if (content.inRoom === true) {

            console.log(bestAnswerButton);
            for (let i = 0; i < bestAnswerButton.length; i++) {
                bestAnswerButton[i].addEventListener("click", function () {
                    setBestAnswer(bestAnswerButton[i]);
                })
            }
        }
    })
}
function setBestAnswer(answer)
{
    var params = 'id=' + answer.id;

    $.post('/SetBestAnswer', params).done(function (response) {
        for (let i = 0; i < bestAnswerButton.length; i++) {
            bestAnswerButton[i].innerText = "Selecteaza raspunsul";
        }
        answer.innerText = "Cel mai bun raspuns";
    })
}
function RoomState(room)    
{
    if (room.innerHTML === "Join room") {

        let id = room.id;
        var params = 'id=' + id;

        $.post('/JoinRoom', params).done(function (response) {
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
            room.innerHTML = "Leave room";

            objDiv.scrollTop = objDiv.scrollHeight;
        })

    }
    else {
        $.post('/LeaveRoom').done(function (response) {
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
            for (let i = 0; i < replys.length; i++) {
                replys[i].removeEventListener("click", function () {
                });
                replys[i].addEventListener("click", function () {
                    ShowReplies(replys[i]);
                })
            }
        })
    }
}


function SendQuestion() {
   
    let params = 'question=' + $("#question").val();
   
    $.post('/AddQuestion', params).done(function (response) {
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
function SendAnswer() {
    let params = 'answer=' + $("#answer").val();

    $.post('/AddAnswer', params).done(function (response) {
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

function showRooms(course) {
    const courses = document.getElementsByClassName("course");
    const room = document.getElementById("room " + course.id);
    const arrow = document.getElementById(course.id + " arrow")

    if (room.style.display === "block") {
        room.style.display = "none";
        arrow.classList.remove('fa-arrow-down');
        arrow.classList.add('fa-arrow-up');
        course.style.backgroundColor = "#6CD6CE";

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
    }
}
