using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game.Models;
using System.Data.SqlClient;

namespace RPG_Game.DALs
{
    public class InventoryDAL
    {
        private string connectionString;

        public InventoryDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> output = new List<Inventory>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM inventory;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Inventory i = new Inventory();
                        i.Inventory_Id = Convert.ToInt32(reader["inventory_iD"]);
                        i.Name = Convert.ToString(reader["name"]);
                        i.Type = Convert.ToString(reader["type"]);
                        i.SubType = Convert.ToString(reader["subType"]);
                        i.Weight = Convert.ToDecimal(reader["weight"]);
                        i.StrengthProp = Convert.ToInt32(reader["strengthProp"]);
                        i.AttackProp = Convert.ToInt32(reader["attackProp"]);
                        i.DefenseProp = Convert.ToInt32(reader["defenseProp"]);
                        i.MagicProp = Convert.ToInt32(reader["magicProp"]);

                        output.Add(i);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return output;
        }

        public bool AddInventory(Inventory item)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO inventory VALUES (@name, @type, @subtype, @weight, @strengthProp, @attackProp, @defenseProp, @magicProp);", conn);
                    cmd.Parameters.AddWithValue("@name", item.Name);
                    cmd.Parameters.AddWithValue("@type", item.Type);
                    cmd.Parameters.AddWithValue("@subType", item.SubType);
                    cmd.Parameters.AddWithValue("@weight", item.Weight);
                    cmd.Parameters.AddWithValue("@strengthProp", item.StrengthProp);
                    cmd.Parameters.AddWithValue("@attackProp", item.AttackProp);
                    cmd.Parameters.AddWithValue("@defenseProp", item.DefenseProp);
                    cmd.Parameters.AddWithValue("@magicProp", item.MagicProp);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }
        
    }
}
