public struct Bot
{
    static string token;
    static string baseUri;
    static HttpClient hc = new HttpClient();


    public static void Start()
    {
        int offset = 0;
        while (true)
        {

            string url = $"http://api.openweathermap.org/data/2.5/forecast?zip=171080,ru&appid=6f9b33ecd53f0c1be1b22830785323c9&units=metric&lang=ru";
            string json = hc.GetStringAsync(url).Result;
            // System.Console.WriteLine(json);

            JsonParse.Init(json);
            List<ModelMessage> msgs = JsonParse.Parse();
            
            System.Console.WriteLine(msgs);
            // foreach (ModelMessage msg in msgs)
            // {
            //     System.Console.WriteLine(msg);
            //     Repository.Append(msg);
            //     string uid = msg.UserId;
            //     string msgText = String.Empty;
            //     Random r = new Random();
            //     if (!Game.db.ContainsKey(uid) || msg.MessageText == "/restart")
            //     {
            //         int candy = r.Next(22, 33);
            //         if (!Game.db.ContainsKey(uid)) Game.db.Add(uid, 0);
            //         Game.db[uid] = candy;
            //         msgText =  $"Привет!\n";
            //     }
            //     else
            //     {
            //         // 1 2 3 4 
            //         int user = 0;
            //         bool flag = int.TryParse(msg.MessageText, out user);
            //         if (!flag) {  msgText += "Введи число\n";   }
            //         if (user >= 1 && user <= 4)
            //         {
            //             Game.db[msg.UserId] -= user;
            //             var ca = Game.db[msg.UserId];
            //             if(ca <= 0) 
            //             {
            //                 msgText += "Ура, Вы победили!\n";
            //             }
            //             else
            //             {
            //                 if (ca < 5)
            //                 {
            //                     Game.db[msg.UserId] -= ca;
            //                     msgText += $"Ход бота: {ca}\n";
            //                 }
            //                 else
            //                 {
            //                     var ii = r.Next(1, 5);
            //                     Game.db[msg.UserId] -= ii;
            //                     msgText += $"Ход бота: {ii}\n";
                                
            //                 }
            //                 if(Game.db[msg.UserId] <= 0) 
            //                 {
            //                     msgText += "Ура Бот победил\n";
            //                 }
                            
                            
            //             }
                        

                        
            //         }
            //         else
            //         {
            //             // SendMessage(msg.UserId, "Число кривое", msg.MessageId);
            //             msgText += "Число кривое\n";
            //         }
                    

            //     }
            //     msgText += $"Конфет осталось: {Game.db[uid]}.\n Перезапуск /restart";
            //     SendMessage(msg.UserId, msgText, msg.MessageId);

            //     // System.Console.WriteLine(offset);
            //     offset = (Int32.Parse(msg.UpdateId) + 1);
            //     // Thread.Sleep(200);


            //     // if (msg.Id = "") { BotC }
            //     // if (msg.Id = "") {}
            //     // if (msg.Id = "") {}
            //     // if (msg.Id = "") {}



            // }
            Repository.Save();

            // Thread.Sleep(2000);
        }
    }

    public static void Init(string publicToken)
    {
        token = publicToken;
        baseUri = "https://api.telegram.org/bot5157919814:AAFIcb8U-7MaGohs2_c9a-8YI-FTIZIfUlk/";
    }

    public static void SendMessage(string id, string text, string replyToMessageId = "")
    {
        string url = $"{baseUri}sendMessage?chat_id={id}&text={text}&reply_to_message_id={replyToMessageId}";
        var req = hc.GetStringAsync(url).Result;
    }

}