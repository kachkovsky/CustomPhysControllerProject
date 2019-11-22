using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityEngine;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {

        //[TestMethod]
        //public void TestMethodABS() {
        //    float f = 0f;
        //    while (f < 1000000f) {
        //        float fp= Mathf.Sqrt(f);
        //        float f1 = fp * fp;
        //        fp = Mathf.Sqrt(fp);
        //        float f2 = fp * fp * fp * fp;
        //        //Console.WriteLine(f1 - f2);
        //        float eps = 1e-6f;
        //        bool err = false;
        //        if (!(Math.Abs(f1 - f2) < eps)) {
        //            Console.WriteLine("1:"+f);
        //            err = true;
        //        }
        //        if (!(f1 - f2 < eps)) {
        //            Console.WriteLine("2:" + f);
        //            err = true;
        //        }
        //        if (!(f2 > f1 - eps)) {
        //            Console.WriteLine("3:" + f);
        //            err = true;
        //        }
        //        err = false;
        //        if (err) {
        //            Console.WriteLine(f1);
        //            Console.WriteLine(f2);
        //            Console.WriteLine(f1 - f2);
        //        }
        //        //Assert.IsTrue(f1 -f2 < float.Epsilon);
        //        ////Assert.IsTrue(f2 > f1 - float.Epsilon);
        //        //Assert.IsTrue(Math.Abs(f1 - f2) < float.Epsilon);
        //        f += 1000f;
        //    }

        //    Vector3 v = new Vector3();
        //    Vector3 v2 = new Vector3(2, 2, 2);
        //    Assert.AreEqual(2, v.RetrieveAdditionByIndexLimited(v2, 0, -10, 10));
        //}

        [TestMethod]
        public void TestMethod1() {

            Vector3 v = new Vector3();
            Vector3 v2 = new Vector3(2, 2, 2);
            Assert.AreEqual(2, v.RetrieveAdditionByIndexLimited(v2, 0, -10, 10));
        }

        [TestMethod]
        public void TestMethod12() {
            Vector3 v = new Vector3();
            Vector3 v2 = new Vector3(11, 2, 2);
            Assert.AreEqual(10, v.RetrieveAdditionByIndexLimited(v2, 0, -10, 10));
        }

        [TestMethod]
        public void TestMethod13() {
            Vector3 v = new Vector3(11, 1);
            Vector3 v2 = new Vector3(2, 2, 2);
            Assert.AreEqual(0, v.RetrieveAdditionByIndexLimited(v2, 0, -10, 10));
        }

        [TestMethod]
        public void TestMethod14() {
            Vector3 v = new Vector3(11, 1);
            Vector3 v2 = new Vector3(-2, 2, 2);
            Assert.AreEqual(-2, v.RetrieveAdditionByIndexLimited(v2, 0, -10, 10));
        }

        [TestMethod]
        public void TestMethod15() {
            Vector3 v = new Vector3(3.7f, 1f, 1f);
            Vector3 v2 = new Vector3(20, 2, 2);
            Assert.AreEqual(16.3f, v.RetrieveAdditionByIndexLimited(v2, 0, -20, 20));
        }

        [TestMethod]
        public void TestMethod16() {
            Vector3 v = new Vector3(13.7f, 1f, 1f);
            Vector3 v2 = new Vector3(11f, 2, 2);
            Assert.AreEqual(6.3f, v.RetrieveAdditionByIndexLimited(v2, 0, -20, 20));
        }

        [TestMethod]
        public void TestMethod17() {
            Vector3 v = new Vector3(20.0f, 1f, 1f);
            Vector3 v2 = new Vector3(20.0f, 2, 2);
            Assert.AreEqual(0f, v.RetrieveAdditionByIndexLimited(v2, 0, -20, 20));
        }
    }

}
