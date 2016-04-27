using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCore.ActiveDirectory
{
    public class ActiveDirectory
    {
        public string Domain { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public PrincipalContext Context;

        PrincipalSearchResult<Principal> users;
        public PrincipalSearchResult<Principal> Users
        {
            get
            {
                if (users == null)
                {
                    if (Context == null)
                    {
                        Connect();
                    }

                    users = GetAllUsers();
                }

                return users;
            }
        }

        public void Connect()
        {
            Context = new PrincipalContext(ContextType.Domain, Domain, User, Password);
        }

        public PrincipalSearchResult<Principal> GetAllUsers(bool EnabledOnly = true, bool SaveToClass = false)
        {
            UserPrincipal userPrincipal = new UserPrincipal(Context);
            userPrincipal.Enabled = new bool?(EnabledOnly);

            PrincipalSearcher principalSearcher = new PrincipalSearcher(userPrincipal);
            principalSearcher.QueryFilter = userPrincipal;

            PrincipalSearchResult<Principal> result = principalSearcher.FindAll();

            if (SaveToClass)
            {
                users = result;
            }

            return result;
        }

        public List<Principal> GetAllUsers(string DistinguishedName, bool EnabledOnly = true)
        {
            UserPrincipal userPrincipal = new UserPrincipal(Context);
            userPrincipal.Enabled = new bool?(EnabledOnly);

            PrincipalSearcher principalSearcher = new PrincipalSearcher(userPrincipal);
            principalSearcher.QueryFilter = userPrincipal;

            PrincipalSearchResult<Principal> result = principalSearcher.FindAll();

            List<Principal> finalResult = new List<Principal>();

            foreach (Principal p in result)
            {
                if (p.DistinguishedName.Contains(DistinguishedName))
                {
                    finalResult.Add(p);
                }
            }

            return finalResult;
        }

        public bool FindUpdateUserProperty(string username, string property, object value, PrincipalSearchResult<Principal> userslist, bool ignoreUsernameCase = true)
        {
            foreach (Principal current in userslist)
            {
                UserPrincipal up = (UserPrincipal)current;
                DirectoryEntry de = (DirectoryEntry)current.GetUnderlyingObject();

                bool match = false;

                if (ignoreUsernameCase && (Compare.CompareLower(up.SamAccountName, username.ToLower(), true)))
                {
                    match = true;
                }

                if (up.SamAccountName == username)
                {
                    match = true;
                }

                if (match)
                {
                    de.Properties[property].Value = value;
                    up.Save();

                    return true;
                }
            }

            return false;
        }

        public List<string> GetUserList()
        {
            return Users.Select(u => u.SamAccountName).ToList();
        }
    }
}