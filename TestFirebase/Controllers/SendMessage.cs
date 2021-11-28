using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TestFirebase.Controllers
{
    [ApiController]
    [Route("sendMessage")]
    public class SendMessage : Controller
    { 
        NotificationModel _model;
        public SendMessage()
        {
            _model = new NotificationModel();
        }


        [HttpGet("firebase")]
        public async Task<IActionResult> SendMsg()
        {

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json")
            });

            //var message = FirebaseMessagingSnippets.CreateWebpushMessage();
            FirebaseMessagingSnippets.SendMulticastAsync();
            return Ok();
        }

       
    }
}
