﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProj
{
    public interface IShell
    {
        IShellViewModel ViewModel { get; set; }
    }
}
