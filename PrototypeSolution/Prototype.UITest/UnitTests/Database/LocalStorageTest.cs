﻿using NUnit.Framework;
using Prototype.Database;
using Prototype.ModelControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.UITest.UnitTests.Database
{
    [TestFixture]
    public class LocalStorageTest
    {
        [Test]
        public void SerializeToJson()
        {
            //prepare
            StateController stateController = new StateController();

            //act


            //assert
            Assert.DoesNotThrow(() => LocalStorage.SerializeToJson(stateController));
        }

        [Test]
        public void DeserializeFromJson()
        {
            //prepare
            string str = "serialize me";
            string strSerialized = LocalStorage.SerializeToJson(str);

            //act
            string strDeserialized = LocalStorage.DeserializeFromJson<string>(strSerialized);

            //assert
            Assert.IsTrue(str.Equals(strDeserialized));
        }
    }
}
