using Library.TheraOffice;
using TheraOffice.Models;
using TheraOffice.Services;
using System;

namespace CLI.TheraOffice
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TheraOffice!");
            List<Patient?> patients = new List<Patient?>();     //Patient
            List<Physician?> physicians = new List<Physician?>();   //Physician 
            List<Appointment?> appointments = new List<Appointment?>(); //Appointments
            bool cont = true; //Continue/Exit

            do
            {
                Console.WriteLine("P. PATIENTS");
                Console.WriteLine("R. PHYSICIANS");
                Console.WriteLine("A. APPOINTMENTS");
                Console.WriteLine("E. EXIT");

                var userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "P":
                    case "p":
                        Console.WriteLine("C. Create a new patient");
                        Console.WriteLine("L. List all patients");

                        var choice = Console.ReadLine();
                        choice = choice.ToLower();

                        if (choice == "c")
                        {
                            var patient = new Patient();

                            Console.WriteLine("Name: ");
                            patient.Name = Console.ReadLine();
                            Console.WriteLine("Address: ");
                            patient.Address = Console.ReadLine();
                            Console.WriteLine("Birthdate: ");
                            patient.BirthDate = Console.ReadLine();
                            Console.WriteLine("Race: ");
                            patient.Race = Console.ReadLine();
                            Console.WriteLine("Gender: ");
                            patient.Gender = Console.ReadLine();
                            Console.WriteLine("Notes: ");
                            patient.Notes = Console.ReadLine();

                            var maxId = -1; 
                            if (patients.Any())
                            {
                            maxId = patients.Select(b => b?.Id ?? -1).Max();
                            } else
                            {
                            maxId = 0;
                            }
                        patient.Id = ++maxId;
                        patients.Add(patient);
                        }
                        else if (choice == "l")
                        {
                            foreach (var b in patients)
                            {
                                Console.WriteLine(b);
                            }
                        }
                        break;
                    case "R":
                    case "r":
                        Console.WriteLine("C. Create a new physician");
                        Console.WriteLine("L. List all physicians");

                        choice = Console.ReadLine();
                        choice = choice.ToLower();

                        if (choice == "c")
                        {
                            var physician = new Physician();
                            Console.WriteLine("Name: ");
                            physician.Name = Console.ReadLine();
                            Console.WriteLine("License number: ");
                            physician.License = Console.ReadLine();
                            Console.WriteLine("Graduation date: ");
                            physician.GraduationDate = Console.ReadLine();
                            Console.WriteLine("Specializations: ");
                            physician.Special = Console.ReadLine();

                            var maxId = -1; 
                            if (physicians.Any())
                            {
                            maxId = physicians.Select(b => b?.Id ?? -1).Max();
                            } else
                            {
                            maxId = 0;
                            }
                        physician.Id = ++maxId;
                        physicians.Add(physician);
                        }
                        else if (choice == "l")
                        {
                            foreach (var b in physicians)
                            {
                                Console.WriteLine(b);
                            }
                        }
                        break;

                    case "A":
                    case "a":
                        Console.WriteLine("C. Create an appointment");
                        Console.WriteLine("L. List all appointments");

                        choice = Console.ReadLine();
                        choice = choice.ToLower();

                        if (choice == "c")
                        {
                            var appointment = new Appointment();
                            Console.WriteLine("Pick a day >");
                            Console.WriteLine("M. Monday\nT.Tuesday\nW. Wednesday\nR.Thursday\nF.Friday\nS. Saturday\nY. Sunday");

                            do
                            {
                                choice = Console.ReadLine();
                                choice = choice.ToLower();
                            } while (choice != "m" && choice != "t" && choice != "w" && choice != "r" && choice != "f" && choice != "s" && choice != "y");
                            appointment.Day = choice;

                            int time;
                            do
                            {
                                Console.WriteLine("Pick an appointment time (military time) (8 to 17)");
                                var input = Console.ReadLine();
                                int.TryParse(input, out time);
                            } while (time < 8 || time > 17);

                            appointment.Time = time.ToString();

                         var maxId = -1; 
                            if (appointments.Any())
                            {
                            maxId = appointments.Select(b => b?.Id ?? -1).Max();
                            } else
                            {
                            maxId = 0;
                            }
                        appointment.Id = ++maxId;
                        appointments.Add(appointment);
                        }
                        else if (choice == "l")
                        {
                            foreach (var b in appointments)
                            {
                                Console.WriteLine(b);
                            }
                        }
                        break;

                    case "E":
                    case "e":
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            } while (cont);

            Console.WriteLine("Goodbye!");

        }
    }
}