using MaterialConstructionAPI.DAO;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MaterialConstructionAPI.DAL
{
    public class UserManager : AbstractManager
    {
        DBContext _dbContext = new DBContext();
        List<User> userList;

        public List<User> User()
        {
            IEnumerable data = ExecuteQuery(
                "select * " +
                "from users"
                );
            userList = new List<User>();
            foreach (IDataRecord row in data)
            {
                userList.Add(DAO.User.Create(row));
            }
            return userList;
        }

        public User User(int id)
        {
            if (id != 0)
            {
                IEnumerator iterator = ExecuteQuery(
                    "select * " +
                    "from users " +
                    "where user_id = @0",
                    id)
                    .GetEnumerator();
                if (!iterator.MoveNext())
                {
                    //throw new WhateverException("Empty list!");
                    return null;
                }
                return DAO.User.Create((IDataRecord)iterator.Current);
            }
            else
            {
                return null;
            }
        }
    }
}