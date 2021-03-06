﻿using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestModule.DataBaseTests
{
   public class DataBase
    {
        public IUnitOfWork MyUnitOfWork = new UnitOfWork();
        public Student student1 = new Student("Alex", "Stoica");
        public Student student2 = new Student("Tudor", "Melnic");

        public Profesor profesor = new Profesor();

        public Course course;

        public  Room room;

        public Question question1;
        public Question question2;

        public Answer answer1;
        public Answer answer2;

        public DataBase()
        {
            course = new Course("Dotnet", profesor.Id);

            room = new Room(course.Id, profesor.Id);

            question1 = new Question(student1.Id, room.Id, "student", "Se da cursul asta in sesiune?");
            question2 = new Question(student2.Id, room.Id, "student", "Putem pleca?");

            answer1 = new Answer(profesor.Id, question1.Id, "Nu", "professor");
            answer2 = new Answer(profesor.Id, question2.Id, "Nu", "professor");


            MyUnitOfWork.StudentRepository.Add(student1);
            MyUnitOfWork.StudentRepository.Add(student2);

            MyUnitOfWork.ProfesorRepository.Add(profesor);

            MyUnitOfWork.CourseRepository.Add(course);
            MyUnitOfWork.RoomRepository.Add(room);

            MyUnitOfWork.QuestionRepository.Add(question1);
            MyUnitOfWork.QuestionRepository.Add(question2);

            MyUnitOfWork.AnswerRepository.Add(answer1);
            MyUnitOfWork.AnswerRepository.Add(answer2);

            MyUnitOfWork.Commit();

        }
    }
}
