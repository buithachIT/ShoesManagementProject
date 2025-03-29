using MySql.Data.MySqlClient;
using Shared.Models;
using System.Collections.Generic;
using System.Data;

namespace AdminApp.Controllers
{
    class RoleController
    {
        private DatabaseHelper db = new DatabaseHelper();
        public List<Role> GetAllRole()
        {
            string query = "SELECT id_role, name_role, description FROM role";
            DataTable dt = db.ExecuteQuery(query);
            List<Role> roles = new List<Role>();
            foreach (DataRow row in dt.Rows)
            {
                roles.Add(new Role
                {
                    IdRole = Convert.ToInt32(row["id_role"]),
                    NameRole = row["name_role"].ToString(),
                    Description = row["description"].ToString()
                });
            }
            return roles;
        }
    }
}
