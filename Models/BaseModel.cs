using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace TicTacToe.Models
{
    /// <summary>
    /// Base class for all database accessor objects
    /// </summary>
    public class BaseModel
    {
        private SqlConnection sqlCn;
        private ConnectionStringSettings connString;
        public static int NULL_INSERT_VALUE = -1;

        /// <summary>
        /// Default constructor.
        /// <param name="connectionStringName">The connection string name specified in the web.config file</param>
        /// </summary>
        public BaseModel(string connectionStringName)
        {
            setConnectionString(connectionStringName);
        }

        /// <summary>
        /// SqlCn property.  It is read only.
        /// </summary>
        public SqlConnection SqlCn
        {
            get { return sqlCn; }
        }

        /// <summary>
        /// Sets the database connection string.
        /// <param name="connectionStringName">The connection string name specified in the web.config file</param>
        /// </summary>
        private void setConnectionString(string connectionStringName)
        {
            Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("~");

            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings[connectionStringName];
            }
            else
            {
                throw new Exception("No connection string");
            }
        }

        /// <summary>
        /// Opens the SQL connection based on the connection string.
        /// </summary>
        protected void openSQLConnection()
        {
            try
            {
                sqlCn = new SqlConnection();
                sqlCn.ConnectionString = connString.ConnectionString;
                sqlCn.Open();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Closes the SQL connection.
        /// </summary>
        protected void closeSQLConnection()
        {
            try
            {
                sqlCn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}