using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessageBox.DAL;
using MessageBox.Models;

namespace MessageBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        protected IMessageWriter mw;

        public MessageController(IMessageWriter mw)
        {
            this.mw = mw;
        }

        [HttpGet]
        public IEnumerable<Message> GetTopicMessages(int topicId)
        {
            return mw.GetMessages(topicId);
        }

        [HttpPost]
        public void SaveMessage(Message message)
        {
            mw.SaveMessage(message);
        }
    }
}