using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using exo3_;

namespace exo3_.Tests
{
    [TestClass]
    public class CalculateDayIndexInYearTests
    {
        // Propriété magique pour afficher les logs dans Visual Studio
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Jan_1_NonLeap_Returns1()
        {
            // Arrange
            int month = 1;
            int day = 1;
            int year = 2023;
            int expected = 1;
            TestContext.WriteLine($"Test: {day}/{month}/{year} | Attendu: {expected}");

            // Act
            int actual = Class1.CalculateDayIndexInYear(month, day, year);

            // Assert
            TestContext.WriteLine($"Obtenu: {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Mar_1_Leap_Returns61()
        {
            // Arrange
            int month = 3;
            int day = 1;
            int year = 2024; // Année bissextile
            int expected = 61;
            TestContext.WriteLine($"Test: {day}/{month}/{year} (Bissextile) | Attendu: {expected}");

            // Act
            int actual = Class1.CalculateDayIndexInYear(month, day, year);

            // Assert
            TestContext.WriteLine($"Obtenu: {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Feb_29_NonLeap_Throws()
        {
            // Arrange
            int month = 2;
            int day = 29;
            int year = 2023; // Non bissextile
            TestContext.WriteLine($"Test d'erreur: {day}/{month}/{year} (Devrait lancer une exception)");

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                Class1.CalculateDayIndexInYear(month, day, year));

            TestContext.WriteLine("Résultat: L'exception attendue a bien été interceptée.");
        }

        [TestMethod]
        public void Year_2000_Leap_Feb29_Returns60()
        {
            // Arrange
            int month = 2;
            int day = 29;
            int year = 2000; // Si divisible par 400 = Bissextile
            int expected = 60;
            TestContext.WriteLine($"Test siècle bissextile: {day}/{month}/{year} | Attendu: {expected}");

            // Act
            int actual = Class1.CalculateDayIndexInYear(month, day, year);

            // Assert
            TestContext.WriteLine($"Obtenu: {actual}");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Dec_31_Leap_Returns366()
        {
            // Arrange
            int month = 12;
            int day = 31;
            int year = 2024;
            int expected = 366;
            TestContext.WriteLine($"Test fin d'année bissextile: {day}/{month}/{year} | Attendu: {expected}");

            // Act
            int actual = Class1.CalculateDayIndexInYear(month, day, year);

            // Assert
            TestContext.WriteLine($"Obtenu: {actual}");
            Assert.AreEqual(expected, actual);
        }
    }
}