using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegrammChat.Core;
using TelegrammChat.MVVM.Model;

namespace TelegrammChat.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /*Commands*/

        public RelayCommand SendCommand { get; set; }


        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            { 
                _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o => 
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });
                Message = "";
            });
            Messages.Add(new MessageModel
            {
                Username = "Allison",
                UsernameColor = "#409AFF",
                ImageSource = @"C:\Users\Danil\OneDrive\Изображения\elf2.jpg",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            }
            );
            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#409AFF",
                    ImageSource = @"C:\Users\Danil\OneDrive\Изображения\elf2.jpg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = true
                });
            }
            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bunny",
                    UsernameColor = "#409AFF",
                    ImageSource = @"C:\Users\Danil\OneDrive\Изображения\elf2.jpg",
                    Message = "Last",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                });
            }
            for (int i = 0; i < 15; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Allison {i}",
                    ImageSource = @"C:\Users\Danil\OneDrive\Изображения\goblin.jpg",
                    Messages = Messages
                });
            }
        }
    }
}
