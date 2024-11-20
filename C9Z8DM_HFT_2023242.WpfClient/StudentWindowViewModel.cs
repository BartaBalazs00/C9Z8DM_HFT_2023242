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
    class StudentWindowViewModel : ObservableRecipient
    {
        public RestCollection<Student> Students { get; set; }
		private Student selectedStudent;

		public Student SelectedStudent
		{
			get { return selectedStudent; }
			set 
            {
                if (value != null)
                {
                    selectedStudent = new Student()
                    {
                        StudentId = value.StudentId,
                        StudentName = value.StudentName,
                        StudentClass = value.StudentClass,
                    };
                    OnPropertyChanged();
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
		}
        public ICommand CreateStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public StudentWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Students = new RestCollection<Student>("http://localhost:56516", "student");
                CreateStudentCommand = new RelayCommand(() =>
                {
                    Students.Add(new Student()
                    {
                        StudentName = SelectedStudent.StudentName,
                        StudentClass = SelectedStudent.StudentClass
                    });
                });
                UpdateStudentCommand = new RelayCommand(() =>
                {
                    Students.Update(SelectedStudent);
                });
                DeleteStudentCommand = new RelayCommand(() =>
                {
                    Students.Delete(SelectedStudent.StudentId);
                }, () =>
                {
                    return SelectedStudent != null;
                });
                SelectedStudent = new Student();
            }
        }
    }
}
