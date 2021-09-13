using System;
using System.Collections.Generic;
using System.IO;

namespace DoctorJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientManager patientManager = new PatientManager();
            patientManager.GetPatientsInSystem();
            for (; ; )
            {
                Console.WriteLine("1. Create new journal\n2. Patient search");
                int userChoice = Convert.ToInt32(Console.ReadLine());
                if (userChoice == 1)
                {
                    Console.WriteLine("Name of the patient you wish to create");
                    string name = Console.ReadLine();
                    Console.WriteLine("Adress of the patient you wish to create");
                    string adress = Console.ReadLine();
                    Console.WriteLine("Phonenumber of the patient you wish to create");
                    int phoneNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Email of the patient you wish to create");
                    string email = Console.ReadLine();
                    Console.WriteLine("CPR number of the patient you wish to create (no spaces)");
                    string cprNumber = Console.ReadLine();
                    int cprYear = Convert.ToInt32(cprNumber.Substring(4, 4));
                    int cprMonth = Convert.ToInt32(cprNumber.Substring(2, 2));
                    int cprDay = Convert.ToInt32(cprNumber.Substring(0, 2));
                    DateTime dateOfBirth = new DateTime(cprYear, cprMonth, cprDay);
                    Console.WriteLine("Preferred doctor of the patient you wish to create");
                    string preferredDoctor = Console.ReadLine();
                    patientManager.CreatePatient(name, adress, phoneNumber, email, cprNumber, preferredDoctor, dateOfBirth);
                }
                else if (userChoice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Name of patient you are looking for");
                    string name = Console.ReadLine().ToLower();
                    List<string> allPatientsInSystem = new List<string>(patientManager.GetPatientsInSystem());
                    for (int i = 0; i < allPatientsInSystem.Count; i++)
                    {
                        if (allPatientsInSystem[i].Equals(name))
                        {
                            string line;
                            StreamReader sr = new StreamReader(@"C:\journalopgave\patient" + i + ".txt");
                            line = sr.ReadLine();
                            while (line != null)
                            {
                                Console.WriteLine(line);
                                line = sr.ReadLine();
                            }
                            sr.Close();
                            bool keepRunning = true;
                            while (keepRunning == true)
                            {
                                Console.WriteLine("1. Create new journal entry\n" +
                                "2. View journal entries for the patient\n" +
                                "3. Return to the main menu");
                                int journalEntryChoice = Convert.ToInt32(Console.ReadLine().ToLower());
                                if (journalEntryChoice == 1)
                                {
                                    Console.WriteLine("Name of doctor?");
                                    string doctorName = Console.ReadLine();
                                    Console.WriteLine("Journal entry for the patient");
                                    string journalEntry1 = Console.ReadLine();
                                    patientManager.CreateJournalEntry(DateTime.Now, doctorName, journalEntry1, i);
                                }
                                else if (journalEntryChoice == 2)
                                {
                                    int totalEntries = patientManager.GetTotalJournalEntries(i);
                                    if (totalEntries == 0)
                                    {
                                        Console.WriteLine("No entries for that patient");
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        for (int j = 0; j < totalEntries; j++)
                                        {
                                            patientManager.GetJournal(i, j);
                                            Console.WriteLine("1. Return to the main menu");
                                            Console.WriteLine("2. Next journal entry");
                                            if (j > 0)
                                            {
                                                Console.WriteLine("3. Previous journal entry");
                                            }

                                            int createEntryChoice = Convert.ToInt32(Console.ReadLine());
                                            if (createEntryChoice == 1)
                                            {
                                                keepRunning = false;
                                                break;
                                            }
                                            else if (createEntryChoice == 2)
                                            {
                                            }
                                            else if (createEntryChoice == 3)
                                                j -= 2;
                                            else
                                            {
                                                Console.WriteLine("Please select a valid input");
                                                j--;
                                            }
                                        }

                                    }
                                }
                                else if (journalEntryChoice == 3)
                                {
                                    keepRunning = false;
                                }
                                else
                                    Console.WriteLine("Please select a valid input");
                            }
                        }
                    }
                }
                else
                    Console.WriteLine("Please input a valid option");
            }
        }
    }
}
