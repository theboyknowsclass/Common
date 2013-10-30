using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Microsoft.Practices.Prism.Commands;
using TheBoyKnowsClass.Common.UI.ViewModels;
using TheBoyKnowsClass.Common.UI.WPF.Modern.Interfaces;
using TheBoyKnowsClass.Common.UI.WPF.Modern.Models;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.ViewModels
{
    public class AppearanceManagerViewModel : ViewModelBase
    {
        private readonly IAppearanceSettings _settings;
        private readonly ObservableCollection<ThemeResource> _themes;
        private readonly ObservableCollection<AccentResource> _accents;
        private readonly ObservableCollection<string> _accentGroups;
        private readonly CollectionViewSource _accentGroupings;


        public DelegateCommand ApplyCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        private ThemeResource _selectedTheme;
        private AccentResource _selectedAccent;
        private string _selectedAccentGroup;

        public AppearanceManagerViewModel(IAppearanceSettings settings)
        {
            _settings = settings;

            _themes = new ObservableCollection<ThemeResource>(AppearanceManager.GetThemes());
            _selectedTheme = (from t in _themes where t.Name == _settings.Theme select t).FirstOrDefault();

            if (_selectedTheme == null)
            {
                SelectedTheme = CurrentTheme;
            }
            SelectedTheme.Apply();

            _accents = new ObservableCollection<AccentResource>(AppearanceManager.GetAccents());
            _accentGroups = new ObservableCollection<string>((from a in _accents orderby a.SortOrder ascending select a.AccentGroup).Distinct().ToList());
            _accentGroupings = new CollectionViewSource { Source = _accents };
            _accentGroupings.Filter += AccentGroupingsOnFilter;
            _accentGroupings.SortDescriptions.Add(new SortDescription("SortOrder", ListSortDirection.Ascending));

            _selectedAccent = (from a in _accents where a.Name == _settings.Accent select a).FirstOrDefault();

            if (_selectedAccent == null)
            {
                SelectedAccent = CurrentAccent;
            }
            SelectedAccent.Apply();

            ApplyCommand = new DelegateCommand(Apply, CanExecuteApply);
            CancelCommand = new DelegateCommand(Cancel, CanExecuteCancel);
        }

        private bool _isApplying;

        private void Apply()
        {
            _isApplying = true;
            RaisePropertyChanged("CanCancel");
            RaisePropertyChanged("CanApply");
            ApplyCommand.RaiseCanExecuteChanged();

            if (!Equals(SelectedAccent, CurrentAccent))
            {
                SelectedAccent.Apply();
            }

            if (!Equals(SelectedTheme, CurrentTheme))
            {
                SelectedTheme.Apply();
            }

            _settings.Save();

            _isApplying = false;
            RaisePropertyChanged("CanCancel");
            RaisePropertyChanged("CanApply");
            ApplyCommand.RaiseCanExecuteChanged();
        }

        public bool CanApply
        {
            get
            {
                bool changes = HasChanges();
                return !_isApplying && !_isCancelling && changes;
            }
        }

        private bool CanExecuteApply()
        {
            return CanApply;
        }

        private bool _isCancelling;

        private void Cancel()
        {
            _isCancelling = true;
            RaisePropertyChanged("CanCancel");
            RaisePropertyChanged("CanApply");
            CancelCommand.RaiseCanExecuteChanged();

            SelectedAccent = CurrentAccent;
            SelectedTheme = CurrentTheme;

            _isCancelling = false;
            RaisePropertyChanged("CanCancel");
            RaisePropertyChanged("CanApply");
            CancelCommand.RaiseCanExecuteChanged();
        }

        public bool CanCancel
        {
            get
            {
                return !_isApplying && !_isCancelling && HasChanges();
            }
        }

        private bool CanExecuteCancel()
        {
            return CanCancel;
        }

        private bool HasChanges()
        {
            return !Equals(SelectedAccent, CurrentAccent) || !Equals(SelectedTheme, CurrentTheme);
        }

        public ThemeResource SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                _selectedTheme = value;
                _settings.Theme = value.Name;
                RaisePropertyChanged("SelectedTheme");
                RaisePropertyChanged("CanCancel");
                RaisePropertyChanged("CanApply");
            }
        }

        public AccentResource SelectedAccent
        {
            get { return _selectedAccent; }
            set
            {
                _selectedAccent = value;
                _settings.Accent = value == null ? null : value.Name;
                RaisePropertyChanged("SelectedAccent");
                RaisePropertyChanged("CanCancel");
                RaisePropertyChanged("CanApply");
            }
        }

        private ThemeResource CurrentTheme
        {
            get { return new ThemeResource(AppearanceManager.GetCurrentThemeDictionary()); }
        }

        public ThemeResource DefaultTheme
        {
            get { return Themes.FirstOrDefault(); }
        }

        private AccentResource CurrentAccent
        {
            get
            {
                return new AccentResource(AppearanceManager.GetCurrentAccentDictionary());
            }
        }

        public AccentResource DefaultAccent
        {
            get { return AllAccents.FirstOrDefault(); }
        }

        public ObservableCollection<ThemeResource> Themes
        {
            get
            {
                return _themes;
            }
        }

        public ObservableCollection<AccentResource> AllAccents
        {
            get
            {
                return _accents;
            }
        }

        public ObservableCollection<string> AccentGroups
        {
            get
            {
                return _accentGroups;
            }
        }

        public string SelectedAccentGroup
        {
            get { return _selectedAccentGroup ?? (_selectedAccentGroup = _accentGroups.FirstOrDefault()); }
            set
            {
                _selectedAccentGroup = value;
                RaisePropertyChanged("SelectedAccentGroup");
                _accentGroupings.View.Refresh();     
            }
        }

        private void AccentGroupingsOnFilter(object sender, FilterEventArgs filterEventArgs)
        {
            var accentResource = (AccentResource)filterEventArgs.Item;

            if (SelectedAccentGroup.Length == 0)
            {
                filterEventArgs.Accepted = true;
            }
            else
            {
                filterEventArgs.Accepted = accentResource.AccentGroup == SelectedAccentGroup;
            }
        }

        public ICollectionView FilteredAccents
        {
            get
            {
                return _accentGroupings.View;
            }
        }

    }
}
