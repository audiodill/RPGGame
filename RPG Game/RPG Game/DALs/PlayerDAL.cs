using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game.DALs;
using RPG_Game.Models;
using System.Data.SqlClient;

namespace RPG_Game.DALs
{
    public class PlayerDAL
    {
        private string connectionString;

        public PlayerDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> output = new List<Player>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM player", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Player p = new Player();
                        p.Player_Id = Convert.ToInt32(reader["player_Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Life = Convert.ToInt32(reader["life"]);
                        p.Gender = Convert.ToString(reader["gender"]);
                        p.XP = Convert.ToInt32(reader["xp"]);
                        p.Strength = Convert.ToInt32(reader["strength"]);
                        p.Attack = Convert.ToInt32(reader["attack"]);
                        p.Defense = Convert.ToInt32(reader["defense"]);
                        p.Magic = Convert.ToInt32(reader["magic"]);
                        p.Level = Convert.ToInt32(reader["xpLevel"]);
                        p.Gold = Convert.ToInt32(reader["gold"]);
                        p.PlayerType = Convert.ToString(reader["playertype"]);

                        output.Add(p);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return output;   
        }
        public bool AddNewPlayer(Player p)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO player VALUES (@name, @life, @gender, @xp, @strength, @attack, @defense, @magic, @level, @gold, @playertype);", conn);
                    cmd.Parameters.AddWithValue("@name", p.Name);
                    cmd.Parameters.AddWithValue("@life", p.Life);
                    cmd.Parameters.AddWithValue("@gender", p.Gender);
                    cmd.Parameters.AddWithValue("@xp", p.XP);
                    cmd.Parameters.AddWithValue("@strength", p.Strength);
                    cmd.Parameters.AddWithValue("@attack", p.Attack);
                    cmd.Parameters.AddWithValue("@defense", p.Defense);
                    cmd.Parameters.AddWithValue("@magic", p.Magic);
                    cmd.Parameters.AddWithValue("@level", p.Level);
                    cmd.Parameters.AddWithValue("@gold", p.Gold);
                    cmd.Parameters.AddWithValue("@playertype", p.PlayerType);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }
        public Player SearchPlayer(string userName)
        {
            Player output = new Player();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM player WHERE name = @name;", conn);
                    cmd.Parameters.AddWithValue("@name", userName);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Player_Id = Convert.ToInt32(reader["player_Id"]);
                        output.Name = Convert.ToString(reader["name"]);
                        output.Life = Convert.ToInt32(reader["life"]);
                        output.Gender = Convert.ToString(reader["gender"]);
                        output.XP = Convert.ToInt32(reader["xp"]);
                        output.Strength = Convert.ToInt32(reader["strength"]);
                        output.Attack = Convert.ToInt32(reader["attack"]);
                        output.Defense = Convert.ToInt32(reader["defense"]);
                        output.Magic = Convert.ToInt32(reader["magic"]);
                        output.Level = Convert.ToInt32(reader["xpLevel"]);
                        output.Gold = Convert.ToInt32(reader["gold"]);
                        output.PlayerType = Convert.ToString(reader["playertype"]);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return output;
        }
    }
}
