using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumSchedule.ViewModel.Base
{
    internal abstract class TitleViewModel : ViewModelBase
    {
        #region Заголовок
        /// <summary>Заголовок</summary>
        private string _title;

        /// <summary>Заголовок</summary>
        public string Title { get => _title; set => Set(ref _title, value); }
        #endregion
    }
}
