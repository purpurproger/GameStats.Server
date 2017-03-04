﻿using System.Collections.Generic;
using FluentAssertions;
using Kontur.GameStats.Server.Database;
using Kontur.GameStats.Server.DataModels;
using NUnit.Framework;

namespace Tests.Database
{
    [TestFixture]
    public class DbAdapterShould
    {
        #region models for testing

        private readonly GameServerInfo serverInfo1 = new GameServerInfo
        {
            endpoint = "kontur.ru-1024",
            gameServer = new GameServer
            {
                name = "] My P3rfect GameServer [",
                gameModes = new[] { "DM", "TDM" }
            }
        };

        private readonly GameServerInfo serverInfo2 = new GameServerInfo
        {
            endpoint = "192.168.35.38",
            gameServer = new GameServer
            {
                name = "LocalServer",
                gameModes = new[] { "SM", "OPM", "DM" }
            }
        };

        private readonly GameServerInfo serverInfo3 = new GameServerInfo
        {
            endpoint = "g-games.com-2048",
            gameServer = new GameServer
            {
                name = "Geeks only", //todo remove
                gameModes = new[] { "DM" }
            }
        };

        #endregion
        
        [Test]
        public void ShouldReturnAddedServerInfo()
        {
            using (var file = new TempFile())
            {
                using (var db = new LiteDbAdapter(file.Filename))
                {
                    db.AddServerInfo(serverInfo1);
                    var result = db.GetServerInfo(serverInfo1.endpoint);

                    result.ShouldBeEquivalentTo(serverInfo1);
                }
            }
        }

        [Test]
        public void ReturnAllGivenServerInfo()
        {
            using (var file = new TempFile())
            {
                using (var db = new LiteDbAdapter(file.Filename))
                {
                    IList<GameServerInfo> serverInfos = new[] { serverInfo1, serverInfo2, serverInfo3 };
                    foreach (var info in serverInfos)
                    {
                        db.AddServerInfo(info);
                    }

                    var result = db.GetServers();

                    result.Should().Equal(serverInfos, ComparisonExtensions.Equal);
                }
            }
        }


    }
}