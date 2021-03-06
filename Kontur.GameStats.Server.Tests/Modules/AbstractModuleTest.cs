﻿using System.Configuration;
using System.IO;
using Kontur.GameStats.Server.DataModels;
using Kontur.GameStats.Server.NancyModules.NancyConfiguration;
using Kontur.GameStats.Server.Utility;
using Nancy.Testing;
using NUnit.Framework;

namespace Kontur.GameStats.Server.Tests.Modules
{
  public abstract class AbstractModuleTest
  {
    protected Browser Browser;
    protected Bootstrapper Bootstrapper;

    protected ServerInfo Server;
    protected MatchResult Match;
    protected string Endpoint;
    protected string Timestamp;

    [SetUp]
    public void SetUp()
    {
      Bootstrapper = new Bootstrapper();
      Browser = new Browser(Bootstrapper);

      Server = TestData.Server.info;
      Match = TestData.Match.result;
      Endpoint = TestData.Server.endpoint;
      Timestamp = TestData.Match.timestamp.ToUtcString();
    }

    [TearDown]
    public void Cleanup()
    {
      Bootstrapper.Dispose();
      var directory = ConfigurationManager.AppSettings["database_directory"];
      ClearDirectory(directory);
    }

    private static void ClearDirectory(string path)
    {
      var dir = new DirectoryInfo(path);
      foreach (var file in dir.GetFiles())
      {
        file.Delete();
      }
    }
  }
}