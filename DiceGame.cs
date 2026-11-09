using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheBugs
{
    public class DiceGame
    {
        private Player _player = new Player();
        private Random _random = new Random();

        private int _trapDamage;
        private int _treasureEnergy;
        private int _gameLength;

        public void SetUpGame(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    //Easy 
                    _player.Energy = 20;
                    _player.Position = 1;
                    _trapDamage = 3;
                    _treasureEnergy = 15;
                    _gameLength = 4;
                    break;
                case 2:
                    //Normal
                    _player.Energy = 15;
                    _player.Position = 1;
                    _trapDamage = 5;
                    _treasureEnergy = 10;
                    _gameLength = 7;
                    break;
                case 3:
                    //Hard
                    _player.Energy = 10;
                    _player.Position = 1;
                    _trapDamage = 7;
                    _treasureEnergy = 8;
                    _gameLength = 10;
                    break;
                default:
                    //default difficulty same as Normal
                    _player.Position = 1;
                    _trapDamage = 5;
                    _treasureEnergy = 10;
                    _gameLength = 7;
                    break;
            }
        }

        public void Play()
        {
            for (int turn = 1; turn <= _gameLength; turn++)
            {
                Console.WriteLine($"\nTurn {turn}");

                int roll = RollDice();
                MovePlayer(roll);
                TriggerEvents();

                Console.WriteLine($"Position: {_player.Position}, Energy: {_player.Energy}");
            }
        }

        private int RollDice()
        {
            int roll = _random.Next(1, 6);
            Console.WriteLine($"Rolled {roll}");
            return roll;
        }

        private void MovePlayer(int steps)
        {
            _player.Position += steps;
            

            if (_player.Position == (3 * _gameLength)) 
            {
                Console.WriteLine("You have WON!");
                
            }
        }

        private void TriggerEvents()
        {
            if (_player.Position % 4 ==0)
            {
                Treasure();
            }

            if (_player.Position % 3 == 0)
            {
                Trap();
            }
        }

        private void Treasure()
        {
            Console.WriteLine("Treasure found!");
            _player.Energy += _treasureEnergy;
        }

        private void Trap()
        {
            Console.WriteLine("Trap triggered!");
            _player.Energy -= _trapDamage;

            if(_player.Energy <0)
            {
                Console.WriteLine("You have lost all your energy!\nYou fall asleep and wake up at the start...");
                int newPlayerPosition = 0;
                _player.Position = newPlayerPosition;
                 
            }
        }
    }


    public class Player
    {
        public int Position { get; set; }
        public int Energy { get; set; }

        public Player(){}
    }
}
