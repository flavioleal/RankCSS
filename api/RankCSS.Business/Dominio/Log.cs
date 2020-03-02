using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankCSS.Business.Dominio
{
    public class Log
    {
        public Log()
        {
            Players = new List<Player>();
        }
        public List<Player> Players { get; set; }
        public void LerAquivoLogTxt()
        {
            string text = System.IO.File.ReadAllText(@"C:\Flavio\cs\Counter-Strike Source\cstrike\logs\l0302001.log");

            var split = text.Split("\r\n");

            BuscarJogadores(split);
            BuscarKillPorPlayer(text);


            var id = 0;
        }

        public void BuscarJogadores(string[] log)
        {
            var listaPlayers = log.Where(x => x.Contains(" connected"));


            foreach (var item in listaPlayers)
            {

                if (!item.Contains("><BOT><>"))
                {

                    var split = item.Split(" ");
                    var fimNickname = split[4].IndexOf("<");
                    var player = new Player();
                    player.Nickname = split[4][1..fimNickname];
                    player.Address = split[7];


                    if (!Players.Any(x => x.Nickname == player.Nickname && x.Address == player.Address))
                    {
                        Players.Add(player);
                    }
                }
            }

        }

        public void BuscarKillPorPlayer(string log)
        {
            var idx = log.IndexOf("Game_Commencing");
            log = log.Remove(0, idx);
            var rounds = log.Split("World triggered");


            foreach (var round in rounds)
            {
                var roundDatail = round.Split("\r\n");
                var listaKill = roundDatail.Where(x => x.Contains("killed"));
                foreach (var killed in listaKill)
                {
                    var killedDatail = killed.Split("killed");
                    foreach (var player in Players)
                    {

                        if ((killedDatail[0].Contains("TERRORIST") && killedDatail[1].Contains("TERRORIST")) || (killedDatail[0].Contains("CT") && killedDatail[1].Contains("CT")))
                        {
                            //remover kill
                            if (player.Nickname == BuscarPlayer(killedDatail[0]))
                            {
                                player.Kill -= 1;
                                player.FriendlyFire += 1;
                            }
                        }
                        else
                        {
                            //atribuir kill
                            if (player.Nickname == BuscarPlayer(killedDatail[0]))
                            {
                                player.Kill += 1;
                            }
                        }

                        //atribuir death
                        if (player.Nickname == BuscarPlayer(killedDatail[1]))
                        {
                            player.Death += 1;
                        }

                    }
                }
            }

        }
        public string BuscarPlayer(string item)
        {
            var inicioNickname = item.IndexOf("\"") + 1;
            var fimNickname = item.IndexOf("<");
            var player = item[inicioNickname..fimNickname];
            return player;
        }
    }

    public class Player
    {
        public string Nickname { get; set; }
        public string Address { get; set; }
        public int Kill { get; set; }
        public decimal Assistance { get; set; }
        public int Death { get; set; }
        public decimal FriendlyFire { get; set; }
    }

}
