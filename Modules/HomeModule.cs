using Nancy;
using Hangman.Objects;
using System.Collections.Generic;
using System;

namespace Hangman
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => {
        Game currentGame = new Game ();
        Game.SetCurrentGame(currentGame);
        return View ["index.cshtml", currentGame];
      };
      Post ["/"] = _ => {
        string currentGuess = Request.Form["letter-guess"];
        Game currentGame = Game.GetCurrentGame();
        currentGame.GuessLetter(currentGuess);
        return View ["index.cshtml", currentGame];
      };
    }
  }
}
