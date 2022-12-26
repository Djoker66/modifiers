using System;
using System.Collections.Generic;
using System.Text;

namespace HW
{
    internal class User
    {
        public string UserName;
        private string Password;
        public int Data;

        public User(string username, string password, int data)
        {
            this.UserName = username;
            this.Password = password;
            this.Data = data;
        }
        public string Showinfo()
        {
            return $"\nUsername: {UserName} -Data: {Data}";
        }

    }
}
