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
        Game newGame = new Game ();
        return View ["index.cshtml", newGame];
      };
    }
  }
}
