using C9Z8DM_HFT_2023242.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace C9Z8DM_HFT_2023242.WpfClient
{
    public class GradeWindowViewModel :ObservableRecipient
    {
        public RestCollection<Grade> Grades { get; set; }
        public RestCollection<Teacher> Teachers { get; set; }
        public RestCollection<Student> Students { get; set; }
        
        public List<int> GradeValues { get; set; }
        public Grade selectedGrade;
        public Grade SelectedGrade
        {
            get { return selectedGrade; }
            set 
            {
                if (value != null)
                {
                    selectedGrade = new Grade()
                    {
                        GradeId = value.GradeId,
                        GradeValue = value.GradeValue,
                        StudentId = value.StudentId,
                        TeacherId = value.TeacherId,
                        Subject = value.Subject,
                        Year = value.Year,
                    };
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedTeacher));
                    OnPropertyChanged(nameof(SelectedGradeValueIndex));
                    OnPropertyChanged(nameof(SelectedStudent));
                    OnPropertyChanged(nameof(SelectedSubject));
                    (DeleteGradeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public Teacher SelectedSubject
        {
            get
            {
                return Teachers.FirstOrDefault(x => x.Subject == SelectedGrade.Subject);
            }
            set
            {
                if (value != null)
                {
                    SelectedGrade.Subject = value.Subject;
                    OnPropertyChanged(nameof(SelectedGrade));
                }
            }
        }
        public int SelectedGradeValueIndex
        {
            get
            {
                return SelectedGrade != null && SelectedGrade.GradeValue > 0 ? SelectedGrade.GradeValue - 1 : -1;
            }
            set
            {
                if (value >= 0 && value < GradeValues.Count)
                {
                    SelectedGrade.GradeValue = value+1;
                    OnPropertyChanged(nameof(SelectedGrade));
                }
            }
        }
        public Student SelectedStudent
        {
            get
            {
                return Students.FirstOrDefault(x => x.StudentId == SelectedGrade.StudentId);
            }
            set
            {
                if (value != null)
                {
                    SelectedGrade.StudentId = value.StudentId;
                    OnPropertyChanged(nameof(SelectedGrade));
                }
            }
        }
        public Teacher SelectedTeacher
        {
            get
            {
                return Teachers.FirstOrDefault(x => x.TeacherId == SelectedGrade.TeacherId);
            }
            set
            {
                if (value != null)
                {
                    SelectedGrade.TeacherId = value.TeacherId;
                    OnPropertyChanged(nameof(SelectedGrade));
                }
            }
        }
        public ICommand CreateGradeCommand { get; set; }
        public ICommand DeleteGradeCommand { get; set; }
        public ICommand UpdateGradeCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public GradeWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Grades = new RestCollection<Grade>("http://localhost:56516", "grade");
                Teachers = new RestCollection<Teacher>("http://localhost:56516", "teacher");
                Students = new RestCollection<Student>("http://localhost:56516", "student");
                GradeValues = Enumerable.Range(1,5).ToList();
                CreateGradeCommand = new RelayCommand(() =>
                {
                    
                    Grades.Add(new Grade()
                    {
                        GradeValue = SelectedGrade.GradeValue,
                        StudentId = SelectedGrade.StudentId,
                        TeacherId = SelectedGrade.TeacherId,
                        Subject = SelectedGrade.Subject,
                        Year = DateTime.Now.Year,
                    });
                });
                UpdateGradeCommand = new RelayCommand(() =>
                {
                    Grades.Update(SelectedGrade);
                });
                DeleteGradeCommand = new RelayCommand(() =>
                {
                    Grades.Delete(SelectedGrade.GradeId);
                }, () =>
                {
                    return SelectedGrade != null;
                });
                SelectedGrade = new Grade();
            }
        }
    }
}
