using System;

namespace hangman
{
    class Program
    {
        private static string _WordToGuess;

        private static int _hangmanCountdown = 7;

        private static char[] _lettersGuessed = new char[26] ;

        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                _WordToGuess = args[0];
            }

            DisplayIntroScreen();

            if (string.IsNullOrWhiteSpace(_WordToGuess))
            {
                SetupGame();
            }

            while(1!=0)
            {
                RenderScreen();
            }
        }

        
        public static void SetupGame()
        {
            Console.Write("Enter a word to guess:");
            _WordToGuess =  Console.ReadLine();
        }

        public static void RenderScreen()
        {
            Console.Clear();
            Console.WriteLine($"Guesses left: {_hangmanCountdown}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            RenderLetterSpaces();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Letters Guessed so far: ");

            for(int i = 0; i< _lettersGuessed.Length; i++)
            {
                if (_lettersGuessed[i] > 32)
                {
                    Console.Write(_lettersGuessed[i]);
                }
            }

            Console.WriteLine();

            Console.Write(" Guess a Letter ");
            char attempt = Console.ReadKey().KeyChar;
            AddAttemptToGuesses(attempt);


        }

        private static void AddAttemptToGuesses(char attempt)
        {
            int i = 0;

            char safeAttempt = attempt.ToString().ToLower()[0];

            while (_lettersGuessed[i] != 0)
            {
                if (_lettersGuessed[i] == safeAttempt)
                {
                    return;
                }

                i++;
            }

            _lettersGuessed[i] = safeAttempt;
        }

        public static void RenderLetterSpaces()
        {
            for(int i=0; i < _WordToGuess.Length;i++)
            {
                Console.Write(" _" + RenderLetterIfGuessed( _WordToGuess[i]).ToString()  + "_ ");
            }
        }

        private static char RenderLetterIfGuessed(char letter)
        {
            for(int i = 0; i < _lettersGuessed.Length; i++)
            {
                if(_lettersGuessed[i] == letter.ToString().ToLower()[0])
                {
                    return letter;
                }
            }

            return '_';
        }

        public static void DisplayIntroScreen()
        {
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("***                       Welcome   To     Hangman                                     ***");
            Console.WriteLine("***                                                                                    ***");
            Console.WriteLine("***                                                                                    ***");
            Console.WriteLine("***                                                                                    ***");
            Console.WriteLine("***                                                                                    ***");
            Console.WriteLine("***                                                                                    ***");
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("******************************************************************************************");


            Console.ReadKey();

        }
    }
}
