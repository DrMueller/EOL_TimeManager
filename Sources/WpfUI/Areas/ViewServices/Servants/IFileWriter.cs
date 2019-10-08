using System;
using System.Collections.Generic;
using System.Text;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.WpfUI.Areas.ViewServices.Servants
{
    public interface IFileWriter
    {
        void WriteAndOpenTextFile(IReadOnlyCollection<SapEntry> entries);
    }
}
