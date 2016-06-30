using System.Collections.Generic;
using System;

namespace Hangman.Objects
{
  public class Game
  {
    private string _gameWord;
    private int _turnCount;
    private static List<string> _wordsList = new List<string> () {"anteater", "bear", "cheetah", "giraffe", "tiger", "whale", "beetle"};
    private List<string> _lettersGuessed;
    private List<string> _wordToDisplay;
    private string _imageName;
    private static Game _currentGame;
    private string _messageString;

    public Game()
    {
      Random randomWord = new Random ();
      int chosenWord = randomWord.Next(0, _wordsList.Count);
      _gameWord = _wordsList[chosenWord];
      _turnCount = 0;
      _imageName = "hang-man-0.png";
      _lettersGuessed = new List<string> {};
      _wordToDisplay = new List<string> {};
      for(int index = 0; index < _gameWord.Length; index ++)
      {
        _wordToDisplay.Add("_ ");
      }
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
    public static Game GetCurrentGame()
    {
      return _currentGame;
    }
    public static void SetCurrentGame(Game newGame)
    {
      _currentGame = newGame;
    }
    public string GetMessageString()
    {
      return _messageString;
    }
    public string GetImageName()
    {
      return _imageName;
    }
    public void SetImageName()
    {
      _imageName = "hang-man-" + _turnCount.ToString() + ".png";
    }
    public string GetWordToDisplayString()
    {
      string _wordToDisplayString = "";
      foreach (string letter in _wordToDisplay)
      {
        _wordToDisplayString += letter;
      }
      return _wordToDisplayString;
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

    public void GuessLetter(string letter)
    {
      if (_messageString == "You win!" || _messageString == "You Lose" || _messageString == "The game is over, please start a new game.")
      {
        _messageString = "The game is over, please start a new game.";
      }
      else
      {
        _messageString = "";
        if (_lettersGuessed.Contains(letter))
        {
          _messageString = "You already guessed that letter";
        }
        else
        {
          _lettersGuessed.Add(letter);
          _lettersGuessed.Sort();
          if (_gameWord.Contains(letter))
          {
            for(int index = 0; index < _gameWord.Length; index ++)
            {
              string charOfGameWord = _gameWord[index].ToString();
              if (charOfGameWord == letter)
              {
                _wordToDisplay[index] = letter;
              }
            }
          }
          else
          {
            _turnCount ++;
            SetImageName();
            if (_turnCount >= 9)
            {
              _messageString = "You Lose";
            }
          }
          if (!_wordToDisplay.Contains("_ "))
          {
            _messageString = "You win!";
          }
        }
      }
    }
  }
}
