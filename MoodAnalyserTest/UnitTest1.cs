using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;
namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_Sad_Mood_Should_Return_Sad()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser("I am in a Sad mood");
            //Act
            string mood = analyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Sad", mood);
        }
        [TestMethod]
        public void Given_Any_Mood_Should_Return_Happy()
        {
            //Arrange
            MoodAnalyser analyser = new MoodAnalyser("I am in a Happy mood");
            //Act
            string mood = analyser.AnalyseMood();
            //Assert
            Assert.AreEqual("Happy", mood);
        }
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_EmptyMood()
        {
            try
            {
                string message = string.Empty;
                MoodAnalyser mood = new MoodAnalyser(message);
                string moodStr = mood.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }
        [TestMethod]
        public void Given_NULL_Mood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }
        [TestMethod]
        public void Given_MoodAnalyserClassName_Should_ReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("MoodAnalyserApp.MoodAnalyser" , "MoodAnalyser");
            expected.Equals(actual);
            //Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Given_ImproperClassName_Should_Throw_MoodAnalysisException_NO_SUCH_CLASS()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("abc", "abc");
            }
            catch(MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such class found", e.Message);
            }
        }
        [TestMethod]
        public void Given_ImproperConstructorName_Should_Throw_MoodAnalysisException_NO_SUCH_METHOD()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("Mood", "MoodAnalyser");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Constructor not found", e.Message);
            }
        }
    }
}
