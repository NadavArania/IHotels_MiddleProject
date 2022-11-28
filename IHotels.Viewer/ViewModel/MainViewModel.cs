using IHotels.Viewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHotels.Viewer.ViewModel
{
    public class MainViewModel : ObserveableObject
    {
        //Control all view models toghter.
        public RelayCommand StartViewCommand { get; set; }
        public RelayCommand RoomViewCommand { get; set; }
        public RelayCommand GuestViewCommand { get; set; }
        public RelayCommand UsersViewCommand { get; set; }

        public BookingViewModel BookingVm { get; set; }
        public RoomsViewModel RoomVm { get; set; }
        public GuestsViewModel GuestVm { get; set; }
        public UsersViewModel UserVm { get; set; }
        public LogAndValidate lav = new LogAndValidate();

        private object _currentView;

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ChangeView();
        }

        //Check which tab is shown and bring acces to change it.
        public void ChangeView()
        {
            BookingVm = new BookingViewModel();
            RoomVm = new RoomsViewModel();
            GuestVm = new GuestsViewModel();
            UserVm = new UsersViewModel();
            CurrentView = BookingVm;

            StartViewCommand = new RelayCommand(o => CurrentView = BookingVm);
            RoomViewCommand = new RelayCommand(o => CurrentView = RoomVm);
            GuestViewCommand = new RelayCommand(o => CurrentView = GuestVm);
            UsersViewCommand = new RelayCommand(o => { if (lav.Authorize()) { CurrentView = UserVm; } });
        }
    }
    
}
