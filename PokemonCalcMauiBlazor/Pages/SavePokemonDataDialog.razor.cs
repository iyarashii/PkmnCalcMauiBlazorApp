// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class SavePokemonDataDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}
