using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace waUser.Models
{
    public abstract class BaseResponse
    {

        [JsonProperty("success")]
        private bool Success { get; set; }

        [JsonProperty("message")]
        private  string Message { get; set; }

        [JsonProperty("result")]
        protected virtual dynamic Result{ get; set; } 

        public BaseResponse(bool success, string message, dynamic result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

    }

    public class ResponseUser : BaseResponse 
    {

        public ResponseUser(bool success, string message, bool result) : base(success, message, result)
        {
         
        }
        public ResponseUser(bool success, string message, List<User> result) : base(success, message, result)
        {

        }

    }

    
}
