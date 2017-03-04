﻿using System;
using System.Collections.Generic;
using Kontur.GameStats.Server.DataModels;

namespace Kontur.GameStats.Server.DataBase
{
    public interface IDatabaseAdapter
    {
        void AddServerInfo(GameServerInfo server);
        void AddMatchInfo(MatchInfo match);

        GameServerInfo GetServerInfo(string endpoint);
        MatchInfo GetMatchInfo(string endpoint, DateTime timestamp);

        IEnumerable<GameServerInfo> GetServers();
        IEnumerable<MatchInfo> GetMatches(string endpoint);
    }
}