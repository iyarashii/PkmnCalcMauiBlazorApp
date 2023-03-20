// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public interface IPokedexType
    {
        string Name { get; }
        string Url { get; }
        string Regex { get; }
        string FileName { get; }
    }
}
