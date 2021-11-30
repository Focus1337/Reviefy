﻿using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Reviefy.Models;

namespace Reviefy.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDataConnection _connection;

        public AccountController(AppDataConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public Task<Account[]> ListAccount()
        {
            return _connection.Account.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public Task<Account?> GetAccount(int id)
        {
            return _connection.Account.SingleOrDefaultAsync(account => account.UserId == id);
        }

        [HttpDelete("{id}")]
        public Task<int> DeleteAccount(int id)
        {
            return _connection.Account.Where(account => account.UserId == id).DeleteAsync();
        }

        [HttpPut]
        public Task<int> InsertAccount(Account account)
        {
            return _connection.InsertAsync(account);
        }
    }
}