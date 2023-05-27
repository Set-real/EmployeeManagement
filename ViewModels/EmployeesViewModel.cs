using EmployeeManagement.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.ViewModels
{
    public class EmployeesViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public EmployeeRepository _employeeRepository { get; }

        public EmployeesViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            FillListView();
            OnPropertyChanged();

        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees 
        { get 
            {
                return _employees;
            } 
            set 
            { 
                _employees = value;
                OnPropertyChanged();
            }
        }

        private string _filter;
        public string Filter 
        { get
            {
                return _filter;
            }
        set {
                _filter = value; 
                FillListView();
            }
        }

        private string _filterMessage;
        public string FilterMessage
        {
            get
            {
                return _filterMessage;
            }
            set
            {
                _filterMessage = value;
                OnPropertyChanged();
            }
        }

        public void FillListView()
        {
            if(!string.IsNullOrEmpty(_filter))
            {
                _employees = new ObservableCollection<Employee>(
                    _employeeRepository.GetAll().Where(x => x.FirstName.Contains(_filter)));
            }
            else
            {
                _employees = new ObservableCollection<Employee>(
                    _employeeRepository.GetAll());
            }
        }

        private void FillFilterMessage()
        {
            if (!String.IsNullOrEmpty(_filter))
            {
                FilterMessage = "По вашему запросу найдено: " + Employees.Count().ToString();
            }
            else
            {
                FilterMessage = "Введите данные для поиска";
            }
        }
    }
}
