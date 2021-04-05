using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model;
using Logic;

namespace HospitalApplication.WorkWithFiles
{
    class FilesDoctor
    {
        private string path = "doctors.txt";
        private ExaminationManagement m = ExaminationManagement.Instance;

        public List<Doctor> LoadFromFile()
        {
            List<Doctor> doctors = new List<Doctor>();
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] doctor = line.Split(",");
                //DateTime myDate = DateTime.ParseExact(pregled[3], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                //DateTime myDate = DateTime.Parse(examination[3]);
                List<DateTime> terms = new List<DateTime>();
                string[] term = doctor[2].Split("~");
                //ovaj and u foru je tu da ne bi pokusao da prazan string pretvori u date
                for(int i=0; i<term.Length && term[i] != ""; i++){
                    DateTime myDate = DateTime.Parse(term[i]);
                    terms.Add(myDate);
                }
                Doctor dr = new Doctor(doctor[0], doctor[1], terms);
                doctors.Add(dr);
            }
            return doctors;
        }

        public void WriteInFile(List<Doctor> doctors)
        {
            System.IO.File.WriteAllText(path, string.Empty);
            for (int i = 0; i < doctors.Count; i++)
            {
                File.AppendAllText(path, doctors[i].Username + "," + doctors[i].Password + ",");
                for (int j = 0; j < doctors[i].Scheduled.Count; j++) { 
                    File.AppendAllText(path, doctors[i].Scheduled[j] + "");
                    if (j < doctors[i].Scheduled.Count-1) {
                        File.AppendAllText(path, "~");
                    }
                }
                File.AppendAllText(path, "\n");
            }
        }
    }
}
