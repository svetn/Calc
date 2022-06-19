using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicTacToe;
using System;

namespace TicTacToeeTests
{
    [TestClass]
    public class TicTacToeTests
    {
        [TestMethod]
        public void IsFirstPlayerO()
        {
            Mock<TicTacToeBusinessLogic> mock = new Mock<TicTacToeBusinessLogic>();
            TicTacToeBusinessLogic oTicTacToeBusinessLogic = mock.Object;

            char expected = 'X';
            char current = oTicTacToeBusinessLogic.oTicTacToeSystemLogic.GetCurrentPlayer();
            Assert.AreEqual(expected, current);

            TicTacToeBusinessLogic.RestartGame();
        }

        [TestMethod]
        public void IsPlayerOAfterPlayerX()
        {
            Mock<TicTacToeBusinessLogic> mock = new Mock<TicTacToeBusinessLogic>();
            TicTacToeBusinessLogic oTicTacToeBusinessLogic = mock.Object;

            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
                TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
                1,
                1,
                ref TicTacToeBusinessLogic.Map);

            char expected = 'O';
            char current = oTicTacToeBusinessLogic.oTicTacToeSystemLogic.GetCurrentPlayer();
            Assert.AreEqual(expected, current);

            TicTacToeBusinessLogic.RestartGame();
        }

        [TestMethod]
        public void IsThereWinner()
        {
            Mock<TicTacToeBusinessLogic> mock = new Mock<TicTacToeBusinessLogic>();
            TicTacToeBusinessLogic oTicTacToeBusinessLogic = mock.Object;

            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
               0,
               0,
               ref TicTacToeBusinessLogic.Map);

            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
               0,
               1,
               ref TicTacToeBusinessLogic.Map);

            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
               1,
               1,
               ref TicTacToeBusinessLogic.Map);

            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
               1,
               2,
               ref TicTacToeBusinessLogic.Map);

            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
               2,
               2,
               ref TicTacToeBusinessLogic.Map);

            TicTacToeSystemLogic.Players eWinner = oTicTacToeBusinessLogic.oTicTacToeSystemLogic.GetTheWinner(
                ref TicTacToeBusinessLogic.Map);

            Assert.AreNotSame(eWinner, TicTacToeSystemLogic.Players.PlayersPlayerNoWinner);

            TicTacToeBusinessLogic.RestartGame();
        }


        public void DoSameStep()
        {
            Mock<TicTacToeBusinessLogic> mock = new Mock<TicTacToeBusinessLogic>();
            TicTacToeBusinessLogic oTicTacToeBusinessLogic = mock.Object;

            // Is valid
            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionIsValidPosition,
               0,
               0,
               ref TicTacToeBusinessLogic.Map);
            
           // Drawing it
           oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
               0,
               0,
               ref TicTacToeBusinessLogic.Map);

            // Checking again if the same pos is valid
            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionIsValidPosition,
               0,
               0,
               ref TicTacToeBusinessLogic.Map);
        }

        [TestMethod]
        public void IsInvalidOperationExceptionThrown()
        {         
            Action act = new Action(DoSameStep);
            Assert.ThrowsException<InvalidOperationException>(act);

            TicTacToeBusinessLogic.RestartGame();
        }

        [TestMethod]
        public void IsGameRestarted()
        {
           string Map = "|   |   |   |\n" +
                        "|   |   |   |\n" +
                        "|   |   |   |\n";

            string GameStatus = "Няма победител";

            int StepCounter = 0;

            Mock<TicTacToeBusinessLogic> mock = new Mock<TicTacToeBusinessLogic>();
            TicTacToeBusinessLogic oTicTacToeBusinessLogic = mock.Object;

            // Is valid
            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionIsValidPosition,
               0,
               0,
               ref TicTacToeBusinessLogic.Map);
            
           // Drawing it
           oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
               0,
               0,
               ref TicTacToeBusinessLogic.Map);
            
            TicTacToeBusinessLogic.RestartGame();

            Assert.AreEqual(Map, TicTacToeBusinessLogic.Map);
            Assert.AreEqual(GameStatus, TicTacToeBusinessLogic.GameStatus);
            Assert.AreEqual(StepCounter, TicTacToeBusinessLogic.StepCounter);

        }

        [TestMethod]
        public void ClearCell()
        {
            Mock<TicTacToeBusinessLogic> mock = new Mock<TicTacToeBusinessLogic>();
            TicTacToeBusinessLogic oTicTacToeBusinessLogic = mock.Object;

            // Is valid
            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
               TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionIsValidPosition,
               0,
               0,
               ref TicTacToeBusinessLogic.Map);

            // Drawing it
            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
                TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
                0,
                0,
                ref TicTacToeBusinessLogic.Map);

            oTicTacToeBusinessLogic.oTicTacToeSystemLogic.ClearCell(0, 0, ref TicTacToeBusinessLogic.Map);

            // Drawing it
            var index = oTicTacToeBusinessLogic.oTicTacToeSystemLogic.MangePosition(
                TicTacToeSystemLogic.ManagePositionAction.ManagePositionActionDrawPlayer,
                0,
                0,
                ref TicTacToeBusinessLogic.Map);

            Assert.AreNotSame(index, -1);
        }
    }
}
