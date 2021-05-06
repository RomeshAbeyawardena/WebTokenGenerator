using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;

namespace WebTokenGenerator.Shared
{
    public class JwtTokenGenerator
    {
        public string Generate(string issuer, string audience, 
            string key, string algorithm,
            IDictionary<string, string> claimsDictionary,
            DateTime notBefore, DateTime expiry, string digest = null)
        {
            SecurityKey sk = new SymmetricSecurityKey(Convert.FromBase64String(key));
            //SecurityAlgorithms.HmacSha256Signature

            var signingCredentials = string.IsNullOrWhiteSpace(digest) 
                ? new SigningCredentials(sk, algorithm) 
                : new SigningCredentials(sk, algorithm, digest);

            var claims = claimsDictionary != null && claimsDictionary.Count > 0 
                ? claimsDictionary.Select(a => new Claim(a.Key, a.Value))
                : Array.Empty<Claim>();

            var jwt = new JwtSecurityToken(issuer, audience, claims, notBefore, expiry, signingCredentials);

            return jwt.ToString();
        }
    }
}
