using MyFace.Repositories;
using MyFace.Helpers;
using MyFace.Models.Database;
using System;

public class AuthenticationService
{
    private readonly IUsersRepo _usersRepo;

    public AuthenticationService(IUsersRepo usersRepo)
    {
        _usersRepo = usersRepo;
    }

    public bool VerifyBasicCredentials(string authorizationHeader)
    {
        if (authorizationHeader != null && authorizationHeader.StartsWith("Basic "))
        {
            string encodedCredentials = authorizationHeader.Substring(6);
            string decodedCredentials = FromBase64String(encodedCredentials);
            string[] credentials = decodedCredentials.Split(new[] { ':' }, 2);
            string username = credentials[0];
            string password = credentials[1];

            var user = _usersRepo.GetUserByUsername(username);

            if (user != null && PasswordHelper.GetHashedPassword(password, user.Salt) == user.HashedPassword)
            {
                return true;
            }
        }

        return false;
    }

    private string FromBase64String(string base64)
    {
        byte[] bytes = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
}



