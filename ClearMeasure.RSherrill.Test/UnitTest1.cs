using NUnit.Framework;
using System.IO;

namespace ClearMeasure.RSherrill.Test
{

    public class Tests
    {

        FizzBuzz _fizzBuzz;        

        [SetUp]
        public void Setup()
        {
            _fizzBuzz = new FizzBuzz();           
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Line15IsFizzBuzz()
        {
            var fizzBuzzFile = _fizzBuzz.GenerateFizzBuzzFile(100);
            
            int lineNumber = 0;            
            foreach (string line in System.IO.File.ReadLines(fizzBuzzFile))
            {
                lineNumber++;
                if(lineNumber == 15)
                {
                    Assert.IsTrue(line == "FizzBuzz");
                }
            }
            File.Delete(fizzBuzzFile);
        }

        [Test]
        public void Predicates()
        {
            static bool fizzPredicate(int x) { return (x == 5); }
            static bool buzzPredicate(int x) { return (x == 6); }

            var fizzBuzzFile = _fizzBuzz.GenerateFizzBuzzFile(fizzPredicate, buzzPredicate, 10);

            int lineNumber = 0;
            foreach (string line in System.IO.File.ReadLines(fizzBuzzFile))
            {
                lineNumber++;
                if (lineNumber == 5)
                {                    
                    Assert.IsTrue(line == "Fizz");
                }
                else if (lineNumber == 6)
                {
                    Assert.IsTrue(line == "Buzz");
                }
            }
            File.Delete(fizzBuzzFile);
        }

    }

}