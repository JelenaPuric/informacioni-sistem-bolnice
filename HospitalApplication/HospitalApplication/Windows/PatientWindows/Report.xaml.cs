using HospitalApplication.Service;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkWithFiles;
using Paragraph = iTextSharp.text.Paragraph;

namespace HospitalApplication.Windows.PatientWindows
{
    public partial class Report : Window
    {
        private MainWindow mainWindow = MainWindow.Instance;
        private FileAppointments fileAppointments = FileAppointments.Instance;

        public Report()
        {
            InitializeComponent();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            DateTime firstDate = FirstDate.SelectedDate.Value.Date;
            DateTime secondDate = SecondDate.SelectedDate.Value.Date;
            List<Appointment> appointments = fileAppointments.GetAppointments(firstDate, secondDate, mainWindow.PatientsUsername);

            //--------------------------------------------

            Document pdfDoc = new Document(PageSize.A4  , 40f, 40f, 60f, 60f);
            //string path = "../../../Report/ZdravoReportPatient.pdf";
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Pdf Files|*.pdf";
            save.FileName = "ZdravoReport.pdf";
            save.ShowDialog();
            PdfWriter.GetInstance(pdfDoc, new FileStream(save.FileName, FileMode.OpenOrCreate));
            pdfDoc.Open();
            /*using (FileStream fs = new FileStream("../Windows/PatientWindows/Images/home.png", FileMode.Open)) { 
                var png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Png);
            }*/

            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bf, 32, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font tableFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            Paragraph par = new Paragraph("Appointments report", headerFont);
            par.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(par);
            Paragraph spacer = new Paragraph("") { SpacingBefore = 10f, SpacingAfter = 10f };
            pdfDoc.Add(spacer);
            pdfDoc.Add(spacer);

            PdfPTable table = new PdfPTable(new[] { .75f, 2f }){
                HorizontalAlignment = (int)Left,
                WidthPercentage = 75,
                DefaultCell = { MinimumHeight = 22f }
            };

            SetInfoTable(table, firstDate, secondDate);

            pdfDoc.Add(table);
            pdfDoc.Add(spacer);

            int realTableWidth = 4;

            PdfPTable realTable = new PdfPTable(realTableWidth)
            {
                HorizontalAlignment = (int)Left,
                WidthPercentage = 100,
                DefaultCell = { MinimumHeight = 22f },
            };

            PdfPCell cellId = new PdfPCell(new Phrase("ID"));
            PdfPCell cellDoctor = new PdfPCell(new Phrase("Doctor"));
            PdfPCell cellStartTime = new PdfPCell(new Phrase("Start time"));
            PdfPCell cellRoom = new PdfPCell(new Phrase("Room"));
            StyleCell(cellId, false);
            StyleCell(cellDoctor, false);
            StyleCell(cellStartTime, false);
            StyleCell(cellRoom, false);
            realTable.AddCell(cellId);
            realTable.AddCell(cellDoctor);
            realTable.AddCell(cellStartTime);
            realTable.AddCell(cellRoom);

            for (int i = 0; i < appointments.Count; i++) {
                bool isOdd = i % 2 == 1 ? true : false;
                PdfPCell cell1 = new PdfPCell(new Phrase(appointments[i].ExaminationId, tableFont));
                PdfPCell cell2 = new PdfPCell(new Phrase(appointments[i].DoctorsId, tableFont));
                PdfPCell cell3 = new PdfPCell(new Phrase(appointments[i].ExaminationStart.ToString(), tableFont));
                PdfPCell cell4 = new PdfPCell(new Phrase(appointments[i].RoomId, tableFont));
                StyleCell(cell1, isOdd);
                StyleCell(cell2, isOdd);
                StyleCell(cell3, isOdd);
                StyleCell(cell4, isOdd);
                realTable.AddCell(cell1);
                realTable.AddCell(cell2);
                realTable.AddCell(cell3);
                realTable.AddCell(cell4);
            }

            pdfDoc.Add(realTable);


            pdfDoc.Close();

            //--------------------------------------------

            /*SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Pdf Files|*.pdf";
            save.FileName = "ZdravoReport.pdf";
            bool ok = true;
            if (save.ShowDialog() == true) {
                if (File.Exists(save.FileName)) {
                    try{
                        File.Delete(save.FileName);
                    }
                    catch(Exception ex) {
                        ok = false;
                        MessageBox.Show("Unable to write data. " + ex.Message);
                    }
                }
                if (ok) {
                    try {
                        PdfPTable ptable = new PdfPTable(appointments.Count);
                        ptable.DefaultCell.Padding = 2;
                        ptable.WidthPercentage = 100;
                        ptable.HorizontalAlignment = Element.ALIGN_LEFT;
                        for (int i = 0; i < 1; i++)
                        {
                            PdfPCell pcell = new PdfPCell(new Phrase("vreme"));
                            ptable.AddCell(pcell);
                        }
                        for (int i = 0; i < appointments.Count; i++) {
                            ptable.AddCell(appointments[i].DoctorsId);
                        }
                        using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                        {
                            Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                            document.Open();
                            document.Add(ptable);
                            document.Close();
                            fileStream.Close();
                        }
                        MessageBox.Show("Report made successfully.");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Error in exporting data to pdf. " + ex.Message);
                    }
                }
            }*/
            //--------------------------------
        }

        private void StyleCell(PdfPCell cell, bool isOdd) {
            cell.BorderWidth = 1;
            //cell.BorderColor = new iTextSharp.text.BaseColor(1, 69, 70);
            if(isOdd) cell.BackgroundColor = new iTextSharp.text.BaseColor(231, 231, 231);
        }

        private void SetInfoTable(PdfPTable table, DateTime firstDate, DateTime secondDate) {
            PdfPCell cell1 = new PdfPCell(new Phrase("Date of document creation"));
            PdfPCell cell2 = new PdfPCell(new Phrase(DateTime.Now.ToString()));
            PdfPCell cell3 = new PdfPCell(new Phrase("Patient"));
            PdfPCell cell4 = new PdfPCell(new Phrase(mainWindow.PatientsUsername));
            PdfPCell cell5 = new PdfPCell(new Phrase("From"));
            PdfPCell cell6 = new PdfPCell(new Phrase(firstDate.ToString()));
            PdfPCell cell7 = new PdfPCell(new Phrase("To"));
            PdfPCell cell8 = new PdfPCell(new Phrase(secondDate.ToString()));
            StyleCell(cell1, false);
            StyleCell(cell2, false);
            StyleCell(cell3, false);
            StyleCell(cell4, false);
            StyleCell(cell5, false);
            StyleCell(cell6, false);
            StyleCell(cell7, false);
            StyleCell(cell8, false);
            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);
            table.AddCell(cell5);
            table.AddCell(cell6);
            table.AddCell(cell7);
            table.AddCell(cell8);
        }
    }
}