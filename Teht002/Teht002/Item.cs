using System;

public class Item
{
    public Guid Id { get; set; }
    public int Level { get; set; }

    public Item() {}

    public Item(int _level, Guid _guid) {
        Level = _level;
        Id = _guid;
    }
}