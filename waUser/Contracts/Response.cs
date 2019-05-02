using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace waUser.Contracts
{
    public interface IBaseResponse
    {
        [JsonProperty("success")]
        bool Success { get; set; }

        [JsonProperty("message")]
        string Message { get; set; }
    }
}
