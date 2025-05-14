using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PatientAppointments; //Added using "add reference"

namespace DatabaseManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatientData TheDatabase = new PatientData();

            try
            {
                using (TheDatabase)
                {
                    //Declaration of class instances/objects
                    //Note that PatientID and AppointmentID do not have to be hardcoded in
                    //primary keys are "randomly" generated whenever a new instance of an object is added to the database

                    Patient Patient1 = new Patient()
                    {
                        FirstName = "John",
                        Surname = "Smith",
                        DOB = new DateTime(2000, 01, 31),
                        ContactNumber = "086 123 4567"
                    };

                    Patient Patient2 = new Patient()
                    {
                        FirstName = "Mary",
                        Surname = "Jones",
                        DOB = new DateTime(1980, 06, 15),
                        ContactNumber = "087 323 2585"
                    };

                    Patient Patient3 = new Patient()
                    {
                        FirstName = "Jim",
                        Surname = "Ryan",
                        DOB = new DateTime(2005, 03, 10),
                        ContactNumber = "086 568 7896"
                    };
                    Console.WriteLine("Patients Created");

                    TheDatabase.ListOfPatients.Add(Patient1);
                    TheDatabase.ListOfPatients.Add(Patient2);
                    TheDatabase.ListOfPatients.Add(Patient3);
                    TheDatabase.SaveChanges();

                    Console.WriteLine("Added the Patients");


                    Appointment Appointment1 = new Appointment() { AppointmentTime = new DateTime(2025, 12, 13), AppointmentNotes = "Prolonged Flu"};
                    Appointment Appointment2 = new Appointment() { AppointmentTime = new DateTime(2025, 12, 13), AppointmentNotes = "Vision Loss" };
                    Appointment Appointment3 = new Appointment() { AppointmentTime = new DateTime(2025, 12, 13), AppointmentNotes = "Unprecedented Amount of Kidney Stones" };

                    TheDatabase.ListOfAppointments.Add(Appointment1);
                    TheDatabase.ListOfAppointments.Add(Appointment2);
                    TheDatabase.ListOfAppointments.Add(Appointment3);
                    TheDatabase.SaveChanges();

                    Console.WriteLine("Added the Appointments");

                    Console.WriteLine("Press Enter To Continue");
                    Console.ReadLine();
                }
            }
            catch (Exception PossibleException)
            {
                Console.WriteLine($"Database Error: {PossibleException.Message}");
            }
        }
    }
}
