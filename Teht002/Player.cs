using System;
using System.Collections.Generic;
using System.Linq;
public class Player : IPlayer
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    public List<Item> Items { get; set; }
}

public static class PlayerExtensions
{
    public static Item GetHighestLevelItem(this Player player) {
        Item item = null;

        if(player.Items.Count == 0) {
            return item;
        } else {
            item = player.Items[0];
        }

        foreach(Item i in player.Items) {
            if(i.Level > item.Level) {
                item = i;
            }
        }

        return item;
    }
}