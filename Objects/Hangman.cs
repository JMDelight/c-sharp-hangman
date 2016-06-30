using System.Collections.Generic;
using System;

namespace Hangman.Objects
{
  public class Game
  {
    private string _gameWord;
    private int _turnCount;
    private static List<string> _wordsList = new List<string> () {"apple", "bear", "cheetah"};
    private List<string> _lettersGuessed;

    public Game()
    {
      Random randomWord = new Random ();
      int chosenWord = randomWord.Next(0, _wordsList.Count);
      _gameWord = _wordsList[chosenWord];
      _turnCount = 0;
      _lettersGuessed = new List<string> {"a"};
    }

    public string GetGameWord()
    {
      return _gameWord;
    }
    public int GetTurnCount()
    {
      return _turnCount;
    }
    public void SetTurnCount(int newCount)
    {
      _turnCount = newCount;
    }
    public string GetLettersGuessedString()
    {
      string _lettersGuessedString = "";
      foreach (string letter in _lettersGuessed)
      {
        _lettersGuessedString += letter;
      }
      return _lettersGuessedString;
    }
    // public void GuessLetter(string letter)
    // {
    //
    //   if (_gameWord.Contains(letter))
    //   {
    //
    //   }
    // }
  }
}
