using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatientAppointments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PatientData PatientData = new PatientData();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Query the database for all patients
        //Order them by Name
        //Display in listbox in the formated designated by the ToString()

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var PatientQuery = from SinglePatient in PatientData.ListOfPatients
                               where SinglePatient.PatientID > 0 //Should select all Patients as all their IDs will be above zero
                               select SinglePatient;

            var Patients = PatientQuery.ToList(); 
        }

       
    }
}
