using MyFace.Repositories;
using MyFace.Helpers;
using MyFace.Models.Database;

public class AuthenticationService
{
    private readonly IUsersRepo _usersRepo;

    public AuthenticationService(IUsersRepo usersRepo)
    {
        _usersRepo = usersRepo;
    }

    public bool VerifyCredentials(string username, string passwordAttempt)
    {
        var user = _usersRepo.GetUserByUsername(username);

        if (user != null && PasswordHelper.GetHashedPassword( passwordAttempt, user.Salt) == user.HashedPassword)
        {
            return true;
        }

        return false;
    }

}

