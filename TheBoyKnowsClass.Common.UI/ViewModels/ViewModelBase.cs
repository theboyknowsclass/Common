using System;
using System.ComponentModel;

namespace TheBoyKnowsClass.Common.UI.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

            EventHandler<DataErrorsChangedEventArgs> errorHandler = ErrorsChanged;
            if (errorHandler != null)
            {
                errorHandler(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
        #endregion

        public bool IsInDebug
        {
            get
            {
                #if DEBUG
                    return true;
                #else
                    return false;
                #endif
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}
