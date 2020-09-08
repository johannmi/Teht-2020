using System;
using System.Collections.Generic;
using System.Linq;

namespace Teht002
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> playerList = new List<Player>();

            // TEHT 1
            //createPlayers(playerList);
            //checkDuplicates(playerList);

            Player player = new Player();
            player.Items = new List<Item>();
            player.Items.Add(new Item(1, Guid.NewGuid()));
            player.Items.Add(new Item(5, Guid.NewGuid()));
            player.Items.Add(new Item(3, Guid.NewGuid()));

            // TEHT 2
            testItems(player);

            // TEHT 3
            Item[] items1 = GetItems(player);
            printItemArray(items1);
            Item[] items2 = GetItemsWithLinq(player);
            printItemArray(items2);

            // TEHT 4
            Item itemFirst1 = FirstItem(player);
            Console.WriteLine(itemFirst1.Level);
            Item itemFirst2 = FirstItemWithLinq(player);
            Console.WriteLine(itemFirst2.Level);

            // TEHT 5
            ProcessEachItem(player, PrintItem);

            // TEHT 6
            Action<Item> process = (item) => 
                Console.WriteLine("GUID: " + item.Id + ", Level: " + item.Level);
            ProcessEachItem(player, process);
        }

        // TEHT 5
        static void ProcessEachItem(Player player, Action<Item> process){
            foreach(Item i in player.Items) {
                process(i);
            }
        }

        static void PrintItem(Item item) {
            Console.WriteLine("GUID: " + item.Id + ", Level: " + item.Level);
        }

        // TEHT 4
        static Item FirstItem(Player player) {
            if(player.Items.Count == 0) {
                return null;
            } else {
                return player.Items[0];
            }
        }

        static Item FirstItemWithLinq(Player player) {
            return player.Items.First();
        }

        // TEHT 3
        static Item[] GetItems(Player player) {
            Item[] itemList = new Item[player.Items.Count];

            for(int i = 0; i < player.Items.Count; i++) {
                itemList[i] = player.Items[i];
            }

            return itemList;
        }

        static Item[] GetItemsWithLinq(Player player) {
            return player.Items.ToArray();
        }

        // TEHT 2
        static void testItems(Player player) {
            var highestLevelItem = player.GetHighestLevelItem();
            Console.WriteLine("Highest level item: " + highestLevelItem.Level);
        }

        // TEHT 1
        static void createPlayers(List<Player> playerList) {
            for (int i = 0; i < 1000000; i++) {
                Player newPlayer = new Player();
                newPlayer.Id = Guid.NewGuid();
                playerList.Add(newPlayer);
            }
        }

        static void checkDuplicates(List<Player> playerList) {
            var playerDupes = playerList
                .GroupBy(x => x.Id)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToList();

            if(playerDupes.Count > 0) {
                Console.WriteLine("Duplicates found");
            } else {
                Console.WriteLine("No duplicates");
            }
        }

        static void printItemArray(Item[] items) {
            foreach(Item i in items) {
                Console.WriteLine(i.Level);
            }
        }

        
    }
}
