using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PayAjo.Domain.Core.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Exceptions
{
  /// <summary>
  /// Exception handler 
  /// </summary>
  public static class ExceptionHandler
  {
    /// <summary>
    /// Get exception details 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static string Get(this HttpContext context, Exception ex)
    {
      //Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);

      var responseModel = new Responses();
      // var op = new Operation<Responses>();

      try
      {
        if (ex.GetType() == typeof(SecurityTokenValidationException))
        {
          responseModel.ResponseMessage = "Invalid token";
          responseModel.ResponseCode = ResponseCode.INVALID_TOKEN;

          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          //context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else if (ex.GetType() == typeof(SecurityTokenInvalidIssuerException))
        {
          responseModel.ResponseMessage = "Invalid issuer";
          responseModel.ResponseCode = ResponseCode.INVALID_ISSUER;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          //  context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

        }
        else if (ex.GetType() == typeof(SecurityTokenExpiredException))
        {
          responseModel.ResponseMessage = "Token expired";
          responseModel.ResponseCode = ResponseCode.TOKEN_EXPIRED;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          //  context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else if (ex.GetType() == typeof(ModelValidationException))
        {
          ModelValidationException error = ex as ModelValidationException;
          responseModel.ResponseCode = ResponseCode.MODEL_INVALID;
          responseModel.ResponseMessage = ex.Message;
          //responseModel.ValidationErrors = error.errors;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          // context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (ex.GetType() == typeof(ArgumentNullException))
        {
          ModelValidationException error = ex as ModelValidationException;
          responseModel.ResponseCode = ResponseCode.MODEL_INVALID;
          responseModel.ResponseMessage = "Parameter passes is incorrect.";
          // responseModel.ValidationErrors = error.errors;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          // context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (ex.GetType() == typeof(AlreadyExistException))
        {
          responseModel.ResponseCode = ResponseCode.ALREADY_EXIST;
          responseModel.ResponseMessage = ex.Message;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          // context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (ex.GetType() == typeof(NotFoundException))
        {
          responseModel.ResponseCode = ResponseCode.NOT_FOUND;
          responseModel.ResponseMessage = ex.Message;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          //  context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        else if (ex.GetType() == typeof(NotActiveException))
        {
          responseModel.ResponseCode = ResponseCode.NOT_ACTIVE;
          responseModel.ResponseMessage = ex.Message;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
          // context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
        else if (ex.GetType() == typeof(BadRequestException))
        {
          responseModel.ResponseCode = ResponseCode.NOT_ACTIVE;
          responseModel.ResponseMessage = ex.Message;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          //context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (ex.GetType() == typeof(VerificationCodeException))
        {
          responseModel.ResponseCode = ResponseCode.VERIFICATION_CODE;
          responseModel.ResponseMessage = ex.Message;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          //context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (ex.GetType() == typeof(PasswordException))
        {
          responseModel.ResponseCode = ResponseCode.PASSWORD_EXCEPTION;
          responseModel.ResponseMessage = ex.Message;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          // context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else if (ex.GetType() == typeof(SessionExpiredException))
        {
          responseModel.ResponseCode = ResponseCode.SESSIONEXPIRED;
          responseModel.ResponseMessage = ex.Message;
          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          // context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        else if (ex.GetType() == typeof(InvalidOperationException))
        {
          responseModel.ResponseCode = ResponseCode.FORBIDDEN;
          responseModel.ResponseMessage = ex.Message; // "Invalid Request";
                                                      // responseModel.ErrorMessage = ex.Message; //new string[] { ex.Message };

          //op.Succeeded = false;
          //op.Result = responseModel;
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          // context.Response.StatusCode = (int)HttpStatusCode.Forbidden;

        }
        else if (ex.GetType() == typeof(LoginException))
        {
          responseModel.ResponseCode = ResponseCode.LOGIN_FAILED;
          responseModel.ResponseMessage = ex.Message;
          //op.Succeeded = false;
          //op.Result = responseModel;

          context.Response.StatusCode = (int)HttpStatusCode.OK;

          //context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

        }
        else
        {
          responseModel.ResponseCode = ResponseCode.GENERAL_ERROR;
          responseModel.ResponseMessage = ex.Message;
          //  responseModel.ResponseMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

          //responseModel.ErrorMessage = new string[] { ex.InnerException != null ? ex.InnerException.Message : ex.Message };

          context.Response.StatusCode = (int)HttpStatusCode.OK;
          // context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        return JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }
      catch (Exception _ex)
      {
        responseModel.ResponseCode = ResponseCode.GENERAL_ERROR;
        responseModel.ResponseMessage = _ex.Message != null ? _ex.Message : "Please contact the administrator";

        context.Response.StatusCode = (int)HttpStatusCode.OK;
        Log.Error(ResponseCode.GENERAL_ERROR + " " + responseModel.ResponseMessage);

        return JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }

    }
  }
}
