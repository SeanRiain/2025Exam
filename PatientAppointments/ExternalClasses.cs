using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //Needed for database connection

namespace PatientAppointments
{
    //One Patient may have multiple appointments (on different days/at different times), but an Appointment will only be designated for one uniquely identified patient.
    //In database orientated code, classes like these can be visually understood as tables with columns (their variables) and rows, unique combinations of values of those variables types
    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNumber { get; set; }

        //One to many relationship between the two classes
        //This class needs to be able to have multiple instances of Appointment, for that we need a list
        //List<What class type will be stored in the list> [NameOfList] { get; set; }
        public virtual List<Appointment> OnePatientsManyAppointments { get; set; }

        public override string ToString()
        {
            return $"{Surname}, {FirstName} - {ContactNumber}";
        }
    }
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string AppointmentNotes { get; set; }

        //As each instance of Appointment is dependent on having a relationship to a unique instance of Patient
        //it needs access to the primary key/identity variable of that class
        public int PatientID { get; set; }
        //And it also needs to expect an instance of the whole Patient class as well
        public virtual Patient ThisAppointmentsPatient { get; set; }

        
    }

    public class PatientData : DbContext
    {
        public PatientData() : base("OODExam_SeanRiain"){ } //Declares the name of the database
        public DbSet<Patient> ListOfPatients { get; set; }
        public DbSet<Appointment> ListOfAppointments { get; set; }

    }
}
