// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages
{
    public class BasePage : ComponentBase
    {
        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
