using System;

namespace Solid03.LSP
{
    public class UserAccessSettings : PersistedSettingsBase
    {
        public bool AreUsersAbleToChangeUsername { get; set; }
        public int AreUsersAbleToResetPassword { get; set; }

        public override void Load()
        {
            // Load from DB here
        }

        public override void Persist()
        {
            throw new NotSupportedException("User permissions cannot be sa");
        }

        protected override string FileName => throw new NotImplementedException();
    }
}
