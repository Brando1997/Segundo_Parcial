using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Parcial_Agenda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Tarea> Tareas { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Tareas = new ObservableCollection<Tarea>();

            ListaTareas.ItemsSource = Tareas;
        }

        private void AgregarTarea_Click(object sender, RoutedEventArgs e)
        {
            Tarea nuevaTarea = new Tarea
            {
                Nombre = NombreTarea.Text,
                Descripcion = DescripcionTarea.Text,
                Fecha = FechaTarea.SelectedDate ?? DateTime.Today
            };

            Tareas.Add(nuevaTarea);

            NombreTarea.Text = "";
            DescripcionTarea.Text = "";
            FechaTarea.SelectedDate = DateTime.Today;
        }

        private void EliminarTarea_Click(object sender, RoutedEventArgs e)
        {
           
            if (ListaTareas.SelectedItem != null)
            {
                Tareas.Remove((Tarea)ListaTareas.SelectedItem);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una tarea para eliminar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class Tarea
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}

