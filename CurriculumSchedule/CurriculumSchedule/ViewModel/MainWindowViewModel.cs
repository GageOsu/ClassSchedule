using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumSchedule.ViewModel.Base;
using CurriculumSchedule.Models.CRUDOperation;
using System.Collections.ObjectModel;
using CurriculumSchedule.Model;
using System.Windows.Controls;
using CurriculumSchedule.Infrastructure.Commands;
using System.Windows.Input;
using CurriculumSchedule.View;
using System.Windows;
using CurriculumSchedule.View.ViewCabinetTypeCRUDOperation;
using System.IO;
using ClosedXML.Excel;
using Microsoft.Win32;

namespace CurriculumSchedule.ViewModel
{
    internal class MainWindowViewModel : TitleViewModel
    {
        CRUDCabinet CRUDCabinet = new CRUDCabinet();
        CRUDCabinetType CRUDCabinetType = new CRUDCabinetType();
        CRUDDay CRUDDay = new CRUDDay();
        CRUDGroup CRUDGroup = new CRUDGroup();
        CRUDLesson CRUDLesson = new CRUDLesson();
        CRUDLessonNumber CRUDLessonNumber = new CRUDLessonNumber();
        CRUDSemester CRUDSemester = new CRUDSemester();
        CRUDSubject CRUDSubject = new CRUDSubject();
        CRUDTeacher CRUDTeacher = new CRUDTeacher();
        CRUDWeek CRUDWeek = new CRUDWeek();
        CRUDWeekday CRUDWeekday = new CRUDWeekday();

        private ObservableCollection<Cabinet> _cabinets;
        private ObservableCollection<CabinetType> _cabinetTypes;
        private ObservableCollection<Day> _days;
        private ObservableCollection<Group> _groups;
        private ObservableCollection<Lesson> _lessons;
        private ObservableCollection<LessonNumber> _lessonNumbers;
        private ObservableCollection<Semester> _semesters;
        private ObservableCollection<Subject> _subjects;
        private ObservableCollection<Teacher> _teachers;
        private ObservableCollection<Week> _weeks;
        private ObservableCollection<Weekday> _weekdays;
        public ObservableCollection<Cabinet> Cabinets
        {
            get => _cabinets;
            set => Set(ref _cabinets, value);
        }

        public ObservableCollection<CabinetType> CabinetTypes
        {
            get => _cabinetTypes;
            set => Set(ref _cabinetTypes, value);
        }

        public ObservableCollection<Day> Days
        {
            get => _days;
            set => Set(ref _days, value);
        }

        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set => Set(ref _groups, value);
        }

        public ObservableCollection<Lesson> Lessons
        {
            get => _lessons;
            set => Set(ref _lessons, value);
        }

        public ObservableCollection<LessonNumber> LessonNumbers
        {
            get => _lessonNumbers;
            set => Set(ref _lessonNumbers, value);
        }

