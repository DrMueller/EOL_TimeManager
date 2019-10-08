using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;

namespace Mmu.TimeManager.WpfUI.Areas.ViewData
{
    public abstract class ValidatableViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errorsByProperty = new Dictionary<string, List<string>>();

        public bool HasErrors => _errorsByProperty.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return
                _errorsByProperty.ContainsKey(propertyName) ?
                _errorsByProperty[propertyName] :
                null;
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errorsByProperty.ContainsKey(propertyName))
            {
                _errorsByProperty[propertyName] = new List<string>();
            }

            if (!_errorsByProperty[propertyName].Contains(error))
            {
                _errorsByProperty[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorsByProperty.ContainsKey(propertyName))
            {
                _errorsByProperty.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}