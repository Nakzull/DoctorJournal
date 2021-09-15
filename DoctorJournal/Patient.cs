using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorJournal
{
    public class Patient
    {
        public string Name { get; private set; }
        public string Adress { get; private set; }
        public int PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string CPRNumber { get; private set; }
        public string PreferredDoctor { get; private set; }
        public int AgeYear { get; private set; }
        public int AgeDay { get; private set; }

        public List<JournalEntry> JournalEntry = new List<JournalEntry>();

        public Patient()
        {

        }
        public Patient(string name, string adress, int phoneNumber, string email, string cprNumber, string preferredDoctor, int ageYear, int ageDay, List<JournalEntry> journalEntry)
        {
            Name = name;
            Adress = adress;
            PhoneNumber = phoneNumber;
            Email = email;
            CPRNumber = cprNumber;
            PreferredDoctor = preferredDoctor;
            AgeYear = ageYear;
            AgeDay = ageDay;
            JournalEntry = journalEntry;
        }
    }
}

