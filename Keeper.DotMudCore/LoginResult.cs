﻿namespace Keeper.DotMudCore
{
    public struct LoginResult
    {
        public static LoginResult Failed => new LoginResult { Type = LoginResultType.Failed };

        public static LoginResult Disconnected => new LoginResult { Type = LoginResultType.Disconnected };

        public static LoginResult Success(string username, bool isNewRegistration = false)
            => new LoginResult
                {
                    Type = isNewRegistration
                                ? LoginResultType.Registered
                                : LoginResultType.Authenticated,
                    Username = username
                };

        public LoginResultType Type
        {
            get;
            private set;
        }

        public string Username
        {
            get;
            private set;
        }

        public bool IsSuccess => this.Type == LoginResultType.Authenticated || this.Type == LoginResultType.Registered;
    }

    public enum LoginResultType
    {
        Failed,
        Disconnected,
        Cancelled,
        Authenticated,
        Registered
    }
}