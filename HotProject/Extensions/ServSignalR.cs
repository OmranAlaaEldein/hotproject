using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.SignalR;

//read : https://www.c-sharpcorner.com/article/implementation-of-signalr-with-net-core/

namespace HotProject.Extensions
{
    public class ServSignalR : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

    /*
     * chat.js file under “wwwroot/js” folder:
     
     <script src="~/Scripts/jquery.signalR-2.4.2.min.js"></script>
    <script src="~/signalr/hubs"></script>
     <script>
     const connection = new signalR.HubConnectionBuilder()  
    .withUrl("/ServSignalR")  
    .build();  
  
        //This method receive the message and Append to our list  
        connection.on("ReceiveMessage", (user, message) => {  
        const msg = message.replace(/&/g, "&").replace(/</g, "<").replace(/>/g, ">");  
        const encodedMsg = user + " :: " + msg;  
        const li = document.createElement("li");  
        li.textContent = encodedMsg;  
        document.getElementById("messagesList").appendChild(li);  
        });  
  
        connection.start().catch(err => console.error(err.toString()));  
  
        //Send the message  
  
        document.getElementById("sendMessage").addEventListener("click", event => {  
            const user = document.getElementById("userName").value;  
            const message = document.getElementById("userMessage").value;  
            connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));  
            event.preventDefault();  
        });   

     </script>
    */

}