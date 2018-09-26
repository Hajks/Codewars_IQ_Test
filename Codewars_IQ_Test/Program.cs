using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//    ##TASK DESCRIPTION##
//    Bob is preparing to pass IQ test.The most frequent task in this test is to find out which one of the given numbers differs from the others. Bob observed that one number usually differs from the others in evenness.Help Bob — to check his answers, he needs a program that among the given numbers finds one that is different in evenness, and return a position of this number.

//    ! Keep in mind that your task is to help Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)

//    ##Examples :

//    IQ.Test("2 4 7 8 10") => 3 // Third number is odd, while the rest of the numbers are even

//    IQ.Test("1 2 1 1") => 2 // Second number is even, while the rest of the numbers are odd

namespace Codewars_IQ_Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // MySolution
            int Test(string numbers)
            {
                List<int> sNumbers = new List<int>(Array.ConvertAll(numbers.Split(' '), int.Parse));
                int even = 0;
                int odd = 0;
                int positionOfEvenNumber = 0;
                int positionOfOddNumber = 0;
                foreach (int check in sNumbers)
                    if (check % 2 == 0)
                    {
                        even++;
                        positionOfEvenNumber = check;
                    }
                    else
                    {
                        odd++;
                        positionOfOddNumber = check;
                    }

                if (even > odd)
                    return sNumbers.IndexOf(positionOfOddNumber) + 1;
                else
                    return sNumbers.IndexOf(positionOfEvenNumber) + 1;

            }

            // Codewars best solution + code analysis for myself.
            int Test2(string numbers)
            {
                var ints = numbers.Split(' ').Select(int.Parse).ToList(); // We create var ints. Using split we take out numbers from string. Then we take them by select meanwhile we convert them from string to int, by int.Parse and finally we place them in list.
                var unique = ints.GroupBy(n => n % 2).OrderBy(c => c.Count()).First().First(); // We group ints into two group even and odd. Then we order them by how many of them is inside so basicly at first place will be group with count == 1 and inside this group we got only one number. That's why we take first group and from first group we take first number.
                return ints.FindIndex(c => c == unique) + 1; // Finally we find index of this number before being sorted and we return it. I like this solution a lot. 
            }
        }
    }
}
