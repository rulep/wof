using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LeapWoF.Interfaces;
using System;

namespace LeapWoF.Tests
{
    [TestClass]
    public class GameManagerTests
    {
        private Mock<IInputProvider> mockInputProvider = new Mock<IInputProvider>(MockBehavior.Strict);
        private Mock<IOutputProvider> mockOutputProvider = new Mock<IOutputProvider>(MockBehavior.Strict);

        private GameManager gm;

        [TestInitialize]
        public void Init()
        {
            mockInputProvider.Setup(x => x.Read()).Returns("a");
            mockOutputProvider.Setup(x => x.Write(It.IsAny<string>())).Verifiable();

            gm = new GameManager(mockInputProvider.Object,
                mockOutputProvider.Object);
        }

        [TestMethod] 
        public void TestGrabWord()
        {
            var word = gm.GrabWord();
            Assert.IsInstanceOfType(word, typeof(string));
        }
    }
}
