using C9Z8DM_HFT_2023242.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace C9Z8DM_HFT_2023242.WpfClient
{
    class TeacherWindowViewModel : ObservableRecipient
    {
        public RestCollection<Teacher> Teachers { get; set; }
		private Teacher selectedTeacher;

		public Teacher SelectedTeacher
		{
			get { return selectedTeacher; }
			set 
            {
                if (value != null)
                {
                    selectedTeacher = new Teacher()
                    {
                        TeacherId = value.TeacherId,
                        TeacherName = value.TeacherName,
                        Subject = value.Subject,
                        Email = value.Email,
                    };
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedSubject));
                    (DeleteTeacherCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
		}
        public Teacher SelectedSubject
        {
            get
            {
                return Teachers.FirstOrDefault(x => x.Subject == SelectedTeacher.Subject);
            }
            set
            {
                if (value != null)
                {
                    SelectedTeacher.Subject = value.Subject;
                    OnPropertyChanged(nameof(SelectedTeacher));
                }
            }
        }
        public ICommand CreateTeacherCommand { get; set; }
        public ICommand DeleteTeacherCommand { get; set; }
        public ICommand UpdateTeacherCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public TeacherWindowViewModel()
        {
            Teachers = new RestCollection<Teacher>("http://localhost:56516", "teacher");
            CreateTeacherCommand = new RelayCommand(() =>
            {
                Teachers.Add(new Teacher()
                {
                    TeacherName = SelectedTeacher.TeacherName,
                    Subject = SelectedTeacher.Subject,
                    Email = SelectedTeacher.Email,
                });
            });
            UpdateTeacherCommand = new RelayCommand(() =>
            {
                Teachers.Update(SelectedTeacher);
            });
            DeleteTeacherCommand = new RelayCommand(() =>
            {
                Teachers.Delete(SelectedTeacher.TeacherId);
            }, () =>
            {
                return SelectedTeacher != null;
            });
            SelectedTeacher = new Teacher();
        }
    }
}
