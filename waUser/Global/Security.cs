﻿using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace waUser
{
    public class Security
    {
        public class PasswordHash
        {
            public static string Create(long userID , string password)
            {

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: BitConverter.GetBytes(userID),
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));

                return hashed;

            }
        }

    }
}