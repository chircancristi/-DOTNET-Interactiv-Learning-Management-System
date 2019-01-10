using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Models;

namespace TestModule
{
    public class QuestionTests
    {
        private Question _Question = new Question(new Guid(), new Guid(),"profesor" ,"Bine");
        InteractionModel interaction = new InteractionModel();

        [Fact]
        private void When_QuestionIsInitialized_IsCreatedSuccessfully()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Question.Content == "Bine");
        }

        [Fact]
        private void When_GetAllQuestions_IsCalled_ReturnAllQuestions()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(interaction.GetAllQuestions().Count == 7);
        }

    }
}
