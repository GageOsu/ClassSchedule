using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurriculumSchedule.ViewModel.Base;
using CurriculumSchedule.Models.CRUDOperation;
using System.Collections.ObjectModel;
using CurriculumSchedule.Models;

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
            Weekdays= new ObservableCollection<Weekday>(CRUDWeekday.ReadWeekday());
    }
    }
}
