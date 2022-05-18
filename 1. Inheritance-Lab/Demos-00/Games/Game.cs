using System;
using System.Collections.Generic;
using System.Text;

namespace Games
{
    // Superclass - Base class or Child class
    public class Game
    {

    }

    // Game -> SinglePlayerGame
    public class SinglePlayerGame : Game
    {

    }

    // Game -> MultiPlayerGame
    public class MultiPlayerGame : Game
    {

    }

    // Game -> SinglePlayerGame -> Minesweeper
    public class Minesweeper : SinglePlayerGame
    {

    }

    // Game -> SinglePlayerGame -> Solitaire
    public class Solitaire : SinglePlayerGame
    {

    }

    // Game -> MiltiPlayerGame -> BoardGame
    public class BoardGame : MultiPlayerGame
    {

    }

    // Game -> MiltiPlayerGame -> BoardGame -> Chess
    public class Chess : BoardGame
    {

    }

    // Game -> MiltiPlayerGame -> BoardGame -> Backgammon
    public class Backgammon : BoardGame
    {

    }
}
