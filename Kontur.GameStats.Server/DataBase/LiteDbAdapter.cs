﻿using System;
using System.Collections.Generic;
using Kontur.GameStats.Server.DataModels;
using LiteDB;

namespace Kontur.GameStats.Server.Database
{
    public class LiteDbAdapter : IDatabaseAdapter
    {
        private readonly LiteDatabase database;

        public LiteDbAdapter(string filename)
        {
            database = new LiteDatabase(filename);
        }

        public void AddServerInfo(GameServerInfo server)
        {
            throw new NotImplementedException();
        }

        public void AddMatchInfo(MatchInfo match)
        {
            throw new NotImplementedException();
        }

        public GameServerInfo GetServerInfo(string endpoint)
        {
            throw new NotImplementedException();
        }

        public MatchInfo GetMatchInfo(string endpoint, DateTime timestamp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameServerInfo> GetServers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatchInfo> GetMatches(string endpoint)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}