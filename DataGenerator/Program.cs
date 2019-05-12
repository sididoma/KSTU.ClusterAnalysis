using KSTU.App.BLL.Entities;
using KSTU.App.BLL.Interfaces;
using KSTU.App.Data.Domain;
using KSTU.App.Data.Repositories;
using KSTU.Common.DTOs;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataGenerator
{
    public class Program
    {
        private readonly IRepo<User> _userRepo;
        private static readonly int _countUsers = 1000;
        private static readonly int _countInterests = 1000;
        private static readonly int _countInterestsPerUser = 5;
        public Program(IRepo<User> userRepo)
        {
            _userRepo = userRepo;
        }
        static void Main(string[] args)
        {
            List<string> musicTypes = GetMusicTypes();
            List<User> users = new List<User>();

            for(int i = 0; i < _countUsers; i++)
            {

            }
        }

        public static List<string> GetMusicTypes()
        {
            List<string> result = new List<string>();

            using (StreamReader reader = new StreamReader("D:\\musics.txt"))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    result.Add(line.Trim());
                }
            }

            return result;
        }
    }
}

