﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;



namespace AuxiliarDoProatec.Services
{
    public interface IOpenFile
    {
        Task<FileResult> PickAFile();
    }
}
