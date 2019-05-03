using System;

namespace waUser.Constants
{
    internal static class DataBase
    {
        internal const int COMMANDTIMEOUT = 10000;
    }

    internal static class Smtp
    {
        internal const string HOST = "ns0.ovh.net";
        internal const int PORT = 587;
        internal const string USER = "activate@jepro.it";
        internal const string PASSWORD = "activate";
        internal const bool ENABLESSL = false;
        internal const bool DEFAULTCREDENTIAL = false;
        
    }
}
