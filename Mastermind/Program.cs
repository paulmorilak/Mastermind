using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {


        static void Main(string[] args)
        {
            Game game1 = new Game();
            String UserIn;

            while (game1.GetTries() > 0){
                Console.WriteLine("Try to guess the 4 digit code! Use only numbers 1-6!");
                UserIn = Console.ReadLine();
                game1.SubmitAnswer(UserIn);
               // game1.LoseTry();
             }
            Console.WriteLine("You Lose!");
            Console.ReadLine();

        }
    }

    class Game
    {
        private int[] code = new int[4];
        private int[] codeCheck = new int[4];
        private int[] answer = new int[4];
        private int tries = 10;
        private bool valid = false;
        private int plus = 0;
        private int minus = 0;
        
       
        public Game()
        {
            
            Random randomNumber = new Random();

            // remove 
            Console.Write("Code:");
            
            for (int i = 0; i <= 3; i++)
            {

                code[i] = randomNumber.Next(1, 6);

                // remove 
                Console.Write(code[i].ToString());
            }

            
            

        }

        public void SubmitAnswer(string ans)
        {
            valid = true;
            try
            {

                for (int i = 0; i <= 3; i++)
                {

                    answer[i] = (int)Char.GetNumericValue(ans[i]);
                    if (answer[i] < 1 || answer[i] > 6)
                    {
                        Console.WriteLine("Enter numbers from 1 - 6 only");
                        valid = false;
                    }
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Please enter four numbers");
                valid = false;
            }

            if (valid == true)
            {
                CheckAnswer();
            }


        }

        public int GetTries()
        {
            return tries;
        }

        private void CheckAnswer()
        {
            plus = 0;
            
            minus = 0;
            

            for (int i=0; i<=3; i++)
            {
                codeCheck[i] = code[i];
            }

            // check for correct number and position
            for (int i=0; i<=3; i++)
            {
                

                if (answer[i] == codeCheck[i])
                {
                    plus += 1;
                    codeCheck[i] = 0;
                }

            }
            // check for correct number in wrong position
            for (int i= 0; i <= 3; i++)
            {
                for (int j= 0; j <= 3; j++)
                {
                    // skip if it's the same position
                    if ((answer[i] == codeCheck[j]) && (i != j))
                    {
                        minus += 1;
                        codeCheck[j] = 0;
                        break;
                    }
                }
            }


                
            if (plus < 4)
            {
                while (minus > 0)
                {
                    Console.Write("-");
                    minus -= 1;
                }
                while (plus > 0)
                {
                    Console.Write("+");
                    plus -= 1;
                }
                Console.WriteLine();
                Console.WriteLine("ACCESS DENIED");
                LoseTry();
                Console.WriteLine("You have " + tries + " tries remaining...");
            }
            else
            {
                Console.WriteLine("ACCESS GRANTED");
                Console.WriteLine("Welcome! Today's combination to Planet Druidia's planetary shield is:");
                Console.WriteLine("1 - 2 - 3 - 4 - 5");
                Console.WriteLine("Have a nice day, King Roland!");
            }
        }

        public void LoseTry()
        {
            if (tries <=1)
            {
                Console.WriteLine("Your hacking attempts have been jammed by Lone Starr's raspberry jam.");
            }
            else
            {
                tries -= 1;
            }
            
        }
    }
   
}


