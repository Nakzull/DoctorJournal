using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorJournal
{
    public class DataStorage
    {
        
        int patientNumber = 0;

        // Check if a local file exists with the correct patient number and if so update it from 0.
        public void PatientNumber()
        {
            if (File.Exists(@"C:\\journalopgave\patientNumber.txt"))
                patientNumber = Convert.ToInt32(File.ReadAllText(@"C:\\journalopgave\patientNumber.txt"));
        }

        // Check if a local folder exists for all the files used in the program.
        public void CheckFolder()
        {
            if (!Directory.Exists(@"c:\journalopgave"))
                Directory.CreateDirectory(@"c:\journalopgave");
        }
        // Method for creating a new patient and write it to a local file.
        public void CreatePatient(string name, string adress, int phoneNumber, string email, string cprNumber, string preferredDoctor, DateTime dateOfBirth)
        {
            int ageYear = 0;
            if (DateTime.Now.Month > dateOfBirth.Month)
                ageYear = DateTime.Now.Year - dateOfBirth.Year - 1;
            else
                ageYear = DateTime.Now.Year - dateOfBirth.Year;
            DateTime now = DateTime.Now;
            int ageDay = (int)((now - dateOfBirth).TotalDays % 365.25);
            string fileName = @"c:\\journalopgave\patient" + patientNumber +".txt";

            // Create a new file     
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine($"Name: {name}\n" +
                    $"Adress: {adress}\n" +
                    $"Phonenumber: {phoneNumber}\n" +
                    $"Email: {email}\n" +
                    $"CPR Number: {cprNumber}\n" +
                    $"Preferred doctor: {preferredDoctor}\n" +
                    $"Age: {ageYear}");
                sw.Close();
            }
            // Update the patient number in the local file.
            using (StreamWriter sw = File.CreateText(@"C:\\journalopgave\patientNumber.txt"))
            {
                patientNumber++;
                sw.WriteLine(patientNumber);
                sw.Close();
            }
            // Add the name of the patient to the local file.
            using (StreamWriter sw = File.AppendText(@"C:\\journalopgave\patientNames.txt"))
            {
                sw.WriteLine(name);
                sw.Close();
            }
        }
        // Method for creating new journal entries and writing them to a local file
        public void CreateJournalEntry(DateTime date, string doctor, string entry, int patientIndex)
        {
            JournalEntry journal = new JournalEntry(date, doctor, entry);
            int entryNumber = 0;
            if (Directory.Exists(@"c:\journalopgave\patient" + patientIndex))
            {
                entryNumber = Convert.ToInt32(File.ReadAllText(@"C:\\journalopgave\patient" + patientIndex + @"\entryNumber.txt"));
            }
            else
                Directory.CreateDirectory(@"c:\journalopgave\patient" + patientIndex);
            string fileName = @"C:\\journalopgave\patient" + patientIndex + @"\entry" + entryNumber + ".txt";
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine($"Date: {date}\n" +
                    $"Doctor: {doctor}\n" +
                    $"Journal entry: {entry}\n");
                sw.Close();
            }
            using (StreamWriter sw = File.CreateText(@"C:\\journalopgave\patient" + patientIndex + @"\entryNumber.txt"))
            {
                entryNumber++;
                sw.WriteLine(entryNumber);
                sw.Close();
            }
        }
        // Method for getting the total amount of journal entries for a patient.
        public int GetTotalJournalEntries(int patientIndex)
        {
            if (File.Exists(@"C:\\journalopgave\patient" + patientIndex + @"\entryNumber.txt"))
            {
                return Convert.ToInt32(File.ReadAllText(@"C:\\journalopgave\patient" + patientIndex + @"\entryNumber.txt"));
            }
            else
                return 0;
        }
        // Method for getting a journal entry for a patient.
        public void GetJournal(int patientNumber, int journalIndex)
        {            
            StreamReader sr = new StreamReader(@"C:\\journalopgave\patient" + patientNumber + @"\entry" + journalIndex +".txt");
            string line;
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        // Method for finding the names of all patients in the system.
        public List<string> GetPatientsInSystem()
        {
            List<string> listOfPatientsInSystem = new List<string>();
            if (File.Exists(@"C:\\journalopgave\patientNames.txt"))
            {
                StreamReader sr = new StreamReader(@"C:\\journalopgave\patientNames.txt");
                string line;
                line = sr.ReadLine();
                while (line != null)
                {
                    listOfPatientsInSystem.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                return listOfPatientsInSystem;
            }
            else
            {
                using (StreamWriter sw = File.CreateText(@"C:\\journalopgave\patientNames.txt"))
                {
                    sw.Close();
                }
            }
            return listOfPatientsInSystem;
        }
    }
}
