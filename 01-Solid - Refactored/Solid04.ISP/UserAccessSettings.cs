using System;

namespace Solid04.ISP
{
    public class UserAccessSettings : ILoad
    {
        public bool AreUsersAbleToChangeUsername { get; set; }
        public bool AreUsersAbleToResetPassword { get; set; }

        public void Load()
        {
            // LOAD FROM FILE, DB, etc...
            AreUsersAbleToChangeUsername = false;
            AreUsersAbleToResetPassword = true;
        }
        
    }
}
