using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace AssemblyBrowserLib
{
    public class ModelViewer : INotifyPropertyChanged
    {
        AssemblyReader result;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AssemblyReader AssemblyTree
        {
            get
            {
                return result;
            }
            protected set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        protected void LoadAssembly(object o)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Assemblies|*.dll;*.exe",
                Title = "Select assembly",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AssemblyTree = new AssemblyReader(openFileDialog.FileName);
            }
        }

        public Command LoadCommand
        { get; protected set; }

        public ModelViewer()
        {
            LoadCommand = new Command(LoadAssembly);
        }
    }
}
