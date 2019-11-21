using EdiFileProcess.Models.EdiFact;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace EdiFileProcess.UnitTest {
    [TestClass]
    public class UnitTestDESADV {
        [TestMethod]
        public void First() {
            try {
                EdiFactDesadvModel objectType = null;
                using (Stream stream = File.OpenRead("DESADV_02.edi")) {
                    objectType = new EdiFactDeserialize().Deserialize<EdiFactDesadvModel>(new StreamReader(stream));
                }
                Assert.IsTrue(true);
            }
            catch {
                Assert.IsTrue(false);
            }
        }
    }
}