        public ObservableCollection<Semester> Semesters
        {
            get => _semesters;
            set => Set(ref _semesters, value);
        }

        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set => Set(ref _subjects, value);
        }

        public ObservableCollection<Teacher> Teachers
        {
            get => _teachers;
            set => Set(ref _teachers, value);
        }

        public ObservableCollection<Week> Weeks
        {
            get => _weeks;
            set => Set(ref _weeks, value);
        }

        public ObservableCollection<Weekday> Weekdays
        {
            get => _weekdays;
            set => Set(ref _weekdays, value);
        }

        public TabItem SelectedTabItem { get; set; }
        static private Cabinet _selectedCabinet;
        static private CabinetType _selectedCabinetType;
        static private Day _selectedDay;
        static private Group _selectedGroup;
        static private Lesson _selectedLesson;
        static private LessonNumber _selectedLessonNumber;
        static private Semester _selectedSemester;
        static private Subject _selectedSubject;
        static private Teacher _selectedTeacher;
        static private Week _selectedWeek;
        static private Weekday _selectedWeekday;

        static public Cabinet SelectedCabinet
        {
            get => _selectedCabinet;
            set => _selectedCabinet = value;
        }
        static public CabinetType SelectedCabinetType
        {
            get => _selectedCabinetType;
            set => _selectedCabinetType = value;
        }
        static public Day SelectedDay
        {
            get => _selectedDay;
            set => _selectedDay = value;
        }
        static public Group SelectedGroup
        {
            get => _selectedGroup;
            set => _selectedGroup = value;
        }
        static public Lesson SelectedLesson
        {
            get => _selectedLesson;
            set => _selectedLesson = value;
        }
        static public LessonNumber SelectedLessonNumber
        {
            get => _selectedLessonNumber;
            set => _selectedLessonNumber = value;
        }
        static public Semester SelectedSemester
        {
            get => _selectedSemester;
            set => _selectedSemester = value;
        }
        static public Subject SelectedSubject
        {
            get => _selectedSubject;
            set => _selectedSubject = value;
        }
        static public Teacher SelectedTeacher
        {
            get => _selectedTeacher;
            set => _selectedTeacher = value;
        }
        static public Week SelectedWeek
        {
            get => _selectedWeek;
            set => _selectedWeek = value;
        }
        static public Weekday SelectedWeekday
        {
            get => _selectedWeekday;
            set => _selectedWeekday = value;
        }

        private LambdaCommand? _deleteItem;
        public ICommand DeleteItem => _deleteItem ??= new(_deleteItemCommandExecuted);

        public void _deleteItemCommandExecuted()
        {
            if (SelectedTabItem.Name == "CabinetTab" && SelectedCabinet != null)
            {
                CRUDCabinet.DeleteCabinet(SelectedCabinet);
                Cabinets = CRUDCabinet.ReadCabinet();
            }
            if (SelectedTabItem.Name == "CabinetTypeTab" && SelectedCabinetType != null)
            {
                CRUDCabinetType.DeleteCabinetType(SelectedCabinetType);
                CabinetTypes = CRUDCabinetType.ReadCabinetType();
            }
            if (SelectedTabItem.Name == "DayTab" && SelectedDay != null)
            {
                CRUDDay.DeleteDay(SelectedDay);
                Days = CRUDDay.ReadDay();
            }
            if (SelectedTabItem.Name == "GroupTab" && SelectedGroup != null)
            {
                CRUDGroup.DeleteGroup(SelectedGroup);
                Groups = CRUDGroup.ReadGroup();
            }
            if (SelectedTabItem.Name == "LessonTab" && SelectedLesson != null)
            {
                CRUDLesson.DeleteLesson(SelectedLesson);
                Lessons = CRUDLesson.ReadLesson();
            }
            if (SelectedTabItem.Name == "LessonNumberTab" && SelectedLessonNumber != null)
            {
                CRUDLessonNumber.DeleteLessonNumber(SelectedLessonNumber);
                LessonNumbers = CRUDLessonNumber.ReadLessonNumber();
            }
            if (SelectedTabItem.Name == "SemesterTab" && SelectedSemester != null)
            {
                CRUDSemester.DeleteSemester(SelectedSemester);
                Semesters = CRUDSemester.ReadSemester();
            }
            if (SelectedTabItem.Name == "SubjectTab" && SelectedSubject != null)
            {
                CRUDSubject.DeleteSubject(SelectedSubject);
                Subjects = CRUDSubject.ReadSubject();
            }
            if (SelectedTabItem.Name == "TeacherTab" && SelectedTeacher != null)
            {
                CRUDTeacher.DeleteTeacher(SelectedTeacher);
                Teachers = CRUDTeacher.ReadTeacher();
            }
            if (SelectedTabItem.Name == "WeekTab" && SelectedWeek != null)
            {
                CRUDWeek.DeleteWeek(SelectedWeek);
                Weeks = CRUDWeek.ReadWeek();
            }
            if (SelectedTabItem.Name == "WeekdayTab" && SelectedWeekday != null)
            {
                CRUDWeekday.DeleteWeekday(SelectedWeekday);
                Weekdays = CRUDWeekday.ReadWeekday();
            }
        }

        private LambdaCommand? _openCreateCabinetCommand;
        public ICommand OpenCreateCabinetCommand => _openCreateCabinetCommand ??= new(_onOpenCreateCabinetCommandExecuted);
        private void _onOpenCreateCabinetCommandExecuted()
        {
            CreateCabinetTypeWindow createCabinetTypeWindow = new CreateCabinetTypeWindow();
            createCabinetTypeWindow.ShowDialog();
        }

        private LambdaCommand? _openCreateCabinetTypeCommand;
        public ICommand OpenCreateCabinetTypeCommand => _openCreateCabinetTypeCommand ??= new(_onOpenCreateCabinetTypeCommandExecuted);
        private void _onOpenCreateCabinetTypeCommandExecuted()
        {
            CreateCabinetTypeWindow createCabinetTypeWindow = new CreateCabinetTypeWindow();
            createCabinetTypeWindow.ShowDialog();
        }

        private LambdaCommand? _openUpdateCabinetCommand;
        public ICommand OpenUpdateCabinetCommand => _openUpdateCabinetCommand ??= new(_onOpenUpdateCabinetCommandExecuted);
        private void _onOpenUpdateCabinetCommandExecuted()
        {
            UpdateCabinetTypeWindow updateCabinetTypeWindow = new UpdateCabinetTypeWindow();
            updateCabinetTypeWindow.ShowDialog();
        }

        private LambdaCommand? _updateItem;
        public ICommand UpdateItem => _updateItem ??= new(_updateItemCommandExecuted);

        public void _updateItemCommandExecuted()
        {
            if (SelectedTabItem.Name == "CabinetTab" && SelectedCabinet != null)
            {
                UpdateCabinetTypeWindow updateCabinetTypeWindow = new UpdateCabinetTypeWindow();
                updateCabinetTypeWindow.ShowDialog();
            }
            if (SelectedTabItem.Name == "CabinetTypeTab" && SelectedCabinetType != null)
            {
                UpdateCabinetTypeWindow updateCabinetTypeWindow = new UpdateCabinetTypeWindow();
                updateCabinetTypeWindow.ShowDialog();
            }
        }

        private LambdaCommand? _exportExcelCabinetType;
        public ICommand ExportExcelCabinetType => _exportExcelCabinetType ??= new(ExportExcelCabinetTypeCommandExecuted);


        public void ExportExcelCabinetTypeCommandExecuted()
        {
           using ( var workbook = new XLWorkbook())
           {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Файлы разметки|*.xlsx;*.xlsm;";

                DateTime date = DateTime.Now;
                var worksheet = workbook.Worksheets.Add("Тип кабинета");

                worksheet.Cell("A" + 1).Value = "Тип кабинета";
                worksheet.Cell("B" + 1).Value = "Описание";
                worksheet.Cell("A" + 1).Style.Font.Bold = true;
                worksheet.Cell("B" + 1).Style.Font.Bold = true;

                worksheet.Columns().AdjustToContents();
                var data = CRUDCabinetType.ReadCabinetType();
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).SetValue(data.ElementAt(i).CabinetName);
                    worksheet.Cell(i + 2, 2).SetValue(data.ElementAt(i).Discription);
                }
                var zxc = data.Count +1;
                var rngTable = worksheet.Range("A1:B" + zxc);
                rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;


                if (saveFileDialog.ShowDialog() == true)
                {
                    var put = saveFileDialog.FileName;
                    workbook.SaveAs(put);
                }
            }
        }
        public MainWindowViewModel()
        {
            Title = "Главное окно";
            Cabinets = new ObservableCollection<Cabinet>(CRUDCabinet.ReadCabinet());
            CabinetTypes = new ObservableCollection<CabinetType>(CRUDCabinetType.ReadCabinetType());
            Days = new ObservableCollection<Day>(CRUDDay.ReadDay());
            Groups = new ObservableCollection<Group>(CRUDGroup.ReadGroup());
            Lessons = new ObservableCollection<Lesson>(CRUDLesson.ReadLesson());
            LessonNumbers = new ObservableCollection<LessonNumber>(CRUDLessonNumber.ReadLessonNumber());
            Semesters = new ObservableCollection<Semester>(CRUDSemester.ReadSemester());
            Subjects = new ObservableCollection<Subject>(CRUDSubject.ReadSubject());
            Teachers = new ObservableCollection<Teacher>(CRUDTeacher.ReadTeacher());
            Weeks = new ObservableCollection<Week>(CRUDWeek.ReadWeek());
            Weekdays = new ObservableCollection<Weekday>(CRUDWeekday.ReadWeekday());
        }
    }
}
