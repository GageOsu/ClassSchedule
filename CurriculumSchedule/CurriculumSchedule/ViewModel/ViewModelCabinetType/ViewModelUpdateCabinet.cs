using CurriculumSchedule.Infrastructure.Commands;
using CurriculumSchedule.Model;
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
    class ViewModelUpdateCabinet : TitleViewModel
    {
        public CabinetType CabinetSelectedTabItem { get; set; }
        private CRUDCabinetType _CRUDCabinetType = new CRUDCabinetType();

        private LambdaCommand _updateCabinetType;
        public ICommand UpdateCabinetType => _updateCabinetType ??= new(_updateCabinetTypeExecuted);
        public void _updateCabinetTypeExecuted()
        {
            _CRUDCabinetType.UpdateCabinetType(CabinetSelectedTabItem);
        }

        public ViewModelUpdateCabinet()
        {
            Title = "Создать кабинет";
            CabinetSelectedTabItem = MainWindowViewModel.SelectedCabinetType;
        }
    }
}
