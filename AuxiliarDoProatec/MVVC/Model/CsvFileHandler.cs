using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms.Internals;

namespace AuxiliarDoProatec.MVVC.Model
{
    public class CsvFileHandler
    {
        private string[] _studentsArray { get; set; }

        public CsvFileHandler()
        {

        }

        private void ReadCsvFile(string csvFilePath)
        {
            using (StreamReader streamReader = new StreamReader(csvFilePath))
            {
                string[] s = streamReader.ReadToEnd()
                    .Replace("\n", ";")
                    .Replace("\r", ";")
                    .ToUpper()
                    .Split(';');

                _studentsArray = s;
            }


        }

        public List<Student> Students(string csvFilePath)
        {
            ReadCsvFile(csvFilePath);
            List<Student> list = new List<Student>();

            for (int i = 15; i < _studentsArray.Length - 12; i += 12)
            {
                int exists = list.FindIndex(x => x.Name == _studentsArray[i]);
                if(exists > 0)
                {
                    list[exists].AddClass(_studentsArray[i + 8]);
                    continue;
                }
                else
                {
                    Student newStudent = new Student(
                    _studentsArray[i],
                    _studentsArray[i + 1],
                    _studentsArray[i + 2],
                    _studentsArray[i + 3],
                    _studentsArray[i + 4],
                    _studentsArray[i + 5],
                    _studentsArray[i + 6],
                    _studentsArray[i + 7],
                    _studentsArray[i + 9],
                    _studentsArray[i + 10],
                    _studentsArray[i + 11]);

                    newStudent.AddClass(_studentsArray[i + 8]);

                    list.Add(newStudent);
                }
            }

            return list;
        }
}
}
