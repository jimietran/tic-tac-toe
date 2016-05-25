using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using TicTacToe.Data;

namespace TicTacToe.Models
{
    /// <summary>
    /// Model class
    /// </summary>
    public class TicTacToeModel : BaseModel
    {
        public int ID { get; set; }
        public string topLeft { get; set; }
        public string topMiddle { get; set; }
        public string topRight { get; set; }
        public string centerLeft { get; set; }
        public string centerMiddle { get; set; }
        public string centerRight { get; set; }
        public string bottomLeft { get; set; }
        public string bottomMiddle { get; set; }
        public string bottomRight { get; set; }

        private const string CONNECTION_STRING = "TicTacToeDBContext";

        public TicTacToeModel()
            : base(CONNECTION_STRING)
        {
        }

        public void insertGame(GameObject game)
        {
            openSQLConnection();

            using (SqlCommand cmd = new SqlCommand("InsertGame", this.SqlCn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@TopLeft", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.topLeft))
                {
                    cmd.Parameters["@TopLeft"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@TopLeft"].Value = game.topLeft;
                }

                cmd.Parameters.Add("@TopMiddle", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.topMiddle))
                {
                    cmd.Parameters["@TopMiddle"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@TopMiddle"].Value = game.topMiddle;
                }

                cmd.Parameters.Add("@TopRight", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.topRight))
                {
                    cmd.Parameters["@TopRight"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@TopRight"].Value = game.topRight;
                }

                cmd.Parameters.Add("@CenterLeft", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.centerLeft))
                {
                    cmd.Parameters["@CenterLeft"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@CenterLeft"].Value = game.centerLeft;
                }

                cmd.Parameters.Add("@CenterMiddle", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.centerMiddle))
                {
                    cmd.Parameters["@CenterMiddle"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@CenterMiddle"].Value = game.centerMiddle;
                }

                cmd.Parameters.Add("@CenterRight", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.centerRight))
                {
                    cmd.Parameters["@CenterRight"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@CenterRight"].Value = game.centerRight;
                }

                cmd.Parameters.Add("@BottomLeft", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.bottomLeft))
                {
                    cmd.Parameters["@BottomLeft"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@BottomLeft"].Value = game.bottomLeft;
                }

                cmd.Parameters.Add("@BottomMiddle", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.bottomMiddle))
                {
                    cmd.Parameters["@BottomMiddle"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@BottomMiddle"].Value = game.bottomMiddle;
                }

                cmd.Parameters.Add("@BottomRight", SqlDbType.NVarChar);
                if (String.IsNullOrEmpty(game.bottomRight))
                {
                    cmd.Parameters["@BottomRight"].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters["@BottomRight"].Value = game.bottomRight;
                }

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw e;
                }
                finally
                {
                    closeSQLConnection();
                }
            }
        }
    }

    public class TicTacToeDBContext : DbContext
    {
        public DbSet<TicTacToeModel> TicTacToe { get; set; }
    }
}