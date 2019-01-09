// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

    const courses = document.getElementsByClassName("course");
    const rooms = document.getElementsByClassName("rooms");
    const replys = document.getElementsByClassName("questions-answer__trigger");
    const modal = document.getElementById("modalJS");
    const addRoom = document.getElementById("addRoomJS");
    const modalContainer = document.getElementById("containerJS");
    const roomsContainer = document.getElementById("roomsContainer");
    const closeRoom = document.getElementById("closeRoomJS");
    addRoom.addEventListener("click", function () {

        $.post('/AddRoom').done(function (response) {
            let body = "<div class='room'> <span>Room " + response.number + "</span> <button class='rooms' id=" + response.id + ">Join room</button> </div>";
            roomsContainer.innerHTML = roomsContainer.innerHTML + body;
            for (let i = 0; i < rooms.length; i++) {
                rooms[i].removeEventListener("click", function () {
                });
                rooms[i].addEventListener("click", function () {
                    RoomState(rooms[i])
                })
            }        
        })
    })
    for (let i = 0; i < courses.length; i++) {
        courses[i].addEventListener("click", function () {
            showRooms(courses[i]);
        })
    }

    for (let i = 0; i < replys.length; i++) {
        replys[i].addEventListener("click", function () {

            let id = replys[i].id;
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
                for (let i = 0; i < content.numberOfAnswers; i++)
                    body = body + "<div class='answer'><h3 class='answer-author'>" + content.authors[i] + "</h3> <p class='answer-string'>" + content.answers[i] + "</p></div> "
                console.log(body);

                replyContentJS.innerHTML = body;
                body = " <form id='postAnswer' method='post' class='modal-container__input'> <input for='answerProfessor' name='answerProfessor'  class='chat-form__input chat-form__input--modal' type = 'text' name = 'answerProfessor' > <br><div class='buttons__container buttons__container--modal'><input class='chat-form__button' type='submit' value='Submit'></div></form>"

                modalContainer.innerHTML = modalContainer.innerHTML + body;

            })

        })
    }

    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }   
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


                closeRoom.style.display = "Block";
                for (let j = 0; j < rooms.length; j++)
                    rooms[j].innerHTML = "Join room";
                room.innerHTML = "Leave room";

                objDiv.scrollTop = objDiv.scrollHeight;
            })

        }
        else {
            $.post('/CloseRoom').done(function (response) {
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
    for (let i = 0; i < rooms.length; i++) {
        rooms[i].addEventListener("click", function () {
            RoomState(rooms[i])
        })
    }
   


var xhr = new XMLHttpRequest();
xhr.onreadystatechange = function () {
    if (xhr.readyState == 4)
        if (xhr.status == 200) {
            var response = xhr.responseText;
            if (response.type === "question") {
                var objDiv = document.getElementById("questions");

                let  body = "<div class='question'> <h3 class='question-author'>" + response.questionAuthor + "</h3><p class=question-string'>" + response.questionContent + " </p><a class='questions-answer__trigger' id='" + response.questionId + "' href='#'> Vezi raspunsuri</a></div>"
                
                objDiv.innerHTML = objDiv.innerHTML+body;

            }
            if (reponse.type === "answer") {
                const replyContentJS = document.getElementById("replyContentJS");
                let body = " ";
                body = body + "<div class='answer'><h3 class='answer-author'>" + content.authors + "</h3> <p class='answer-string'>" + content.answers + "</p></div> "
                console.log(body);

                replyContentJS.innerHTML = replyContentJS.innerHTML + body;
            }
         }
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
window.onload = function () {
    var objDiv = document.getElementById("questions");
    objDiv.scrollTop = objDiv.scrollHeight;
}