using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBox.Models;

namespace MessageBox.DAL
{
    interface IMessageWriter
    {
        void SaveMessage(Message message);

        IList<Message> GetMessages(int topicId);
    }
}
