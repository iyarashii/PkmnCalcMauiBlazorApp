// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class BasePage : ComponentBase
    {
        public static async Task<IEnumerable<string>> SearchForMatchingNamesInFile(string name, System.IO.Abstractions.IFileSystem fileSystem, string pathToData)
        {
            // if text is null or empty, don't return values (drop-down will not open)
            if (string.IsNullOrEmpty(name))
                return Array.Empty<string>();
            var names = await fileSystem.File.ReadAllLinesAsync(pathToData);
            return names.Where(x => x.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }
        [GeneratedRegex("</option>")]
        public static partial Regex OptionClosingTag();
    }
}
