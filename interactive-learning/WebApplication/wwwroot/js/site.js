// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const courses = document.getElementsByClassName("course");
const rooms = document.getElementsByClassName("rooms");
const replys = document.getElementsByClassName("questions-answer__trigger");
const modal = document.getElementById("modalJS");
const replyContentJS = document.getElementById("replyContentJS");
var http = new XMLHttpRequest();
 

for (let i = 0; i < courses.length; i++) {
    courses[i].addEventListener("click", function () {
        showRooms(courses[i]);
    })
}

for (let i = 0; i < replys.length; i++) {
    replys[i].addEventListener("click", function () {
       
        let id = replys[i].id;
        
        var url = 'ProfessorAnswers';
        var params = 'id='+id;
        
        $.post('/ProfessorAnswers', params).done(function (response)
        {
            console.log(response);
            modal.style.display = "block";
            let content = response;

           

            let body = " ";
           
          
            for (let i = 0; i < content.numberOfAnswers; i++)
                body = body + "<div class='answer'><h3 class='answer-author'>" + content.authors[i] + "</h3> <p class='answer-string'>" + content.answers[i] + "</p></div> "
            console.log(body);
            replyContentJS.innerHTML = body;

        })
        
    })
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
for (let i = 0; i < rooms.length; i++) {
    rooms[i].addEventListener("click", function () {
       
        if (rooms[i].innerHTML === "Join room")
        {
            
            for (let j = 0; j < rooms.length; j++)
                rooms[j].innerHTML = "Join room";
            rooms[i].innerHTML = "Leave room";
           
            
        }
        else
        {
            rooms[i].innerHTML = "Join room";
        }
    })
}
window.onload = function () {
    var objDiv = document.getElementById("questions");
    objDiv.scrollTop = objDiv.scrollHeight;
}

function showRooms(course) {
    const room = document.getElementById("room" + course.id);
    const arrow = document.getElementById(course.id + "arrow")

    if (room.style.display === "block") {
        room.style.display = "none";
        arrow.classList.remove('fa-arrow-down');
        arrow.classList.add('fa-arrow-up');
        course.style.backgroundColor = "#6CD6CE";

    }
    else {
        for (let i = 0; i < courses.length; i++) {
            document.getElementById("room" + courses[i].id).style.display = "none";
            document.getElementById(courses[i].id + "arrow").classList.remove('fa-arrow-down');
            document.getElementById(courses[i].id + "arrow").classList.add('fa-arrow-up');
            courses[i].style.backgroundColor = "#6CD6CE";
        }

        room.style.display = "block";
        arrow.classList.remove('fa-arrow-up');
        arrow.classList.add('fa-arrow-down');
        course.style.backgroundColor = "rgba(128, 128, 128, 0.6)";
    }
}