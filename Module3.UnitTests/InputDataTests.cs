﻿using NUnit.Framework;
using Module3_UnitTesting.Controller;
using Module3_UnitTesting.View;
using System.Threading.Tasks;
using System;

namespace Module3.UnitTests
{
    static class Globals
    {
        // Strings
        // Valid
        public const string VALID_STRING = "Valid String";
        // Invalid
        public const string EMPTY_STRING = "";
        public const string NULL_STRING = null;
        public const string CARRIAGE_RETURN = "\r\n";

        // Dates
        // Valid
        public const string VALID_DATE_TEXT = "Nov 30, 1980";
        public const string VALID_DATE_NUMERIC_AMERICAN = "11/30/1980";
        public const string VALID_DATE_NUMERIC_EUROPEAN = "30/11/1980";
        // Invalid
        public const string INVALID_DATE_TEXT = "Nove 30 1980";
        public const string INVALID_DATE_NUMERIC_AMERICAN = "11/300/1980";
        public const string INVALID_DATE_NUMERIC_EUROPEAN = "300/11/1980";

        public const string VALID = "Valid";
        public const string INVALID = "Invalid";
        public const int METHOD_TIMEOUT = 1000;
        public const int TEST_TIMEOUT = 50;
        public const string PROMPT = "";

        public static async Task TimeoutAfter(this Task task, int millisecondsTimeout)
        {
            if (task == await Task.WhenAny(task, Task.Delay(millisecondsTimeout)))
                await task;
            else
                throw new TimeoutException();
        }
    }

    class ConsoleUIMock: ConsoleUI
    {
        string readline { get; set; }

        public ConsoleUIMock(string readline)
        {
            this.readline = readline;
        }

        public override string ReadLine() { return readline; }
    }

    [TestFixture]
    [Category("String Data Tests")]
    class InputDataTests
    {
        string data;

        [TestCase(Globals.VALID_STRING), Timeout(Globals.METHOD_TIMEOUT)]
        public void GetStringData_Required_ValidInput(string readline)
        {
            bool required = true;

            DataCollector dc = new DataCollector(new ConsoleUIMock(readline));
            dc.GetStringData(Globals.PROMPT, out data, required);
            Assert.True(data == readline);
        }

        [TestCase(Globals.NULL_STRING), Timeout(Globals.METHOD_TIMEOUT)]
        [TestCase(Globals.EMPTY_STRING)]
        [TestCase(Globals.CARRIAGE_RETURN)]
        [ExpectedException(typeof(TimeoutException))]
        public async void GetStringData_Required_InvalidInput(string readline)
        {
            bool required = true;

            DataCollector dc = new DataCollector(new ConsoleUIMock(readline));
            Task task = new Task(() => dc.GetStringData(Globals.PROMPT, out data, required));
            await Globals.TimeoutAfter(task, Globals.TEST_TIMEOUT);
        }

        [TestCase(Globals.NULL_STRING), Timeout(Globals.METHOD_TIMEOUT)]
        [TestCase(Globals.EMPTY_STRING)]
        [TestCase(Globals.CARRIAGE_RETURN)]
        [TestCase(Globals.VALID_STRING)]
        public void GetStringData_NotRequired_ValidInput(string readline)
        {
            bool notRequired = false;

            DataCollector dc = new DataCollector(new ConsoleUIMock(readline));
            dc.GetStringData(Globals.PROMPT, out data, notRequired);
            Assert.IsTrue(data == readline);
        }
    }

    [TestFixture]
    [Category("Date Data Tests")]
    class InputDateTests
    {
        [TestCase(Globals.VALID_DATE_TEXT), Timeout(Globals.METHOD_TIMEOUT)]
        [TestCase(Globals.VALID_DATE_NUMERIC_AMERICAN)]
        [TestCase(Globals.VALID_DATE_NUMERIC_EUROPEAN)]
        public void GetDate_NotRequired_ValidInput(string readline)
        {
            DateTime date;
            bool notRequired = false;

            DataCollector dc = new DataCollector(new ConsoleUIMock(readline));
            dc.GetDate(Globals.PROMPT, out date, notRequired);
            Assert.IsTrue(DateTime.Parse(readline) == date);
        }
    }
}