using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliarDoProatec.MVVC.Model
{
    public class Student
    {
        public string Name { get; set; }
        public string RA { get; set; }
        public string DigitoRA { get; set; }
        public string UF { get; set; }
        public string EmailMicrosoft { get; set; }
        public string EmailGoogle { get; set; }
        public string AnoLetivo { get; set; }
        public string NumeroClasse { get; set; }
        public List<string> Turma { get; set; }
        public string Diretoria { get; set; }
        public string CIE { get; set;}
        public string Escola { get; set; }


        public Student(string name, string rA, string digitoRA, string uF, string emailMicrosoft, string emailGoogle, string anoLetivo, string numeroClasse, string diretoria, string cIE, string escola)
        {
            Name = name;
            RA = rA;
            DigitoRA = digitoRA;
            UF = uF;
            EmailMicrosoft = emailMicrosoft;
            EmailGoogle = emailGoogle;
            AnoLetivo = anoLetivo;
            NumeroClasse = numeroClasse;
            Diretoria = diretoria;
            CIE = cIE;
            Escola = escola;

            Turma = new List<string>();
        }

        public void AddClass(string turma)
        {
            Turma.Add(turma);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
