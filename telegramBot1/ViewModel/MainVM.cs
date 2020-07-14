using FISHY.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Telegram.Bot;
using telegramBot1.Model;

namespace telegramBot1.ViewModel
{
    public class MainVM:BaseVM
    {
        private const string token = "1264510297:AAERd_JO7grVrwEVfrNgaQrC3vPYRN8xmII";
        private TelegramBotClient bot;
        private string message;
        private TelegramUser currentUser;
        private ICommand sendMessage;
        public MainVM()
        {
            bot = new TelegramBotClient(token);
            bot.OnMessage += MessageEventHandler;
            Users = new ObservableCollection<TelegramUser>();
            try
            {
                bot.StartReceiving();
            }
            catch (Exception e)
            {
                File.AppendAllText("errors.log", $"{DateTime.Now} : {e.Message}\n");
            }
        }
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        public TelegramUser CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                this.currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }
        public ObservableCollection<TelegramUser> Users { get; set; }
        public ICommand SendMessage
        {
            get
            {
                return sendMessage ?? (sendMessage = new RelayCommand((obj) =>
                {
                    string msg = $"Albert: {Message}";
                    currentUser.Messages.Add(msg);
                    bot.SendTextMessageAsync(currentUser.Id, Message);
                    Message = String.Empty;
                },(obj)=>
                {
                    return !String.IsNullOrWhiteSpace(Message) && currentUser!=null;
                }));
            }
        }
        
        private void MessageEventHandler(object sender,Telegram.Bot.Args.MessageEventArgs e)
        {
            string msg = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.Id}\t {e.Message.Text}\n";
            File.AppendAllText("data.log", msg);
            Debug.WriteLine(msg);
            Application.Current.Dispatcher.Invoke(() =>
            {
                TelegramUser user = new TelegramUser(e.Message.Chat.Id, e.Message.Chat.FirstName);
                if (!Users.Contains(user))
                {
                    Users.Add(user);
                }
                Users[Users.IndexOf(user)].Messages.Add(e.Message.Text);
            });


        }
    }
}
