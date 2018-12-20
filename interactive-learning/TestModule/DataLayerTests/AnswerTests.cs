using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestModule
{
    public class AnswerTests
    {
        private Answer _Answer = new Answer(new Guid(),  new Guid(),"Bine");

        [Fact]
        private void When_AnswerIsInitialized_IsCreatedSuccessfully()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_Answer.Content == "Bine");
        }
        

    }
}
