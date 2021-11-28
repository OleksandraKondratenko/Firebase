using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TestFirebase
{
    public class SendNotif
    {
        public static void SendNotification()
        {
            try
            {
                FbToken data = new FbToken
                {
                    registrationsIds = new List<string>() { },
                    NotificationModel = new NotificationModel
                    {
                        Title = "Title",     // Notification title
                        Message = "Message",    // Notification body data
                        Link = "link"       // When click on notification user redirect to this link
                    }
                };

                var json = JsonConvert.DeserializeObject<string>(data.ToString());
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                string SERVER_API_KEY = "AAAAC_3s8aI:APA91bEqopBgaWlzHdGILttWooaujcRt03RrFymTg4AvFkH3rkOR0EZd6CgA-kqehj6th3H3HFm8RjnhZicO1agvT4IMkehMfQ2F-m6dFux93YyqJwd4Fvd_42k9uW4V2EFSopgB3A2U";
                string SENDER_ID = "51504804258";

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));

                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();

                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
