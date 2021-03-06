﻿using System;
using Kontur.GameStats.Server.Utility;

namespace Kontur.GameStats.Server.DataModels
{
  public class ServerInfo:IEquatable<ServerInfo>
  {
    public string name { get; set; }
    public string[] gameModes { get; set; }

    #region equality members

    public bool Equals(ServerInfo other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      if(!string.Equals(name, other.name)) return false;
      return gameModes.CompareWithoutOrder(other.gameModes);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((ServerInfo) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return ((name?.GetHashCode() ?? 0)*397) ^ (gameModes?.GetHashCode() ?? 0);
      }
    }

    #endregion
  }
}