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
        public  bool Success { get; set; }

        [JsonProperty("message")]
        public  string Message { get;  set; }

        [JsonProperty("result")]
        public virtual dynamic Result { get; set; }

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

        public override dynamic Result
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
            set
            {

                base.Result = value;
            }
        }
    }
}
