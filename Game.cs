using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    /*struct Player
    {
        public int health;
        public int damage;
        public int defense;
        public string name;
        public int levelScaleMax;
    }*/

    struct Player
    {
        public string name;
        public float health;
    }

    struct Item
    {
        public string name;
        public float damage;
    }

    class Game
    {
        bool _gameOver = false;
        Player player1;
        Player player2;
        Item weapon1;
        Item weapon2;

        void Introduction()
        {
            Console.WriteLine("Hello Gamers!!");
            Console.WriteLine("Player 1 please give your name.");
            Console.Write("> ");
            player1.name = Console.ReadLine();
            Console.WriteLine(player1.name + " ...wow what a great name.");
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Player 2 please give your name.");
            Console.Write("> ");
            player2.name = Console.ReadLine();
            Console.WriteLine("Hello " + player2.name + ", what a beautiful name!");
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
            char input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                Console.WriteLine("Player 1, please select a weapon.");
                input = GetInput("Sword", "Daggers", "Staff");
                switch (input)
                {
                    case '1':
                        Console.WriteLine("Wow you chose the sword. How basic.");
                        weapon1.name = "Sword";
                        weapon1.damage = 10.0f;
                        player1.health = 100.0f;
                        break;
                    case '2':
                        Console.WriteLine("You chose the daggers, bet you think you're cool.");
                        weapon1.name = "Daggers";
                        weapon1.damage = 15.0f;
                        player1.health = 80.0f;
                        break;
                    case '3':
                        Console.WriteLine("Really? The staff? Okay.");
                        weapon1.name = "Staff";
                        weapon1.damage = 20.0f;
                        player1.health = 60.0f;
                        break;
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                Console.WriteLine("Player 2, please select a weapon.");
                input = GetInput("Sword", "Daggers", "Staff");
                switch (input)
                {
                    case '1':
                        Console.WriteLine("You chose the sword. A fine choice!");
                        weapon2.name = "Sword";
                        weapon2.damage = 10.0f;
                        player2.health = 100.0f;
                        break;
                    case '2':
                        Console.WriteLine("You chose the daggers. Sharp and fast. Good choice.");
                        weapon2.name = "Daggers";
                        weapon2.damage = 15.0f;
                        player2.health = 80.0f;
                        break;
                    case '3':
                        Console.WriteLine("You chose the staff. Good luck mighty wizard!");
                        weapon2.name = "Staff";
                        weapon2.damage = 20.0f;
                        player2.health = 60.0f;
                        break;
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Players! Get Ready for a mighty battle!");
            Console.WriteLine("Good Luck " + player2.name + "!");
            Console.WriteLine("Press any key to start");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        void Battle()
        {
            GetBattleStats();
            Console.WriteLine(player2.name + " goes first!");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
            while (player1.health > 0 && player2.health > 0)
            {
                char input = ' ';
                while (input != '1' && input != '2')
                {
                    GetBattleStats();
                    Console.WriteLine("Player 2's turn");
                    Console.WriteLine("What will you do?");
                    input = GetInput("Attack", "Kill " + player1.name);
                    switch (input)
                    {
                        case '1':
                            Console.WriteLine(player2.name + " dealt " + weapon2.damage + " damage!");
                            player1.health -= weapon2.damage;
                            Console.WriteLine("Press any key to continue");
                            Console.Write("> ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case '2':
                            Console.WriteLine("You kill " + player1.name + ". Congrats!!");
                            Console.WriteLine("You win!");
                            player1.health = 0.0f;
                            Console.WriteLine("Press any key to continue");
                            Console.Write("> ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                if (player1.health > 0)
                {
                    input = ' ';
                    while (input != '1' && input != '2')
                    {
                        GetBattleStats();
                        Console.WriteLine("Player 1's turn");
                        Console.WriteLine("What will you do?");
                        input = GetInput("Attack", "Kill yourself");
                        switch (input)
                        {
                            case '1':
                                Console.WriteLine(player1.name + " dealt " + weapon1.damage + " damage!");
                                player2.health -= weapon1.damage;
                                Console.WriteLine("Press any key to continue");
                                Console.Write("> ");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case '2':
                                Console.WriteLine("Im sorry it had to end this way.");
                                player1.health = 0.0f;
                                Console.WriteLine("Press any key to continue");
                                Console.Write("> ");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                }
                if (player2.health <= 0.0f)
                {
                    Console.WriteLine(player2.name + " died.");
                    Console.WriteLine("Let's try that again.");
                    player2.health = 1000000;
                    weapon2.damage = 1000000;
                    Console.WriteLine("Press any key to continue");
                    Console.Write("> ");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
            _gameOver = true;
        }

        void GetBattleStats()
        {
            Console.WriteLine(player1.name + ": " + player1.health + "          " + player2.name + ": " + player2.health);
            Console.WriteLine("______________________________");
            Console.WriteLine("");
        }
        
        /*

        Player player1;
        bool _gameOver = false;
        Player playerEnemy;

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
                        player1.name = "Sir Kibble";
                        player1.health = 120;
                        player1.defense = 10;
                        player1.damage = 40;
                        break;
                    case '2':
                        player1.name = "Gnojoel";
                        player1.health = 40;
                        player1.defense = 2;
                        player1.damage = 70;
                        break;
                    case '3':
                        player1.name = "Joedazz";
                        player1.health = 200;
                        player1.defense = 5;
                        player1.damage = 25;
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
            PrintStats(player1);
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
            if (player1.health > 0)
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
            playerEnemy.health = 0;
            playerEnemy.damage = 0;
            playerEnemy.defense = 0;
            playerEnemy.name = " ";
            //Changes the enemy's default stats based on our current room number. 
            //This is how we make it seem as if the player is fighting different enemies
            switch (roomNum)
            {
                case 0:
                    playerEnemy.health = 100;
                    playerEnemy.damage = 20;
                    playerEnemy.defense = 5;
                    playerEnemy.name = "Wizard";
                    break;
                case 1:
                    playerEnemy.health = 80;
                    playerEnemy.damage = 30;
                    playerEnemy.defense = 5;
                    playerEnemy.name = "Troll";
                    
                    break;
                case 2:
                    playerEnemy.health = 200;
                    playerEnemy.damage = 40;
                    playerEnemy.defense = 10;
                    playerEnemy.name = "Giant";
                    break;
            }

            //Loops until the player or the enemy is dead
            while (player1.health > 0 && playerEnemy.health > 0)
            {
                //Displays the stats for both charactersa to the screen before the player takes their turn
                PrintStats(player1);
                PrintStats(playerEnemy);

                //Get input from the player
                char input = ' ';
                input = GetInput("Attack", "Defend");
                //If input is 1, the player wants to attack. By default the enemy blocks any incoming attack
                if (input == '1')
                {
                    BlockAttack(ref playerEnemy.health, player1.damage, playerEnemy.defense, player1.name);
                    player1.health -= playerEnemy.damage;
                    Console.WriteLine(playerEnemy.name + " dealt " + playerEnemy.damage + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();
                    turnCount++;
                    Console.Clear();
                }
                //If the player decides to defend the enemy just takes their turn. However this time the block attack function is
                //called instead of simply decrementing the health by the enemy's attack value.
                else if (input == '2')
                {
                    BlockAttack(ref player1.health, playerEnemy.damage, player1.defense, playerEnemy.name);
                    Console.Write("> ");
                    Console.ReadKey();
                    turnCount++;
                    Console.Clear();
                }
            }
            //Return whether or not our player died
            return player1.health != 0;
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
            int scale = player1.levelScaleMax - turnCount;
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
                switch(player1.name)
                {
                    case "Sir Kibble":
                        player1.health = 120;
                        player1.defense = 10;
                        player1.damage = 40;
                        player1.health += 10 * scale;
                        break;
                    case "Gnojoel":
                        player1.health = 40;
                        player1.defense = 2;
                        player1.damage = 70;
                        player1.health += 10 * scale;
                        break;
                    case "Joedazz":
                        player1.health = 200;
                        player1.defense = 5;
                        player1.damage = 25;
                        player1.health += 10 * scale;
                        break;
                }
            }
            else if (input == '2')
            {
                Console.WriteLine("You upgraded your damage.");
                switch (player1.name)
                {
                    case "Sir Kibble":
                        player1.health = 120;
                        player1.defense = 10;
                        player1.damage = 40;
                        player1.damage *= scale;
                        break;
                    case "Gnojoel":
                        player1.health = 40;
                        player1.defense = 2;
                        player1.damage = 70;
                        player1.damage *= scale;
                        break;
                    case "Joedazz":
                        player1.health = 200;
                        player1.defense = 5;
                        player1.damage = 25;
                        player1.damage *= scale;
                        break;
                }
            }
            if(input == '3')
            {
                Console.WriteLine("You upgraded your defense.");
                switch (player1.name)
                {
                    case "Sir Kibble":
                        player1.health = 120;
                        player1.defense = 10;
                        player1.damage = 40;
                        player1.damage *= scale;
                        break;
                    case "Gnojoel":
                        player1.health = 40;
                        player1.defense = 2;
                        player1.damage = 70;
                        player1.damage *= scale;
                        break;
                    case "Joedazz":
                        player1.health = 200;
                        player1.defense = 5;
                        player1.damage = 25;
                        player1.damage *= scale;
                        break;
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        */

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

        /*

        //Prints the stats given in the parameter list to the console
        void PrintStats(Player player)
        {
            Console.WriteLine("\n" + player.name);
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
            Console.WriteLine("Defense: " + player.defense);
        }

        */

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
            Introduction();
            //SelectCharacter();
        }

        //Repeated until the game ends
        public void Update()
        {
            Battle();
            //ClimbLadder(0);
        }

        //Performed once when the game ends
        public void End()
        {

            Console.WriteLine(player2.name + " WON!!");
            Console.WriteLine("GAME OVER");

            /*

            //If the player died print death message
            if (player1.health <= 0)
            {
                Console.WriteLine("Failure to live");
            }
            //Print game over message
            Console.WriteLine("Congrats the game is over");

            */

        }
    }
}
