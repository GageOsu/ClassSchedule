using CurriculumSchedule.Infrastructure.Commands;
using CurriculumSchedule.Models.CRUDOperation;
using CurriculumSchedule.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurriculumSchedule.ViewModel.ViewModelCabinetType
{
    class ViewModelCreateCabinet : TitleViewModel
    {
        private string _cabinetName;
        private string _description;
        private CRUDCabinetType _CRUDCabinetType = new CRUDCabinetType();

        public string CabinetName
        {
            get => _cabinetName;
            set => Set(ref _cabinetName, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        private LambdaCommand _createCabinetType;
        public ICommand CreateCabinetType => _createCabinetType ??= new(_createCabinetTypeExecuted);
        public void _createCabinetTypeExecuted()
        {
            _CRUDCabinetType.CreateCabinetType(CabinetName, Description);
        }

        public ViewModelCreateCabinet()
        {
            Title = "Создать кабинет";
        }
    }
}
