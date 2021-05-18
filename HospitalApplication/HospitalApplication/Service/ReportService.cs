using HospitalApplication.Model;
using HospitalApplication.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApplication.Service
{
    public class ReportService
    {
        private List<ReportedDrugs> reports;

        public ReportService()
        {
            reports = FileReportedDrugs.LoadReports();
        }

        public void DeleteReport(ReportedDrugs forDelete)
        {
            for(int i=0; i<reports.Count; i++)
            {
                if (forDelete.IdReportedItem == reports[i].IdReportedItem)
                    reports.RemoveAt(i);
            }
            FileReportedDrugs.EnterReport(reports);
        }
        
        public void AddReport(ReportedDrugs newReport)
        {
            reports.Add(newReport);
            FileReportedDrugs.EnterReport(reports);
        }

        public List<ReportedDrugs> getAllReports()
        {
            return reports;
        }
    }
}
