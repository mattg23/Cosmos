﻿using System;

namespace Cosmos.TestRunner
{
    public static class Assert
    {
        public static void IsTrue(bool condition, string message)
        {
            if (condition)
            {
                TestController.Debugger.Send("Assertion succeeded:");
                TestController.Debugger.Send(message);
                TestController.AssertionSucceeded();
            }
            else
            {
                TestController.Debugger.Send("Assertion failed!:");
                TestController.Debugger.Send(message);
                TestController.Failed();
                throw new Exception("Assertion failed!");
            }
        }

        public static void AreEqual(int expected, int actual, string message)
        {
            var xResult = expected == actual;
            if (!xResult)
            {
                TestController.Debugger.SendNumber("TestAssertion", "Expected", (uint)expected, 32);
                TestController.Debugger.SendNumber("TestAssertion", "Actual", (uint)actual, 32);
            }
            IsTrue(xResult, message);
        }
    }
}
