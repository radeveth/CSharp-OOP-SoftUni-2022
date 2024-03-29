﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero : Object
    {
        private const int MIN_LEVEL = 0;

        private string username;
        private int level;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username 
        {
            get { return this.username; }
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or whitespace");
                }

                this.username = value;
            } 
        }
        public int Level
        {
            get { return this.level; }
            private set 
            {
                if (value < MIN_LEVEL)
                {
                    throw new ArgumentException("Level cannot be negative number.");
                }

                this.level = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
