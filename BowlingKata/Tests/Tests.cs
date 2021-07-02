using BowlingKata.Logic;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    [TestFixture]
    public class Tests
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }
        
        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(0, 0)]
        [TestCase(10, 10)]
        public void Roll_SinglePin_ScoreIsOne(int pins, int expectedScore)
        {
            _game.Roll(pins);
            var result = _game.Score();

            Assert.AreEqual(expectedScore, result);
        }

        [Test]
        public void Roll_MultiplePins_ScoreIsCorrect()
        {
            _game.Roll(4);
            _game.Roll(4);

            var result = _game.Score();
            Assert.AreEqual(8, result);
        }
        
         [Test]
         public void Roll_SingleSpare_FirstFrame_ScoreIsCorrect()
         {
             _game.Roll(5);
             _game.Roll(5);
        
             _game.Roll(1);
             var result = _game.Score();
             Assert.AreEqual(12, result);
         }
        
        [Test]
        public void Roll_TwoSpares_ScoreIsCorrect()
        {
            RollTwoSpares();

            var result = _game.Score();
            Assert.AreEqual(31, result);
        }
        
        [Test]
        public void Roll_SingleStrike_ScoreIsCorrect()
        {
            _game.Roll(10);
            _game.Roll(2);
            _game.Roll(2);
            
            var result = _game.Score();
            Assert.AreEqual(18, result);
        }

        [Test]
        public void Roll_MultipleStrikes_ScoreIsCorrect()
        {
            RollTwoStrikes();

            var result = _game.Score();
            Assert.AreEqual(40, result);
        }

        private void RollTwoStrikes()
        {
            _game.Roll(10);
            _game.Roll(10);

            _game.Roll(2);
            _game.Roll(2);
        }

        [Test]
        public void Roll_PerfectGame_ScoreIs300()
        {
            for (int roll = 0; roll < 12; roll++)
            {
                _game.Roll(10);
            }
            
            var result = _game.Score();
            Assert.AreEqual(300, result);
        }

        private void RollTwoSpares()
        {
            _game.Roll(3);
            _game.Roll(7);

            _game.Roll(5);
            _game.Roll(5);

            _game.Roll(2);
            _game.Roll(2);
        }
    }
}