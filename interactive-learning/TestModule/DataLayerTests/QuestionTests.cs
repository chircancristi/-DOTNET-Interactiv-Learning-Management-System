using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestModule
{
    public class QuestionTests
    {
        private Question _Question = new Question(new Guid(), new Guid(),"profesor" ,"Bine");

        [Fact]
        private void When_QuestionIsInitialized_IsCreatedSuccessfully()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Question.Content == "Bine");
        }

    }
}
