using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegramBot1.Model
{
    public class TelegramUser : BaseModel
    {
        private long id;
        private string nick;
        public TelegramUser(long id, string nick)
        {
            this.id = id;
            this.nick = nick;
            Messages = new ObservableCollection<string>();
        }
        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Nick
        {
            get
            {
                return nick;
            }
            set
            {
                this.nick = value;
                OnPropertyChanged("Nick");
            }
        }
        public ObservableCollection<string> Messages { get; set; }
        public override bool Equals(object u)
        {
            TelegramUser user = u as TelegramUser;
            if (user != null)
            {
                if (this.Id.Equals(user.Id))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public void AddMessage(string m) => Messages.Add(m);
    }
}
