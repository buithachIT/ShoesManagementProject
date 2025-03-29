﻿using MySql.Data.MySqlClient;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    class UserController
    {
        private DatabaseHelper db = new DatabaseHelper();
        public List<User> GetAllUsers()
        {
            string query = "SELECT id_user, username, passwordhash, fullname, email, phone, id_role, is_active FROM user";
            DataTable dt = db.ExecuteQuery(query);
            List<User> users = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User
                {
                    IdUser = Convert.ToInt32(row["id_user"]),
                    Username = row["username"].ToString(),
                    PasswordHash = row["passwordhash"].ToString(),
                    FullName = row["fullname"].ToString(),
                    Email = row["email"].ToString(),
                    Phone = Convert.ToInt32(row["phone"]),
                    IdRole = Convert.ToInt32(row["id_role"]),
                    IsActive = Convert.ToBoolean(row["is_active"])
                });
            }
            return users;
        }
        public bool AddUser(User user)
        {
            string query = "INSERT INTO user (id_user, username, passwordhash, fullname, email, phone, id_role, is_active) " +
                           "VALUES (@id_user, @username, @passwordhash, @fullname, @email, @phone, @id_role, @is_active)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@id_user", user.IdUser),
                new MySqlParameter("@username", user.Username),
                new MySqlParameter("@passwordhash", user.PasswordHash),
                new MySqlParameter("@fullname", user.FullName),
                new MySqlParameter("@email", user.Email),
                new MySqlParameter("@phone", user.Phone),
                new MySqlParameter("@id_role", user.IdRole),
                new MySqlParameter("@is_active", user.IsActive)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool UpdateUser(User user)
        {
            string query = @"UPDATE user
                            SET username = @username, passwordhash = @passwordhash, fullname = @fullname, email = @email, phone = @phone, id_role = @id_role, is_active = @is_active
                            WHERE id_user = @id_user";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@id_user", user.IdUser),
                new MySqlParameter("@username", user.Username),
                new MySqlParameter("@passwordhash", user.PasswordHash),
                new MySqlParameter("@fullname", user.FullName),
                new MySqlParameter("@email", user.Email),
                new MySqlParameter("@phone", user.Phone),
                new MySqlParameter("@id_role", user.IdRole),
                new MySqlParameter("@is_active", user.IsActive)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool DeleteUser(int id)
        {
            string query = "DELETE FROM user WHERE id_user = @id_user";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@id_user", id)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
