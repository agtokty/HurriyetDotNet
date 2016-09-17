using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HurriyetDotNet.Auth;
using HurriyetDotNet.Client;
using HurriyetDotNet.Models;

namespace HurriyetDotNet.Test
{
    [TestClass]
    public class WriterTest
    {
        

        [TestMethod]
        public void GetWriter()
        {
            Authentication auth = new Authentication(TestConstants.apiKey);
            HurriyetClient client = new HurriyetClient(auth);

            Writer w = client.Writers.GetWriter("570167e867b0a90bdc503452");

            Assert.IsNotNull(w);
            Assert.IsTrue(w.FullName == "Abdulkadir SELVİ");
        }

        [TestMethod]
        public void GetWriterByName()
        {
            Authentication auth = new Authentication(TestConstants.apiKey);
            HurriyetClient client = new HurriyetClient(auth);

            Writer w = client.Writers.GetWriterByName("Abdulkadir SELVİ");

            Assert.IsNotNull(w);
            Assert.IsTrue(w.FullName == "Abdulkadir SELVİ");
        }
    }
}
