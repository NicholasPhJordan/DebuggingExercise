﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        bool _gameOver = false;
        string _playerName = "Hero";
        int _playerHealth = 120;
        int _playerDamage = 20;
        int _playerDefense = 10;
        int levelScaleMax = 5;

        //Displays the character selection menu. 
        void SelectCharacter()
        {
            char input = ' ';
            //Loops until a valid option is choosen
            while (input != '1' && input != '2' && input != '3')
            {
                //Prints options
                Console.WriteLine("Welcome! Please select a character.");
                Console.WriteLine("1.Sir Kibble");
                Console.WriteLine("2.Gnojoel");
                Console.WriteLine("3.Joedazz");
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
                //Sets the players default stats based on which character was picked
                switch (input)
                {
                    case '1':
                        _playerName = "Sir Kibble";
                        _playerHealth = 120;
                        _playerDefense = 10;
                        _playerDamage = 40;
                        break;
                    case '2':
                        _playerName = "Gnojoel";
                        _playerHealth = 40;
                        _playerDefense = 2;
                        _playerDamage = 70;
                        break;
                    case '3':
                        _playerName = "Joedazz";
                        _playerHealth = 200;
                        _playerDefense = 5;
                        _playerDamage = 25;
                        break;
                    //If an invalid input is selected display and input message and input over again.
                    default:
                        Console.WriteLine("\nInvalid input. Press any key to continue.");
                        Console.Write("> ");
                        Console.ReadKey();
                        continue;
                }
                Console.Clear();
            }
            //Prints the stats of the choosen character to the screen before the game begins to give the player visual feedback
            PrintStats(_playerName, _playerHealth, _playerDamage, _playerDefense);
            Console.WriteLine("Press any key to continue.");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        //This is used to progress through our game. A recursive function meant to switch the rooms and start the battles inside them.
        void ClimbLadder(int roomNum)
        {
            int turnCount = 0;

            //Displays context based on which room the player is in and starts battle
            switch (roomNum)
            {
                case 0:
                    Console.WriteLine("A wizard blocks your path!");
                    StartBattle(roomNum, ref turnCount);
                    break;
                case 1:
                    Console.WriteLine("A troll stands before you!");
                    StartBattle(roomNum, ref turnCount);
                    break;
                case 2:
                    Console.WriteLine("A giant has appeared!");
                    StartBattle(roomNum, ref turnCount);
                    break;
                default:
                    _gameOver = true;
                    return;
            }

            //If the player survived the battle, level them up and then proceed to the next room.
            if (_playerHealth > 0)
            {
                Console.WriteLine("Congrats you lived!");
                Console.WriteLine("Press any key to continue.");
                Console.Write("> ");
                Console.ReadKey();
                Console.Clear();
                Upgrade(turnCount ++);
                ClimbLadder(roomNum + 1);
            }
            _gameOver = true;

        }

        //This function handles the battles for our ladder. roomNum is used to update the our opponent to be the enemy in the current room. 
        //turnCount is used to keep track of how many turns it took the player to beat the enemy
        bool StartBattle(int roomNum, ref int turnCount)
        {
            //initialize default enemy stats
            int enemyHealth = 0;
            int enemyAttack = 0;
            int enemyDefense = 0;
            string enemyName = "";
            //Changes the enemy's default stats based on our current room number. 
            //This is how we make it seem as if the player is fighting different enemies
            switch (roomNum)
            {
                case 0:
                    enemyHealth = 100;
                    enemyAttack = 20;
                    enemyDefense = 5;
                    enemyName = "Wizard";
                    break;
                case 1:
                    enemyHealth = 80;
                    enemyAttack = 30;
                    enemyDefense = 5;
                    enemyName = "Troll";
                    
                    break;
                case 2:
                    enemyHealth = 200;
                    enemyAttack = 40;
                    enemyDefense = 10;
                    enemyName = "Giant";
                    break;
            }

            //Loops until the player or the enemy is dead
            while (_playerHealth > 0 && enemyHealth > 0)
            {
                //Displays the stats for both charactersa to the screen before the player takes their turn
                PrintStats(_playerName, _playerHealth, _playerDamage, _playerDefense);
                PrintStats(enemyName, enemyHealth, enemyAttack, enemyDefense);

                //Get input from the player
                char input = ' ';
                input = GetInput("Attack", "Defend");
                //If input is 1, the player wants to attack. By default the enemy blocks any incoming attack
                if (input == '1')
                {
                    BlockAttack(ref enemyHealth, _playerDamage, enemyDefense, _playerName);
                    _playerHealth -= enemyAttack;
                    Console.WriteLine(enemyName + " dealt " + enemyAttack + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();
                    turnCount++;
                    Console.Clear();
                }
                //If the player decides to defend the enemy just takes their turn. However this time the block attack function is
                //called instead of simply decrementing the health by the enemy's attack value.
                else if (input == '2')
                {
                    BlockAttack(ref _playerHealth, enemyAttack, _playerDefense, enemyName);
                    Console.Write("> ");
                    Console.ReadKey();
                    turnCount++;
                    Console.Clear();
                }
            }
            //Return whether or not our player died
            return _playerHealth != 0;
        }

        //Decrements the health of a character. The attack value is subtracted by that character's defense
        int BlockAttack(ref int opponentHealth, int attackVal, int opponentDefense,  string attackerName)
        {
            attackVal -= opponentDefense;
            if (attackVal < 0)
            {
                attackVal = 0;
            }
            opponentHealth -= attackVal;
            Console.WriteLine(attackerName + " dealt " + attackVal + " damage.");
            return opponentHealth;
        }

        //Scales up the player's stats based on the amount of turns it took in the last battle
        void Upgrade(int turnCount)
        {
            //Subtract the amount of turns from our maximum level scale to get our current level scale
            int scale = levelScaleMax - turnCount;
            if (scale <= 0)
            {
                scale += 1;
            }
            Console.WriteLine("Welcome to the Between. A place inbetween rooms.");
            Console.WriteLine("What stat would you like to level up?");
            char input = ' ';
            input = GetInput("Health", "Damage", "Defense");
            if (input == '1')
            {
                Console.WriteLine("You upgraded your health.");
                switch(_playerName)
                {
                    case "Sir Kibble":
                        _playerHealth = 120;
                        _playerDefense = 10;
                        _playerDamage = 40;
                        _playerHealth += 10 * scale;
                        break;
                    case "Gnojoel":
                        _playerHealth = 40;
                        _playerDefense = 2;
                        _playerDamage = 70;
                        _playerHealth += 10 * scale;
                        break;
                    case "Joedazz":
                        _playerHealth = 200;
                        _playerDefense = 5;
                        _playerDamage = 25;
                        _playerHealth += 10 * scale;
                        break;
                }
            }
            else if (input == '2')
            {
                Console.WriteLine("You upgraded your damage.");
                switch (_playerName)
                {
                    case "Sir Kibble":
                        _playerHealth = 120;
                        _playerDefense = 10;
                        _playerDamage = 40;
                        _playerDamage *= scale;
                        break;
                    case "Gnojoel":
                        _playerHealth = 40;
                        _playerDefense = 2;
                        _playerDamage = 70;
                        _playerDamage *= scale;
                        break;
                    case "Joedazz":
                        _playerHealth = 200;
                        _playerDefense = 5;
                        _playerDamage = 25;
                        _playerDamage *= scale;
                        break;
                }
            }
            if(input == '3')
            {
                Console.WriteLine("You upgraded your defense.");
                switch (_playerName)
                {
                    case "Sir Kibble":
                        _playerHealth = 120;
                        _playerDefense = 10;
                        _playerDamage = 40;
                        _playerDefense *= scale;
                        break;
                    case "Gnojoel":
                        _playerHealth = 40;
                        _playerDefense = 2;
                        _playerDamage = 70;
                        _playerDefense *= scale;
                        break;
                    case "Joedazz":
                        _playerHealth = 200;
                        _playerDefense = 5;
                        _playerDamage = 25;
                        _playerDefense *= scale;
                        break;
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        //Gets input from the player
        //Out's the char variable given. This variables stores the player's input choice.
        //The parameters option1 and option 2 displays the players current chpices to the screen
        char GetInput(string option1, string option2)
        {
            //Initialize input
            char input = ' ';
            //Loop until the player enters a valid input
            while (input != '1' && input != '2')
            {
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            return input;
        }

        char GetInput(string option1, string option2, string option3)
        {
            char input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. " + option3);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            return input;
        }

        //Prints the stats given in the parameter list to the console
        void PrintStats(string name, int health, int damage, int defense)
        {
            Console.WriteLine("\n" + name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Defense: " + defense);
        }

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            SelectCharacter();
        }

        //Repeated until the game ends
        public void Update()
        {
            ClimbLadder(0);
        }

        //Performed once when the game ends
        public void End()
        {
            //If the player died print death message
            if (_playerHealth <= 0)
            {
                Console.WriteLine("Failure to live");
            }
            //Print game over message
            Console.WriteLine("Congrats the game is over");
        }
    }
}
