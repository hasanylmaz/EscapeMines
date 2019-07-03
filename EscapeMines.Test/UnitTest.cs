using System;
using EscapeMines.Library;
using EscapeMines.Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EscapeMines.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestPoint()
        {
            Point point = new Point(10, 5);
            Assert.AreEqual(5, point.Y);
        }

        [TestMethod]
        public void TestObserver()
        {
            var observer = new Observer(new Board(10, 6));
            Assert.AreEqual(false, observer.IsDanger(new Point(5, 5)));
        }

        [TestMethod]
        public void TestTurtle()
        {
            var turtle = Library.Models.Turtle.Instance(new Point(5, 6));
            var positionX = turtle.Position.X;
            var positionY = turtle.Position.Y;
            Assert.AreEqual(positionX, 5);
            Assert.AreEqual(positionY, 6);
        }

        [TestMethod]
        public void TestPrinter()
        {
            Assert.AreNotEqual(Printer.Success, Printer.HitMine);
        }
    }
}
