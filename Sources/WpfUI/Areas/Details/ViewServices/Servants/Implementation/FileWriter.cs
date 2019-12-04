using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Abstractions;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.TimeManager.Domain.Areas.Models;

namespace Mmu.TimeManager.WpfUI.Areas.Details.ViewServices.Servants.Implementation
{
    public class FileWriter : IFileWriter
    {
        private readonly IFileSystem _fileSystem;

        public FileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void WriteAndOpenTextFile(IReadOnlyCollection<ExportReportEntry> entries)
        {
            var sb = new StringBuilder();

            entries.ForEach(
                f =>
                {
                    sb.Append(f.AbsoluteTimeDescription);
                    sb.Append("\t");
                    sb.Append(f.TimeDescriptionInMinutes);
                    sb.Append("\t");
                    sb.AppendLine(f.DescriptionExternal);
                });

            var tempFileName = _fileSystem.Path.GetTempFileName();
            _fileSystem.File.WriteAllText(tempFileName, sb.ToString());
            Process.Start("notepad.exe", tempFileName);
        }
    }
}