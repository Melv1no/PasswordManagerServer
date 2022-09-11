﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerServer
{
    public class CommandManager
    {

        public CommandManager()
        {

        }

        public static String Redirect(String s)
        {
            switch (s)
            {
                case "LIST":
                    String list = "";
                    foreach(String str in PasswordManager.databaseManager.listPassword())
                    {
                        list = list + str;
                    }
                    return list;
                case "UPDATE":
                case "ADD":
                case "REMOVE":
                default:
                    return "ERROR";
                    break;
            }

            return "ERROR";
        }

    }
}