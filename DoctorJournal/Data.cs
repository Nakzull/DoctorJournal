﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorJournal
{
    public class DataStorage
    {
        // Get the patient number from the file in the directory and initialise lists of patients and journal entries.
        int patientNumber = Convert.ToInt32(File.ReadAllText(@"C:\\journalopgave\patientNumber.txt"));

        List<JournalEntry> journalEntry = new List<JournalEntry>();

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
            Patient patient1 = new Patient(name, adress, phoneNumber, email, cprNumber, preferredDoctor, ageYear, ageDay, journalEntry);
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
            patientNumber++;
            using (StreamWriter sw = File.CreateText(@"C:\\journalopgave\patientNumber.txt"))
            {
                sw.WriteLine(patientNumber);
                sw.Close();
            }
            // Update the patient number in the local file.
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
    }
}