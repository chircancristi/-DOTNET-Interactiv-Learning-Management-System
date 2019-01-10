using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Models;

namespace TestModule
{
    public class AnswerTests
    {
        private Answer _Answer = new Answer(new Guid(),  new Guid(), "Bine", "professor");
        InteractionModel interaction = new InteractionModel();

        [Fact]
        private void When_AnswerIsInitialized_IsCreatedSuccessfully()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Answer.Content == "Bine");
        }

        [Fact]
        private void When_GetAllAnswers_IsCalled_ReturnAllAnswers()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(interaction.GetAllAnswers().Count == 3);
        }


    }
}
