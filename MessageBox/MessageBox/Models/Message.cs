using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBox.Models
{
    public class Message
    {
        /// <summary>
        /// The message id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The Topic ID the message belongs in.
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// The content of the message.
        /// </summary>
        public string MessageContent { get; set; }

        /// <summary>
        /// The date the post was made.
        /// </summary>
        public DateTime PostDate { get; set; }

    }
}
