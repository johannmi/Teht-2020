using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GameWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //FileRepository fileRepository = new FileRepository();
            //fileRepository.Create(newPlayerTest());
            //fileRepository.Get(new Guid("85fdc7f0-28a8-4b74-854c-30644e30a13d"));
            //fileRepository.GetAll();
            //fileRepository.Modify(new Guid("a2900f7c-f578-4e4f-9a0f-f6a01c7118da"), new ModifiedPlayer(235));
            //fileRepository.Delete(new Guid("85fdc7f0-28a8-4b74-854c-30644e30a13d"));
        }

        public static Player newPlayerTest() {
            Player player = new Player();

            player.Id = Guid.NewGuid();
            player.IsBanned = false;
            player.Level = 1;
            player.Name = "new burger";
            player.Score = 0;
            player.CreationTime = DateTime.Now;

            return player;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
