/*
The prime factors of 13195 are 5, 7, 13 and 29.
What is the largest prime factor of the number 600851475143 ?
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {                    
        public static void Main(string[] args)
        {
            //int max:                 2,147,483,647
            //long max:    9,223,372,036,854,775,807
            //ulong max:  18,446,744,073,709,551,615

            ulong num = 9223372036854775807;
            ulong root = (ulong)Math.Sqrt(num);
            
            List<ulong> DividersBelowRoot = new List<ulong>(); 
            List<ulong> DividersAboveRoot = new List<ulong>(); 
            
            for (ulong i = 1; i <= root; i++)
            {
                if (num % i == 0)
                {
                    DividersBelowRoot.Add(i);		//in fact below or equal root
                    DividersAboveRoot.Add(num/i);	//in fact above or equal root
                }
            }

            bool prime = true, foundPrime = false;

            foreach(var k in DividersAboveRoot)
            {
                //check whether the divider is prime (from the highest)
                for (ulong i = 2; i <= k/2; i++)
                {
                    if (k % i == 0) 
                    {
                        prime = false;
                        break;
                    }
                }
                
                if (prime) 
                {
                    Console.WriteLine("highest prime divider of {0} is {1}", num, k);
                    foundPrime = true;
                    break;
                }
                
                prime = true;
            }

            if (!foundPrime)
            {
                DividersBelowRoot.Reverse();
                foreach(var k in DividersBelowRoot)
                {
                    //check whether the divider is prime (from the highest)
                    for (ulong i = 2; i <= k/2; i++)
                    {
                        if (k % i == 0) 
                        {
                            prime = false;
                            break;
                        }
                    }
                
                    if (prime) 
                    {
                        Console.WriteLine("highest prime divider of {0} is {1}", num, k);
                        foundPrime = true;
                        break;
                    }
                
                    prime = true;
                }
            }
		
	    if(!foundPrime) Console.WriteLine("number {0} does not have prime dividers", num);
		Console.ReadLine();
        }        
    }
}