using HospitalApplication.Model;
using HospitalApplication.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Service
{
    public class Report
    {
        private List<ReportedDrugs> reports;

        public Report()
        {
            reports = ReportedDrugsFiles.LoadReports();
        }

        public void DeleteReport(ReportedDrugs forDelete)
        {
            for(int i=0; i<reports.Count; i++)
            {
                if (forDelete.IdReportedItem == reports[i].IdReportedItem)
                    reports.RemoveAt(i);
            }
            ReportedDrugsFiles.EnterReport(reports);
        }
        
        public void AddReport(ReportedDrugs newReport)
        {
            reports.Add(newReport);
            ReportedDrugsFiles.EnterReport(reports);
        }

        public List<ReportedDrugs> getAllReports()
        {
            return reports;
        }
    }
}
