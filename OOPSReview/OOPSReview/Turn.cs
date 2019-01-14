using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSReview
{
    class Turn
    {

        public int Player1Result { get; set; }
        public int Player2Result { get; set; }
        //public string Winner { get; private set; }
        
        public Turn()
        {
            Player1Result = 0;
            Player2Result = 0;
            //FindWinner();
        }

        public Turn(int player1Result, int player2Result)
        {

            Player1Result = player1Result;
            Player2Result = player2Result;
            //FindWinner();
        }


        //private void FindWinner()
        //{
        //    if (Player1Result > Player2Result) Winner = "Player 1 Wins";
        //    else if (Player1Result < Player2Result) Winner = "Player 2 Wins";
        //    else Winner = "Tie";
        //}
    }
}
