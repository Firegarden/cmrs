using System;
using System.IO;
using System.Text;


namespace ClearMeasure.RSherrill
{

    public class FizzBuzz
    {        

        public FizzBuzz()
        {                       
        }

        public string GenerateFizzBuzzFile(int upperBound)
        {
            static bool fizzPredicate(int x) { return (x % 3 == 0); }
            static bool buzzPredicate(int x) { return (x % 5 == 0); }

            return GenerateFizzBuzzFile(fizzPredicate, buzzPredicate, upperBound);
        }

        public string GenerateFizzBuzzFile(Predicate<int> fizzPredicate, Predicate<int> buzzPredicate, int upperBound)
        {
            var tempFilePath = Path.GetTempFileName();
            using (StreamWriter streamWriter = new StreamWriter(tempFilePath))
            {
                for (var x = 1; x <= upperBound; x++)
                {
                    var isFizz = fizzPredicate(x);
                    var isBuzz = buzzPredicate(x);

                    if (isFizz)
                        streamWriter.Write("Fizz");

                    if (isBuzz)
                        streamWriter.Write("Buzz");

                    if (!isFizz && !isBuzz)
                        streamWriter.Write(x.ToString());

                    streamWriter.WriteLine();
                }
            }
            return tempFilePath;
        }

    }

}
