using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayAjo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Services
{
  public class Service
  {
    private readonly PayAjoContext _repo;
    public Service(PayAjoContext repo)
    {
      _repo = repo;
    }

    // Check if merchant is valide or not to be able to grant access to resource  ..
    public static string EncryptPassword(string password, string salt = "")
    {
      string text = salt + password;
      var UE = new UTF8Encoding();
      byte[] hashValue;
      byte[] message = UE.GetBytes(text);

      SHA512Managed hashString = new SHA512Managed();
      string hex = "";

      hashValue = hashString.ComputeHash(message);
      foreach (byte x in hashValue)
      {
        hex += String.Format("{0:x2}", x);
      }
      return hex;
    }

    protected internal Operation<string> GenerateUnique() => Operation.Create(() =>
    {
      uint RandomInt(RandomNumberGenerator rng)
      {
        var intByte = new byte[4];
        rng.GetBytes(intByte);
        return BitConverter.ToUInt32(intByte, 0);
      }
      using (var rng = new RNGCryptoServiceProvider())
      {
        var i1 = Math.Abs(RandomInt(rng));
        var i2 = Math.Abs(RandomInt(rng));
        return $"U-{DateTime.Now.ToString("yyddMM")}-{i1.ToString("X")}";
      }
    });

    /// <summary>
    /// Customer Code 
    /// </summary>
    public String CustomerCode
    {
      get
      {
        return DateTime.Now.Ticks.ToString().Substring(13);
      }
    }

  }
}
