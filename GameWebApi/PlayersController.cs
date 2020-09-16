using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/players")]
public class PlayersController : ControllerBase
{
    private readonly IRepository repo;
    public PlayersController(IRepository repository) 
    {
        repo = repository;
    }

    [Route("{id}")]
    [HttpGet]
    public Task<Player> Get(Guid id) {
        return repo.Get(id);
    }

    [Route("")]
    [HttpGet]
    public Task<Player[]> GetAll() {
        return repo.GetAll();
    }

    [Route("new/{name}")]
    [HttpPost]
    public Task<Player> Create(string name) {
        Player newPlayer = new Player();

        newPlayer.Id = Guid.NewGuid();
        newPlayer.IsBanned = false;
        newPlayer.Level = 1;
        newPlayer.Name = name;
        newPlayer.Score = 0;
        newPlayer.CreationTime = DateTime.Now;

        return repo.Create(newPlayer);
    }

    [Route("modify/{id}/{player}")]
    [HttpPost]
    public Task<Player> Modify(Guid id, ModifiedPlayer player) {
        return repo.Modify(id, player);
    }

    [Route("delete/{id}")]
    [HttpDelete]
    public Task<Player> Delete(Guid id) {
        return repo.Delete(id);
    }
}