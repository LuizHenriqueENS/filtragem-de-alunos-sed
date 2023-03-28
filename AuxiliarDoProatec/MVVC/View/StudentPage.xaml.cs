using AuxiliarDoProatec.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuxiliarDoProatec.MVVC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage(string name, string escola, List<string> turmas, string ra, string digitoRa)
        {
            InitializeComponent();

            nomeEscola.Text = escola;
            studenName.Text = name;

            foreach (string turma in turmas)
            {
                this.turma.Text += $"\n{turma}";
            }
            RA_Aluno.Text = Convert.ToUInt64(ra).ToString(@"000\.000\.000\") + $"-{digitoRa}";
        }
    }
}