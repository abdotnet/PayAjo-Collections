using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public  class ResponseCode
  {
    public static string SUCCESSFULL = "200";
    public static string FAIL = "001";
    public static string MODEL_INVALID = "400";
    public static string GENERAL_ERROR = "500";
    public static string LINK_EXPIRED = "410";
    public static string LOGIN_FAILED = "401";

    public static string ALREADY_EXIST = "IDS03";

    public static string NOT_FOUND = "IDS05";
    public static string NOT_ACTIVE = "IDS06";
    public static string BADREQUEST_ACTIVE = "IDS07";
    public static string VERIFICATION_CODE = "IDS08";
    public static string CLIENT_CODE_NOT_SUPPLIED = "IDS09";
    public static string PASSWORD_EXCEPTION = "IDS10";
    public static string LOCKEDOUT_EXCEPTION = "IDS11";
    public static string INVALID_TOKEN = "IDS12";
    public static string INVALID_ISSUER = "IDS13";
    public static string TOKEN_EXPIRED = "IDS14";
    public static string TOKEN_VALIDATION = "IDS15";
    public static string NOT_REGISTERED = "IDS16";
    public static string SESSIONEXPIRED = "IDS17";
    public static string FORBIDDEN = "IDS18";

  }
}
