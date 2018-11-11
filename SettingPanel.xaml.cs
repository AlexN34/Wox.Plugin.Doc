using System.Windows;
using System.Windows.Controls;

namespace Wox.Plugin.Doc
{
    /// <summary>
    /// Interaction logic for SettingPanel.xaml
    /// </summary>
   public partial class SettingPanel : UserControl
    {
        private Settings _settings;

        public SettingPanel(Settings settings)
        {
            InitializeComponent();
            _settings = settings;
            Loaded += SettingPanel_Loaded;
            DataContext = this._settings;
        }

        void SettingPanel_Loaded(object sender, RoutedEventArgs e)
        {
            lbInstalledDocs.ItemsSource = DocSet.InstalledDocs;

            switch(_settings.BrowserLocationMethod)
            {
                case "ROOT_DEFAULT":
                    ROOT_DEFAULT.IsChecked = true;
                    break;
                case "USER_DEFAULT":
                    USER_DEFAULT.IsChecked = true;
                    break;
                case "CUSTOM":
                    CUSTOM.IsChecked = true;
                    break;
            }

            
        }

        private void OnSelectBrowserDirectoryClick(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.OpenFileDialog { } ;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string chosenBrowserPath = dlg.FileName;
                if (string.IsNullOrEmpty(chosenBrowserPath))
                {
                    System.Windows.MessageBox.Show("Can't find browser executable at this path");
                }
                else
                {
                    _settings.CustomBrowserPath = chosenBrowserPath;
                }
            }

        }

        private void OnCheckRadioBox(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.IsChecked.Value)
            {
                _settings.BrowserLocationMethod = rb.Name;
            } 

        }



    }
}
