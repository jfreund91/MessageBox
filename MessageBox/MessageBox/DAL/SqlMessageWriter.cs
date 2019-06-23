using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MessageBox.Models;

namespace MessageBox.DAL
{
    public class SqlMessageWriter : IMessageWriter
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private string cn;

        /// <summary>
        /// Creates an IMessageWriter that can write to a SQL database.
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlMessageWriter(string connectionString)
        {
            this.cn = connectionString;
        }

        /// <summary>
        /// Saves a message to the database.
        /// </summary>
        public void SaveMessage(Message message)
        {
            string sql = "INSERT INTO [messages] VALUES(@topicId, @entry_date, @content, @is_deleted);";
            using (SqlConnection conn = new SqlConnection(this.cn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@topicId", message.TopicId);
                cmd.Parameters.AddWithValue("@entry_date", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@content", message.MessageContent);
                cmd.Parameters.AddWithValue("@is_deleted", 0);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets the messages for a specific topic.
        /// </summary>
        /// <param name="topicId">Topic ID</param>
        /// <returns>A List of Messages for the given Topic ID.</returns>
        public IList<Message> GetMessages(int topicId)
        {
            List<Message> messages = new List<Message>();
            string sql = "SELECT TOP (1000) * FROM [messages] WHERE topicId = @topicId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(this.cn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@topicId", topicId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        messages.Add(ConvertReaderToMessage(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                //Swollow the exception for now.
                throw;
            }

            return messages;
        }

        /// <summary>
        /// Maps a Reader Object from the SQLDataReader to a Message Object.
        /// </summary>
        /// <param name="reader">reader</param>
        /// <returns>Message</returns>
        private Message ConvertReaderToMessage(SqlDataReader reader)
        {
            Message msg = new Message();
            msg.ID = Convert.ToInt32(reader["id"]);
            msg.MessageContent = Convert.ToString(reader["content"]);
            msg.PostDate = Convert.ToDateTime(reader["entry_date"]);
            msg.TopicId = Convert.ToInt32(reader["topicId"]);

            return msg;
        }
    }
}
