﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const courses = document.getElementsByClassName("course");
const rooms = document.getElementsByClassName("rooms");
const replys = document.getElementsByClassName("questions-answer__trigger");
const modal = document.getElementById("modalJS");
const modal_roomcode = document.getElementById("modalRoomcode")
const questionsContainer = document.getElementById("questions");
document.getElementById("questionStudent").disabled = true;
document.getElementById("question").disabled = true;
for (let i = 0; i < courses.length; i++) {
    courses[i].addEventListener("click", function () {
        showRooms(courses[i]);
    })
}

for (let i = 0; i < replys.length; i++) {
    replys[i].addEventListener("click", function () {
        modal.style.display = "block";
        let id = replys[i].id;
        $.post("/professorAnswers", { id: id });
    })
}
window.onclick = function (event) {
    if (event.target == modal || event.target == modal_roomcode) {
        modal.style.display = "none";
        modal_roomcode.style.display = "none";

    }
}
for (let i = 0; i < rooms.length; i++) {
    rooms[i].addEventListener("click", function () {

        if (rooms[i].innerHTML === "Join room") {

            modal_roomcode.style.display = "block";

            for (let j = 0; j < rooms.length; j++)
                rooms[j].innerHTML = "Join room";
            rooms[i].innerHTML = "Leave room";

        }
        else {
            rooms[i].innerHTML = "Join room";
        }
    })
}
window.onload = function () {
    var objDiv = document.getElementById("questions");
    objDiv.scrollTop = objDiv.scrollHeight;
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
             body = body+ "<div class='room'><span> Room "+  i+1  +"</span><button class='rooms' id="+response.roomsId[i] +"> Join room</button ></div >";
            }
            roomsContainer.innerHTML = body;
            body = " ";
            for (let i = 0; i < response.numberOfQuestion; i++) {
                body = body+"<div class='question'><h3 class='question-author' >"+response.owners[i]+"</h3 ><p class='question-string'>"+ response.questionsContent[i]+" </p><a class='questions-answer__trigger' id='"+response.questionId[i]+"' href='#'> Vezi raspunsuri</a></div >"
            }
            questionsContainer.innerHTML = body;
            document.getElementById("questionStudent").disabled = false;
            document.getElementById("question").disabled = false;
        });
    }
}