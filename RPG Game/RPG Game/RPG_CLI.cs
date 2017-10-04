using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game.DALs;
using RPG_Game.Models;

namespace RPG_Game
{
    public class RPG_CLI
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=RPG Database;User ID=te_student;Password=sqlserver1";

        public void Run()
        {
            while (true)
            {
                Console.WriteLine(@" ______   _______  _______  _______    _______  _        _______           _______  _______  ");
                Console.WriteLine(@"|  __  \ (  ___  )(  ___  )(       )  (  ____ \( \      (  ___  )|\     /|(  ____ \(  ____ ) ");
                Console.WriteLine(@"| (  \  )| (   ) || (   ) || () () |  | (    \/| (      | (   ) |( \   / )| (    \/| (    )| ");
                Console.WriteLine(@"| |   ) || |   | || |   | || || || |  | (_____ | |      | (___) | \ (_) / | (__    | (____)| ");
                Console.WriteLine(@"| |   | || |   | || |   | || |(_)| |  (_____  )| |      |  ___  |  \   /  |  __)   |     __) ");
                Console.WriteLine(@"| |   ) || |   | || |   | || |   | |        ) || |      | (   ) |   ) (   | (      | (\ (    ");
                Console.WriteLine(@"| (__/  )| (___) || (___) || )   ( |  /\____) || (____/\| )   ( |   | |   | (____/\| ) \ \__ ");
                Console.WriteLine(@"|______/ (_______)(_______)|/     \|  \_______)(_______/|/     \|   \_/   (_______/|/   \__/ ");

                Console.WriteLine();
                Console.WriteLine("1.) Print Player List");
                Console.WriteLine("2.) Add Player");
                Console.WriteLine("3.) Show Specific Player");
                Console.WriteLine("4.) Print All Available Inventory");
                Console.WriteLine("5.) Add Inventory");
                Console.WriteLine("6.) Print All Non-Human Players");
                Console.WriteLine("7.) Add A Non-Human Player");
                Console.WriteLine("8.) Print All Stores");
                Console.WriteLine("9.) Show Inventory Of Specific Store");
                Console.WriteLine("10.) Show Player's Inventory");
                Console.WriteLine("Q.) Quit Program");
                Console.WriteLine();

                string input = CLIHelper.GetString("Make a choice");

                switch (input.ToLower())
                {
                    case "1":
                        ShowAllPlayers();
                        break;

                    case "2":
                        AddNewPlayer();
                        break;

                    case "3":
                        ShowSpecificPlayer();
                        break;

                    case "4":
                        ShowAllInventory();
                        break;

                    case "5":
                        AddInventory();
                        break;

                    case "6":
                        ShowAllNonHumanEntity();
                        break;

                    case "7":
                        AddNonHumanEntity();
                        break;

                    case "8":
                        ShowAllStores();
                        break;

                    case "9":
                        ShowInventoryOfStore();
                        break;

                    case "10":
                        ShowPlayersInventory();
                        break;

                    case "q":
                        Console.WriteLine("Quiting");
                        Console.ReadLine();
                        return;
                }
            }
        }
        private void ShowAllPlayers()
        {
            Console.WriteLine("SHOWING ALL PLAYERS");

            PlayerDAL dal = new PlayerDAL(connectionString);

            List<Player> allPlayers = dal.GetAllPlayers();
            int count = 1;
            foreach (Player p in allPlayers)
            {
                Console.WriteLine();
                Console.WriteLine($"{count++}.) {p.Name} - {p.PlayerType}");
                Console.WriteLine($"Level: {p.Level}");
                Console.WriteLine($"Gold: {p.Gold} coins  Experience Points: {p.XP}");
                Console.WriteLine($"Life: {p.Life} Gender: {p.Gender} Strength: {p.Strength}");
                Console.WriteLine();
                Console.WriteLine($"Attributes:");
                Console.WriteLine($"Attack: {p.Attack} Defense: {p.Defense} Magic: {p.Magic}");
            }
            Console.ReadLine();
            Console.Clear();
        }

