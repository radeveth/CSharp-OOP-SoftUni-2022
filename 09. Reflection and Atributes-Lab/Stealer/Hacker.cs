﻿namespace Stealer
{
    public class Hacker
    {
        //private string username;
        //private string password;

        //public Hacker(string username, string password)
        //{
        //    this.Username = username;
        //    this.Password = password;
        //}


        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        private int Id { get; set; }
        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {
        }
    }
}
