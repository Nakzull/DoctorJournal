using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorJournal
{
    public class PatientManager
    {
        DataStorage dataStorage = new DataStorage();

        public void CreatePatient(string name, string adress, int phoneNumber, string email, string cprNumber, string preferredDoctor, DateTime dateOfBirth)
        {
            dataStorage.CreatePatient(name, adress, phoneNumber, email, cprNumber, preferredDoctor, dateOfBirth);
        }

        public void CreateJournalEntry(DateTime date, string doctor, string entry, int patientIndex)
        {
            dataStorage.CreateJournalEntry(date, doctor, entry, patientIndex);
        }

        public List<string> GetPatientsInSystem()
        {
            return dataStorage.GetPatientsInSystem();
        }
        public void GetJournal(int patientNumber, int journalIndex)
        {
            dataStorage.GetJournal(patientNumber, journalIndex);
        }
        public int GetTotalJournalEntries(int patientIndex)
        {
            return dataStorage.GetTotalJournalEntries(patientIndex);
        }
        public void CheckFolder()
        {
            dataStorage.CheckFolder();
        }
        public void PatientNumber()
        {
            dataStorage.PatientNumber();
        }
    }
}