        private void AddNewPlayer()
        {
            string name = CLIHelper.GetString("What name would you like?");
            string playerType = "";
            int strength = 0;
            int attack = 0;
            int defense = 0;
            int magic = 0;

            Console.WriteLine("1.) Human");
            Console.WriteLine("2.) Elf");
            Console.WriteLine("3.) Dark Elf");
            Console.WriteLine("4.) Dwarf");
            Console.WriteLine("5.) Mage");

            string input = CLIHelper.GetString("What race would you like to be?");

            switch (input.ToLower())
            {
                case "1":
                    playerType = "Human";
                    strength = 2;
                    attack = 1;
                    defense = 1;
                    magic = 1;
                    break;

                case "2":
                    playerType = "Elf";
                    strength = 1;
                    attack = 2;
                    defense = 1;
                    magic = 2;
                    break;

                case "3":
                    playerType = "Dark Elf";
                    strength = 1;
                    attack = 2;
                    defense = 1;
                    magic = 2;
                    break;

                case "4":
                    playerType = "Dwarf";
                    strength = 2;
                    attack = 2;
                    defense = 2;
                    magic = 1;
                    break;

                case "5":
                    playerType = "Mage";
                    strength = 1;
                    attack = 1;
                    defense = 1;
                    magic = 3;
                    break;
            }

            string gender = CLIHelper.GetString("What gender would you like to be");

            Player p = new Player();
            p.Name = name;
            p.Life = 25;
            p.Gender = gender.ToUpper();
            p.XP = 0;
            p.Strength = strength;
            p.Attack = attack;
            p.Defense = defense;
            p.Magic = magic;
            p.Level = 1;
            p.Gold = 10;
            p.PlayerType = playerType;

            PlayerDAL dal = new PlayerDAL(connectionString);
            dal.AddNewPlayer(p);

            Console.WriteLine("Successfully Added");

            Console.ReadLine();
            Console.Clear();

        }

        private void ShowSpecificPlayer()
        {
            string userName = CLIHelper.GetString("What's your the name of your character?");
            PlayerDAL dal = new PlayerDAL(connectionString);
            Player p = new Player();
            p = dal.SearchPlayer(userName);
            Console.WriteLine();
            Console.WriteLine($"{p.Name} - {p.PlayerType}");
            Console.WriteLine($"Level: {p.Level}");
            Console.WriteLine($"Gold: {p.Gold} coins  Experience Points: {p.XP}");
            Console.WriteLine($"Life: {p.Life} Gender: {p.Gender} Strength: {p.Strength}");
            Console.WriteLine();
            Console.WriteLine($"Attributes:");
            Console.WriteLine($"Attack: {p.Attack} Defense: {p.Defense} Magic: {p.Magic}");

            Console.ReadLine();
            Console.Clear();

        }

        private void ShowAllInventory()
        {
            Console.WriteLine("SHOWING ALL INVENTORY");

            InventoryDAL dal = new InventoryDAL(connectionString);

            List<Inventory> allInventory = dal.GetAllInventory();
            int count = 1;

            foreach (Inventory i in allInventory)
            {
                Console.WriteLine("");
                Console.WriteLine($"{count++}.) {i.Name} - {i.SubType} - {i.Type}");
                Console.WriteLine($"Weight - {i.Weight}kg ");
                Console.WriteLine($"How it affects your attributes:");
                Console.WriteLine($"Strength {i.StrengthProp} Attack {i.AttackProp} Defense {i.DefenseProp} Magic {i.MagicProp}");
            }
            Console.ReadLine();
            Console.Clear();

        }

        private void AddInventory()
        {
            Console.WriteLine();

            Console.WriteLine("1.) Weapon");
            Console.WriteLine("2.) Potion");
            Console.WriteLine("3.) Ingredient");
            Console.WriteLine("4.) Ore");
            Console.WriteLine("5.) Clothing");
            Console.WriteLine();
            string input = CLIHelper.GetString("What is the type of inventory item that you would like to add?");

            string type = "";
            switch (input.ToLower())
            {
                case "1":
                    type = "Weapon";
                    break;

                case "2":
                    type = "Potion";
                    break;

                case "3":
                    type = "Ingredient";
                    break;

                case "Ore":
                    type = "Ore";
                    break;

                case "Clothing":
                    type = "Clothing";
                    break;
            }
            string name = CLIHelper.GetString("What is the name of your item?");
            string subType = CLIHelper.GetString($"What kind of {type} is this?");
            double weight = CLIHelper.GetDouble($"What is the weight of {name}?");
            int strengthProp = CLIHelper.GetInteger($"How does {name} change your strength attribute?");
            int attackProp = CLIHelper.GetInteger($"How does {name} change your attack attribute?");
            int defenseProp = CLIHelper.GetInteger($"How does {name} change your defense attribute?");
            int magicProp = CLIHelper.GetInteger($"How does {name} change your magic attribute?");

            Inventory item = new Inventory();

            item.Name = name;
            item.Type = type;
            item.SubType = subType;
            item.Weight = Convert.ToDecimal(weight);
            item.StrengthProp = strengthProp;
            item.AttackProp = attackProp;
            item.DefenseProp = defenseProp;
            item.MagicProp = magicProp;

            InventoryDAL dal = new InventoryDAL(connectionString);
            dal.AddInventory(item);

            Console.WriteLine("SUCCESSFULLY CREATED");
            Console.ReadLine();
            Console.Clear();
        }

        private void ShowAllNonHumanEntity()
        {

        }

        private void AddNonHumanEntity()
        {

        }

        private void ShowAllStores()
        {

        }

        private void ShowInventoryOfStore()
        {

        }

        private void ShowPlayersInventory()
        {

        }
    }
}
