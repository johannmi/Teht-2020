using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

public class FileRepository : IRepository
{
    public Task<Player> Get(Guid id){
        string jsonString;
        jsonString = File.ReadAllText("game-dev.txt");
        PlayerList players = JsonConvert.DeserializeObject<PlayerList>(jsonString);

        foreach(Player p in players.playerList){
            if(p.Id == id){
                //Console.WriteLine("Get: " + p.Name);
                return Task.FromResult(p);
            }
        }

        return null;
    }

    public Task<Player[]> GetAll(){
        string jsonString;
        jsonString = File.ReadAllText("game-dev.txt");
        PlayerList players = JsonConvert.DeserializeObject<PlayerList>(jsonString);

        /*
        for (int i = 0; i < players.playerList.Count; i++) {
            Console.WriteLine(players.playerList.ToArray()[i].Name);
        }
        */

        return Task.FromResult(players.playerList.ToArray());
    }

    public Task<Player> Create(Player player){
        string jsonString;
        PlayerList players = new PlayerList();

        if(new FileInfo("game-dev.txt").Length == 0)
        {
            players.playerList.Add(player);
            jsonString = JsonConvert.SerializeObject(players);
        } 
        else 
        {
            jsonString = File.ReadAllText("game-dev.txt");
            players = JsonConvert.DeserializeObject<PlayerList>(jsonString);
            players.playerList.Add(player);
            jsonString = JsonConvert.SerializeObject(players);
        }
        File.WriteAllText("game-dev.txt", jsonString);

        //Console.WriteLine(jsonString);
        
        return Task.FromResult(player);
    }

    public Task<Player> Modify(Guid id, ModifiedPlayer player){
        string jsonString;
        jsonString = File.ReadAllText("game-dev.txt");
        PlayerList players = JsonConvert.DeserializeObject<PlayerList>(jsonString);

        foreach(Player p in players.playerList){
            if(p.Id == id){
                p.Score = player.Score;
                jsonString = JsonConvert.SerializeObject(players);
                File.WriteAllText("game-dev.txt", jsonString);
                        
                return Task.FromResult(p);
            }
        }

        return null;
    }

    public Task<Player> Delete(Guid id){
        string jsonString;
        jsonString = File.ReadAllText("game-dev.txt");
        PlayerList players = JsonConvert.DeserializeObject<PlayerList>(jsonString);
        int index = 0;
        
        foreach(Player p in players.playerList){
            if(p.Id == id){
                players.playerList.Remove(players.playerList[index]);
                jsonString = JsonConvert.SerializeObject(players);
                File.WriteAllText("game-dev.txt", jsonString);
                        
                return Task.FromResult(p);
            }
            index++;
        }

        return null;
    }
}