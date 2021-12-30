using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;

namespace Test
{
    [TestClass]
    public class StandardDateFormatTests
    {
        [TestMethod]
        public void WhenUsingStandardFormatSpecifiers_ThenCurrentCultureFormatIsApplied()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24);
            Console.WriteLine(datetime.ToString("d"));

            Assert.AreEqual($"8/24/2017{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingStandardFormatSpecifiers_ThenOutputChangesAccordingToCulture()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24);
            Console.WriteLine(datetime.ToString("d", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")));
            Console.WriteLine(datetime.ToString("d", CultureInfo.CreateSpecificCulture("ja-JP")));

            Assert.AreEqual(@$"8/24/2017{Environment.NewLine}
                                24/8/2017{Environment.NewLine}
                                2017/08/24{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingDateTimeFormatInfo_ThenOutputChangesAccordingToCustomFormatInfo()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24);
            var formatInfo = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
            formatInfo.DateSeparator = "-";

            Console.WriteLine(datetime.ToString("d", formatInfo));

            Assert.AreEqual($"8-24-2017{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingFormatSpecifierAndCulture_ThenCanParseCorrectString()
        {
            var dateLiteral = "8/24/2017";
            var date = DateTime.ParseExact(dateLiteral, "d", CultureInfo.CreateSpecificCulture("en-US"));

            Assert.AreEqual(date.ToString("d", CultureInfo.CreateSpecificCulture("en-US")), dateLiteral);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void WhenUsingFormatSpecifierAndWrongCulture_ThenThrowsException()
        {
            var dateLiteral = "8/24/2017";
            DateTime.ParseExact(dateLiteral, "d", CultureInfo.CreateSpecificCulture("ja-JP"));
        }

        [TestMethod]
        public void WhenUsingLongDateStandardFormat_ThenOutputChangesAccordingToCulture()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24);
            Console.WriteLine(datetime.ToString("D", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
            Console.WriteLine(datetime.ToString("D", CultureInfo.CreateSpecificCulture("de-DE")));

            Assert.AreEqual(@$"Thursday, August 24, 2017{Environment.NewLine}
                                jueves, 24 de agosto de 2017{Environment.NewLine}
                                Donnerstag, 24. August 2017{Environment.NewLine}", sw.ToString());
        }
    }
}
