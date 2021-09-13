using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorJournal
{
    public class JournalEntry
    {
        public DateTime Date { get; private set; }
        public string Doctor { get; private set; }
        public string DoctorJournalEntry { get; private set; }

        public JournalEntry()
        {

        }
        public JournalEntry(DateTime date, string doctor, string doctorJournalEntry)
        {
            Date = date;
            Doctor = doctor;
            DoctorJournalEntry = doctorJournalEntry;
        }
    }
}
