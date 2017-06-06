using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL.Concrete.Validation;
using DTO.Score;
using Snake.Portal.UnitTests.CustomAsserts;
using Exceptions;

namespace Snake.Portal.UnitTests.Score
{
    [TestClass]
    public class ScoreAddValidation
    {
        private ScoreValidation _scoreValidation;

        [TestInitialize]
        public void TestInitialize()
        {
            _scoreValidation = new ScoreValidation();
        }

        [TestMethod]
        public void ValidateForAdd_InvalidId_ShouldThrowEntityValidationException()
        {
            var scoreDto = new ScoreDto
            {
                Id = 1,
                CreatedOn = DateTime.Now,
                PlayerScore = 10,
                UserId = 10
            };

            var result = AssertOnException.Catch<EntityValidationException>(() => _scoreValidation.ValidateForAdd(scoreDto));

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Message, DefaultExceptionMessages.ENTITY_VALIDATION_EXCEPTION);
        }

        [TestMethod]
        public void ValidateForAdd_IsNull_ShouldThrowEntityValidationException()
        {
            ScoreDto scoreDto = null;

            var result = AssertOnException.Catch<EntityValidationException>(() => _scoreValidation.ValidateForAdd(scoreDto));

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Message, DefaultExceptionMessages.ENTITY_VALIDATION_EXCEPTION);
        }

        [TestMethod]
        public void ValidateForAdd_InvalidUserId_ShouldThrowEntityValidationException()
        {
            var scoreDto = new ScoreDto
            {
                Id = 0,
                CreatedOn = DateTime.Now,
                PlayerScore = 10,
                UserId = 0
            };

            var result = AssertOnException.Catch<EntityValidationException>(() => _scoreValidation.ValidateForAdd(scoreDto));

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Message, DefaultExceptionMessages.ENTITY_VALIDATION_EXCEPTION);
        }

        [TestMethod]
        public void ValidateForAdd_ValidInput_ShouldDoNothing()
        {
            var scoreDto = new ScoreDto
            {
                Id = 0,
                CreatedOn = DateTime.Now,
                PlayerScore = 10,
                UserId = 10
            };

            _scoreValidation.ValidateForAdd(scoreDto);
        }
    }
}
