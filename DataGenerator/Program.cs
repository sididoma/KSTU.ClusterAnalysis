using KSTU.App.BLL.Entities;
using KSTU.App.BLL.Interfaces;
using KSTU.App.Data.Domain;
using KSTU.App.Data.Repositories;
using KSTU.Common.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot;

namespace DataGenerator
{
    public class Program
    {
        private static readonly int _countUsers = 1000;
        private static readonly int _countInterests = 1000;
        private static readonly int _countInterestsPerUser = 5;
        private readonly IRepo<User> _userRepo;
        private readonly IRepo<Hobbies> _hobbiesRepo;
        private readonly IRepo<TestNames> _testNamesRepo;
        private readonly IRepo<TestSurNames> _testSurNamesRepo;
        private readonly IRepo<UserInterests> _userInterestsRepo;

        public Program(IRepo<User> userRepo, IRepo<Hobbies> hobbiesRepo, IRepo<TestNames> testNamesRepo, IRepo<TestSurNames> testSurNamesRepo, IRepo<UserInterests> userInterestsRepo)
        {
            _userRepo = userRepo;
            _hobbiesRepo = hobbiesRepo;
            _testNamesRepo = testNamesRepo;
            _testSurNamesRepo = testSurNamesRepo;
            _userInterestsRepo = userInterestsRepo;
        }

        static void Main(string[] args)
        {
            
        }

        public static List<string> GetMusicTypes()
        {
            List<string> result = new List<string>();

            using (StreamReader reader = new StreamReader("D:\\musics.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(line.Trim());
                }
            }

            return result;
        }
    }
}

