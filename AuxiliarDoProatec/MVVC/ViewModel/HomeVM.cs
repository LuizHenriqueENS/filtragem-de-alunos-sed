using AuxiliarDoProatec.Core;
using AuxiliarDoProatec.MVVC.Model;
using AuxiliarDoProatec.MVVC.View;
using AuxiliarDoProatec.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AuxiliarDoProatec.MVVC.ViewModel
{
    public class HomeVM : ObservableObject
    {
        private readonly CsvFileHandler CsvHandler;
        private string CsvFilePath { get; set; }

        #region Interfaces
        public ICommand OpenFileCM { get; set; }

        private IOpenFile OpenFile { get; set; }
        private INavigationService NavigationService { get; set; }
        #endregion

        // first student list
        private List<Student> _firstListofStudents = new List<Student>();

        private List<Student> _studentsList;
        public List<Student> StudentsList
        {
            get => _studentsList;
            set
            {
                _studentsList = value;
                OnPropertyChanged(nameof(StudentsList));
            }
        }

        private string _searchStudentByName;
        public string SearchStudentByName
        {
            get { return _searchStudentByName; }
            set
            {
                _searchStudentByName = value;

                if (_searchStudentByName.Length >= 2)
                {

                    StudentsList = _firstListofStudents.Where(x => x.Name.StartsWith(_searchStudentByName.ToUpper())).ToList();
                }
                else
                {
                    StudentsList = null;
                }

                OnPropertyChanged(nameof(SearchStudentByName));
            }
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;

                try
                {
                    if (_selectedStudent != null)
                    {
                        NavigationService.NavigateTo(new StudentPage(_selectedStudent.Name, _selectedStudent.Escola, _selectedStudent.Turma, _selectedStudent.RA, _selectedStudent.DigitoRA));
                        OnPropertyChanged(nameof(SelectedStudent));
                    }

                }
                catch (System.Exception)
                {

                    System.Console.WriteLine("BUUUG");
                }


            }
        }


        private bool _isStudentListEmpty;
        public bool IsStudentListEmpty
        {
            get { return _isStudentListEmpty; }
            set
            {
                _isStudentListEmpty = value;
                OnPropertyChanged(nameof(IsStudentListEmpty));
            }
        }


        public HomeVM()
        {
            OpenFile = DependencyService.Get<IOpenFile>();
            NavigationService = DependencyService.Get<INavigationService>();

            CsvHandler = new CsvFileHandler();

            IsStudentListEmpty = _firstListofStudents.Count <= 0;
            OpenFileCM = new Command(() => OpenFileMethod());
        }

        private async void OpenFileMethod()
        {
            var result = await OpenFile.PickAFile();
            if (result != null)
            {
                CsvFilePath = result.FullPath;
                _firstListofStudents = CsvHandler.Students(CsvFilePath);
            }
            IsStudentListEmpty = _firstListofStudents.Count <= 0;
        }


        public string GetCsvFilePath()
        {
            return CsvFilePath;
        }
    }
}
