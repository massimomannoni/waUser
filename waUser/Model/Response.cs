using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace waUser.Models
{
    public abstract class BaseResponse
    {

        [JsonProperty("success")]
        private bool Success { get; set; }

        [JsonProperty("message")]
        private  string Message { get; set; }

        [JsonProperty("result")]
        protected virtual dynamic Result { get; set; }

        public BaseResponse(bool success, string message, dynamic result)
        {
            this.Success = success;
            this.Message = message;
            this.Result = result;
        }

    }

    public class ResponseUser : BaseResponse
    {

        public ResponseUser(bool success, string message, bool result) : base(success, message, result)
        {
            this.Result = result;
        }

        protected override dynamic Result
        {
            get
            {
                bool result = false;

                if (base.Result == "true")
                {
                    result = true;
                }

                return result;
            }
            set => base.Result = value;
        }
    }
}
