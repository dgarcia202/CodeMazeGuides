using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;

namespace Test
{
    [TestClass]
    public class CustomFormatTests
    {
        [TestMethod]
        public void WhenUsingCustomFormatString_ThenValuesAreFromattedOrParsed()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0);
            Console.WriteLine("{0:MM/dd/yy H:mm:ss}", datetime);

            Assert.AreEqual($"08/24/17 14:35:00{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingDayFormatSpecifier_ThenDayValuesAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4);
            Console.WriteLine(datetime.ToString("d MMMM", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("dd MMMM", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual($"4 August{Environment.NewLine}" +
                                $"04 August{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingDayFormatSpecifier_ThenWeekDaysAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4);
            Console.WriteLine(datetime.ToString("ddd, d MMMM", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("dddd, d MMMM", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"Fri, 4 August{Environment.NewLine}
                                Friday, 4 August{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingMonthFormatSpecifier_ThenMonthValuesAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4);
            Console.WriteLine(datetime.ToString("%M", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("MM", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"8{Environment.NewLine}
                                08{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingMonthFormatSpecifier_ThenMonthsAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4);
            Console.WriteLine(datetime.ToString("MMM", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"Aug{Environment.NewLine}
                                August{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingSingleCharacterCustomIdentifier_ThenWorksAsCustomFormatString()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4);
            Console.WriteLine(datetime.ToString("%d", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString(" y", CultureInfo.CreateSpecificCulture("en-US")).Trim());

            Assert.AreEqual(@$"4{Environment.NewLine}
                                17{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingYearCustomFormatIdentifier_ThenIsShownWithOneToFourChars()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2001, 8, 4);
            Console.WriteLine(datetime.ToString("%y", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("yy", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("yyy", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("yyyy", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"1{Environment.NewLine}
                                01{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingHourFormatSpecifier_ThenOnetoTwelveDigitsAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4, 22, 35, 0);
            Console.WriteLine(datetime.ToString("%h", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("hh", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"10{Environment.NewLine}
                                10{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingHourFormatSpecifier_ThenOnetoTwentyThreeDigitsAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4, 22, 35, 0);
            Console.WriteLine(datetime.ToString("%H", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"22{Environment.NewLine}
                                22{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingMinuteFormatSpecifier_ThenMinutesAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4, 22, 35, 0);
            Console.WriteLine(datetime.ToString("%m", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("mm", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"35{Environment.NewLine}
                                35{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingSecondFormatSpecifier_ThenSecondsAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4, 22, 35, 15);
            Console.WriteLine(datetime.ToString("%s", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("ss", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"15{Environment.NewLine}
                                15{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingSecondFractionsFormatSpecifier_ThenSecondsFractionsAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4, 22, 35, 15, 18);
            Console.WriteLine(datetime.ToString("HH:mm:ss.%f", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.ff", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.fff", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.ffff", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.fffff", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.ffffff", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.fffffff", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"22:35:15.0{Environment.NewLine}" +
                                $"22:35:15.01{Environment.NewLine}" +
                                $"22:35:15.018{Environment.NewLine}" +
                                $"22:35:15.0180{Environment.NewLine}" +
                                $"22:35:15.01800{Environment.NewLine}" +
                                $"22:35:15.018000{Environment.NewLine}" +
                                $"22:35:15.0180000{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingSecondFractionsFormatSpecifier_ThenNonZeroSecondsFractionsAreShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4, 22, 35, 15, 18);
            Console.WriteLine(datetime.ToString("HH:mm:ss.%F", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.FF", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.FFF", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.FFFF", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.FFFFF", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.FFFFFF", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("HH:mm:ss.FFFFFFF", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual(@$"22:35:15{Environment.NewLine}" +
                                $"22:35:15.01{Environment.NewLine}" +
                                $"22:35:15.018{Environment.NewLine}" +
                                $"22:35:15.018{Environment.NewLine}" +
                                $"22:35:15.018{Environment.NewLine}" +
                                $"22:35:15.018{Environment.NewLine}" +
                                $"22:35:15.018{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingMeridienFormatSpecifier_ThenMeridienLabelIsShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 4, 22, 35, 15);
            Console.WriteLine(datetime.ToString("hh:mm:ss %t", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("hh:mm:ss tt", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual($"10:35:15 P{Environment.NewLine}" +
                                $"10:35:15 PM{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingTimeZoneFormatSpecifier_ThenDependsOnKindProperty()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetimeLocal = new DateTime(2017, 8, 4, 22, 35, 15, DateTimeKind.Local);
            Console.WriteLine(datetimeLocal.ToString("%K", CultureInfo.CreateSpecificCulture("en-US")));

            var datetimeUtc = new DateTime(2017, 8, 4, 22, 35, 15, DateTimeKind.Utc);
            Console.WriteLine(datetimeUtc.ToString("%K", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual($"+02:00{Environment.NewLine}" +
                                $"Z{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingTimeZoneFormatSpecifier_ThenDependsOnInternalOffsetProperty()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetimeLocal = new DateTimeOffset(2017, 8, 4, 22, 35, 15, TimeSpan.FromHours(2));
            Console.WriteLine(datetimeLocal.ToString("%K", CultureInfo.CreateSpecificCulture("en-US")));

            var datetimeUtc = new DateTimeOffset(2017, 8, 4, 22, 35, 15, TimeSpan.Zero);
            Console.WriteLine(datetimeUtc.ToString("%K", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual($"+02:00{Environment.NewLine}" +
                                $"+00:00{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingTimeZoneFormatSpecifier_ThenSignedTimeZoneIsShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetimeLocal = new DateTimeOffset(2017, 8, 4, 22, 35, 15, TimeSpan.FromHours(2));
            Console.WriteLine(datetimeLocal.ToString("%z", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetimeLocal.ToString("zz", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetimeLocal.ToString("zzz", CultureInfo.CreateSpecificCulture("en-US")));

            Assert.AreEqual($"+2{Environment.NewLine}" +
                                $"+02{Environment.NewLine}" +
                                $"+02:00{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingEraFormatSpecifier_ThenEraIsShown()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTimeOffset(2017, 8, 4, 22, 35, 15, TimeSpan.FromHours(2));
            Console.WriteLine(datetime.ToString("%g", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("gg", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(datetime.ToString("gg", CultureInfo.CreateSpecificCulture("es-ES")));

            Assert.AreEqual($"AD{Environment.NewLine}" +
                                $"AD{Environment.NewLine}" +
                                $"d. C.{Environment.NewLine}", sw.ToString());
        }
    }
}
