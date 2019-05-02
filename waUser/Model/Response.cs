using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using waUser.Contracts;

namespace waUser.Models
{
    //public abstract class BaseResponse
    //{

    //    [JsonProperty("success")]
    //    private bool Success { get; set; }

    //    [JsonProperty("message")]
    //    private  string Message { get; set; }

    //    [JsonProperty("result")]
    //    protected virtual dynamic Result{ get; set; } 

    //    public BaseResponse(bool success, string message, dynamic result)
    //    {
    //        Success = success;
    //         Message = message;
    //        Result = result;
    //    }

    //}

    //public class ResponseUser : BaseResponse
    //{
    //    // could result mutate it's type maintaining a single construct  ? 
    //    public ResponseUser(bool success, string message, bool result) : base(success, message, result) { }

    //    public ResponseUser(bool success, string message, List<User> result) : base(success, message, result) { }

    //}

    public class ResponseAddUser: IBaseResponse
    {
        public bool Success { get;  set; }
        public string Message { get;  set; }

        [JsonProperty("result")]
        public bool Result { get; private set; }

        public ResponseAddUser(bool success, string message, bool result)
        {
            Success = success;
            Message = message;
            Result = result;
        }
    }

    public class ResponseGetUsers : IBaseResponse
    {
        public bool Success { get;  set; }
        public string Message { get;  set; }

        [JsonProperty("result")]
        public List<User> Result { get; private set; }

        public ResponseGetUsers(bool success, string message, List<User> users)
        {
            Success = success;
            Message = message;
            Result = users;
        }
    }


}
