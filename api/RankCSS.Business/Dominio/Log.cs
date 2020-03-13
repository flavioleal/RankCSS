using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Player> LerAquivoLogTxt()
        {
            string execDir = System.Environment.CurrentDirectory + "\\..\\..\\log";         
            string text = System.IO.File.ReadAllText(@"C:\Sites\Rank\log\jogo.log");

            var split = text.Split("\r\n");

            BuscarJogadores(split);
            BuscarKillPorPlayer(text);

            Players = Players
                .GroupBy(i => i.Address)
                .Select(j => new Player()
                {
                    Address = j.First().Address,
                    Kill = j.Sum(ij => ij.Kill),
                    Death = j.Sum(ij => ij.Death),
                    Assistance = j.Sum(ij => ij.Assistance),
                    FriendlyFire = j.Sum(ij => ij.FriendlyFire),
                    Nickname = j.First().Nickname,
                }).OrderByDescending(x => x.Pontuation)
                .ToList();

            return Players;

            //foreach (var player in Players)
            //{
            //    Console.WriteLine($"Nick: {player.Nickname}    |    Kill: {player.Kill}");
            //}
        }

        public void BuscarJogadores(string[] log)
        {
            var listaPlayers = log.Where(x => x.Contains(" connected"));


            foreach (var item in listaPlayers)
            {

                if (!item.Contains("><BOT><>"))
                {

                    var split = item.Split("\"");
                    var fimNickname = split[1].IndexOf('<');
                    var player = new Player();
                    player.Nickname = split[1][0..fimNickname];
                    player.Address = split[3];


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
            var rounds = log.Split("Round_End");



            foreach (var round in rounds)
            {
                MudarNickName(round);
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

        public void MudarNickName(string round)
        {
            if (round.Contains("changed name to"))
            {
                var splitNicknameAntigo = round.Split("changed name to");

                splitNicknameAntigo[0] = splitNicknameAntigo[0].Remove(0, 1);
                var inicioNickname = splitNicknameAntigo[0].IndexOf("\"") + 1;
                var fimNickname = splitNicknameAntigo[0].IndexOf("<");
                var nicknameAntigo = splitNicknameAntigo[0][inicioNickname..fimNickname];

                var nicknameNovo = splitNicknameAntigo[1].Trim().Split("\r\n");

                foreach (var player in Players)
                {
                    if (player.Nickname == nicknameAntigo)
                    {
                        player.Nickname = nicknameNovo[0];
                    }
                }
            }
        }

        public string BuscarPlayer(string item)
        {

            var inicioNickname = item.IndexOf("\"") + 1;
            var fimNickname = item.IndexOf("<");
            var nickname = item[inicioNickname..fimNickname];

            return nickname;
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

        public decimal Pontuation
        {
            get
            {
                return (Kill - Death - FriendlyFire);
            }
        }
    }

}
