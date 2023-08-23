using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Windows.Media;
using System.Windows;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace budget_management_app
{
    public partial class StatisticsForm : Form
    {
        private ExpensesTabLogic expensesTabLogic;
        private MoneyFlowTabLogic moneyFlowTabLogic;
        private ReportsTabLogic reportsFlowTabLogic;

        private DBConnection dbcon = new DBConnection();
        private bool bottombarExpand;
        private int selectedAccId;
        private DateTime currentDate = DateTime.Today;
        private int selectedDay;
        private int selectedMonth;
        private int selectedYear;

        private decimal expTotalAmount;
        private decimal currentExpTotalAmount;
        private decimal inTotalAmount;
        private decimal currentInTotalAmount;
        private decimal max_amount = 0;
        private int animationDuration = 40;

        private string expensesTooltip = "";

        public StatisticsForm()
        {
            InitializeComponent();
            expensesTabLogic = new ExpensesTabLogic();
            moneyFlowTabLogic = new MoneyFlowTabLogic();
            reportsFlowTabLogic=new ReportsTabLogic();

            menuTabControl.SelectedIndex = 1;

            getAcc();
            comboBox_account.SelectedIndex = 0;
            getSelectedAcc();

            DateTime startDateTime = currentDate.AddMonths(-2);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            UpdateSelectedDate(1, startMonth, startYear);

            DataGridView_7High_exp.Columns[1].Width = 100;
            DataGridView_7High_exp.Columns[2].Width = 90;
        }

        private void UpdateSelectedDate(int startDay, int startMonth, int startYear)
        {

            selectedDay = startDay;
            selectedMonth = startMonth;
            selectedYear = startYear;

            if (selectedMonth < 1)
            {
                selectedMonth += 12;
                selectedYear--;
            }
            else if (selectedMonth > 12)
            {
                selectedMonth -= 12;
                selectedYear++;
            }

            int daysInSelectedMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
            if (selectedDay > daysInSelectedMonth)
            {
                selectedDay = daysInSelectedMonth;
            }

            label_exp_from_date.Text = selectedDay.ToString() + "." + selectedMonth.ToString() + "." + selectedYear.ToString();
            UpdateCharts();
        }
        private void UpdateCharts()
        {
            expensesTabLogic.getPieChart(selectedAccId,selectedYear,selectedMonth,selectedDay,chart_exp_cat);
            expensesTabLogic.getHighestExpensees(selectedAccId, selectedYear, selectedMonth, selectedDay,DataGridView_7High_exp);

            DateTime selectedDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            DateTime currentDate = DateTime.Today;
            int daysDifference = (currentDate - selectedDate).Days;

            if (daysDifference > 123)
            {
                expensesTabLogic.getColumnChart_Month(selectedAccId, selectedYear, selectedMonth, selectedDay,chart_exp_column);
                moneyFlowTabLogic.getCartesianChart_Month(selectedAccId,selectedYear,selectedMonth,selectedDay,cartesianChart1);
            }
            else if (daysDifference > 31 && daysDifference <= 123)
            {
                expensesTabLogic.getColumnChart_Week(selectedAccId, selectedYear, selectedMonth, selectedDay, chart_exp_column);
                moneyFlowTabLogic.getCartesianChart_Week(selectedAccId, selectedYear, selectedMonth, selectedDay, cartesianChart1);
            }
            else
            {
                expensesTabLogic.getColumnChart_Day(selectedAccId, selectedYear, selectedMonth, selectedDay, chart_exp_column);
                moneyFlowTabLogic.getCartesianChart_Day(selectedAccId, selectedYear, selectedMonth, selectedDay, cartesianChart1);
            }

            moneyFlowTabLogic.getMoneyFlowChart(selectedAccId, selectedYear, selectedMonth, selectedDay,chart_exp_mf,chart_in_mf,label_amount_diff_mf,label_exp_amount_mf,label_in_amount_mf);
            reportsFlowTabLogic.getRaportMf(selectedAccId, selectedYear, selectedMonth, selectedDay, DataGridView_raport_mf, label_raport_mf);
            label_raport_ledger.Text = label_raport_mf.Text;
            reportsFlowTabLogic.getRaportExp(selectedAccId, selectedYear, selectedMonth, selectedDay,DataGridView_raport_exp, label_raport_total_exp);
            reportsFlowTabLogic.getRaportIn(selectedAccId, selectedYear, selectedMonth, selectedDay, DataGridView_raport_in, label_raport_total_in);
        }

        private void button_7D_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddDays(-6);
            int startDay = startDateTime.Day;
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 7 DAYS";
            label_last_X_cf.Text = "LAST 7 DAYS";
            label_last_X_mf.Text = "LAST 7 DAYS";
            label_last_X_raport_mf.Text = "LAST 7 DAYS";
            label_last_X_raport_ledger.Text = "LAST 7 DAYS";
            UpdateSelectedDate(startDay, startMonth, startYear);
            expensesTabLogic.getColumnChart_Day(selectedAccId, selectedYear, selectedMonth, selectedDay, chart_exp_column);
        }

        private void button_30D_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddDays(-30);
            int startDay = startDateTime.Day;
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 30 DAYS";
            label_last_X_cf.Text = "LAST 30 DAYS";
            label_last_X_mf.Text = "LAST 30 DAYS";
            label_last_X_raport_mf.Text = "LAST 30 DAYS";
            label_last_X_raport_ledger.Text = "LAST 30 DAYS";
            UpdateSelectedDate(startDay, startMonth, startYear);
            expensesTabLogic.getColumnChart_Day(selectedAccId, selectedYear, selectedMonth, selectedDay, chart_exp_column);

        }
        private void button_12W_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddMonths(-2);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 3 MONTH";
            label_last_X_cf.Text = "LAST 3 MONTH";
            label_last_X_mf.Text = "LAST 3 MONTH";
            label_last_X_raport_mf.Text = "LAST 3 MONTH";
            label_last_X_raport_ledger.Text = "LAST 3 MONTH";
            UpdateSelectedDate(1, startMonth, startYear);
            expensesTabLogic.getColumnChart_Week(selectedAccId, selectedYear, selectedMonth, selectedDay, chart_exp_column);
        }

        private void button_6M_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddMonths(-5);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            label_exp_last_X.Text = "LAST 6 MONTH";
            label_last_X_cf.Text = "LAST 6 MONTH";
            label_last_X_mf.Text = "LAST 6 MONTH";
            label_last_X_raport_mf.Text = "LAST 6 MONTH";
            label_last_X_raport_ledger.Text = "LAST 6 MONTH";
            UpdateSelectedDate(1, startMonth, startYear);
            expensesTabLogic.getColumnChart_Month(selectedAccId, selectedYear, selectedMonth, selectedDay, chart_exp_column);
        }

        private void button_1Y_Click(object sender, EventArgs e)
        {
            label_exp_last_X.Text = "LAST 12 MONTH";
            label_last_X_cf.Text = "LAST 12 MONTH";
            label_last_X_mf.Text = "LAST 12 MONTH";
            label_last_X_raport_mf.Text = "LAST 12 MONTH";
            label_last_X_raport_ledger.Text = "LAST 12 MONTH";
            UpdateSelectedDate(1, 1, currentDate.Year);
            expensesTabLogic.getColumnChart_Month(selectedAccId, selectedYear, selectedMonth, selectedDay, chart_exp_column);
        }

        private void buttonBarUp_Click(object sender, EventArgs e)
        {
            timer_bottomBar.Start();
            buttonBarUp.Visible = false;
            buttonBarDown.Visible = true;
        }

        private void buttonBarDown_Click(object sender, EventArgs e)
        {
            timer_bottomBar.Start();
            buttonBarUp.Visible = true;
            buttonBarDown.Visible = false;
        }
        private void timer_bottomBar_Tick(object sender, EventArgs e)
        {
            if (bottombarExpand)
            {
                panel_bottomBar.Location = new System.Drawing.Point(panel_bottomBar.Location.X, panel_bottomBar.Location.Y + 10);
                panel_bottomBar.Height -= 10;
                if (panel_bottomBar.Height == panel_bottomBar.MinimumSize.Height)
                {
                    bottombarExpand = false;
                    timer_bottomBar.Stop();
                }
            }
            else
            {
                panel_bottomBar.Width = 580;
                panel_bottomBar.Location = new System.Drawing.Point(panel_bottomBar.Location.X, panel_bottomBar.Location.Y - 10);
                panel_bottomBar.Height += 10;
                if (panel_bottomBar.Height == panel_bottomBar.MaximumSize.Height)
                {
                    bottombarExpand = true;
                    timer_bottomBar.Stop();
                }
            }
        }

        // Retrieving data on existing accounts for combo_box_account
        private void getAcc()
        {
            string selectQuery = "SELECT AccName FROM Account WHERE UserId = " + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                comboBox_account.Items.Add(data.Trim());
            }
            reader.Close();
            dbcon.CloseCon();
        }

        private void getSelectedAcc()
        {
            string selectQuery = "SELECT AccId FROM Account WHERE AccName ='" + comboBox_account.SelectedItem.ToString() + "' AND UserId=" + LoginForm.userId;
            SqlCommand comm = new SqlCommand(selectQuery, dbcon.GetCon());
            dbcon.OpenCon();
            object result = comm.ExecuteScalar();
            if (result != null)
            {
                selectedAccId = Convert.ToInt32(result);
            }
            dbcon.CloseCon();
        }

        private void comboBox_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_account.SelectedItem != null)
            {
                getSelectedAcc();
                DateTime startDateTime = currentDate.AddMonths(-2);
                int startMonth = startDateTime.Month;
                int startYear = startDateTime.Year;
                UpdateSelectedDate(1, startMonth, startYear);
            }
        }

        private void chart_exp_column_MouseMove(object sender, MouseEventArgs e)
        {
            var chart = (System.Windows.Forms.DataVisualization.Charting.Chart)sender;

            var hitTestResult = chart.HitTest(e.X, e.Y);

            if (hitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int pointIndex = hitTestResult.PointIndex;

                expensesTooltip = chart.Series["Expenses"].Points[pointIndex].GetCustomProperty("Tooltip");
            }
            else
            {
                expensesTooltip = "";
            }
            chart.Series["Expenses"].ToolTip = expensesTooltip;
            chart.Series["Default"].ToolTip = expensesTooltip;
        }

        private void printMf()
        {
            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "Report.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        PdfWriter.GetInstance(doc, stream);
                        doc.Open();

                        int x = 50;
                        int y = 50;
                        int lineHeight = 20;

                        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(128, 128, 128));
                        iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD, new BaseColor(128, 128, 128));
                        iTextSharp.text.Font incomeFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font expensesFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(255, 0, 0));

                        iTextSharp.text.Paragraph titleParagraph = new iTextSharp.text.Paragraph("Money flow table", boldFont);
                        doc.Add(titleParagraph);

                        y += 5 * lineHeight;

                        iTextSharp.text.Paragraph last_X_DaysParagraph = new iTextSharp.text.Paragraph(label_last_X_raport_mf.Text, font);
                        last_X_DaysParagraph.SpacingAfter = 20;
                        doc.Add(last_X_DaysParagraph);

                        PdfPTable table = new PdfPTable(3);
                        BaseColor smokeWhite = new BaseColor(245, 245, 245);

                        table.AddCell(new PdfPCell(new Phrase("Quick view", titleFont)) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT ,
                            FixedHeight = 20,
                        });
                        table.AddCell(new PdfPCell(new Phrase("Income", font)) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT ,
                            FixedHeight = 20,
                        });
                        table.AddCell(new PdfPCell(new Phrase("Expenses", expensesFont)) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT ,
                            FixedHeight = 20,
                        });

                        foreach (DataGridViewRow row in DataGridView_raport_mf.Rows)
                        {
                            string column1Value= row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string incomeValue = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0";
                            string expValue = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "0";

                            BaseColor color;
                            if (table.Rows.Count % 2 == 1) { color = smokeWhite; }
                            else { color = BaseColor.WHITE; }

                            table.AddCell(new PdfPCell(new Phrase(column1Value, font)) 
                            { 
                                BackgroundColor = color, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT ,
                                FixedHeight = 20,
                            });
                            table.AddCell(new PdfPCell(new Phrase(incomeValue, incomeFont))
                            { 
                                BackgroundColor = color, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT ,
                                FixedHeight = 20,
                            });
                            table.AddCell(new PdfPCell(new Phrase(expValue, expensesFont)) 
                            { 
                                BackgroundColor = color, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                FixedHeight=20,
                            });
                        }

                        table.SpacingBefore = 10;
                        table.SpacingAfter = 10;
                        table.HorizontalAlignment = Element.ALIGN_LEFT;

                        float[] columnWidths = { 0.35f, 0.5f, 0.5f };
                        table.SetWidths(columnWidths);
                        doc.Add(table);

                        iTextSharp.text.Paragraph flowParagraph = new iTextSharp.text.Paragraph("Money flow : "+label_raport_mf.Text, new iTextSharp.text.Font(baseFont, 13, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                        flowParagraph.Alignment = Element.ALIGN_LEFT;
                        doc.Add(flowParagraph);

                        doc.Close();
                        System.Windows.Forms.MessageBox.Show("Successful download of the report ", "Download Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("An error occurred while creating the PDF file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void printLedger()
        {
            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "Report_Ledger.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        PdfWriter.GetInstance(doc, stream);

                        doc.Open();

                        int x = 50;
                        int y = 50;
                        int lineHeight = 20;
                        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
                        paragraph.Font = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                        Chunk textChunk = new Chunk("Revenue and expense ledger");
                        paragraph.Add(textChunk);
                        doc.Add(paragraph);

                        y += 5 * lineHeight;
                        iTextSharp.text.Paragraph last_X_DaysParagraph = new iTextSharp.text.Paragraph(label_last_X_raport_ledger.Text, new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(128, 128, 128)));
                        doc.Add(last_X_DaysParagraph);
                        iTextSharp.text.Paragraph totalAmountParagraph = new iTextSharp.text.Paragraph(label_raport_ledger.Text, new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                        totalAmountParagraph.SpacingAfter = 20;
                        doc.Add(totalAmountParagraph);

                        PdfPTable table = new PdfPTable(2);

                        BaseColor smokeWhite = new BaseColor(245, 245, 245);

                        table.AddCell(new PdfPCell(new Phrase("Income", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_LEFT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5,
                            FixedHeight = 28,
                        });
                        table.AddCell(new PdfPCell(new Phrase(label_raport_total_in.Text, new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5 
                        });
                        
                        foreach(DataGridViewRow row in DataGridView_raport_in.Rows)
                        {
                            string name = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string amount = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0.00";
                            
                            int fontSize = 13;
                            bool left = true;
                            BaseColor fontColor = BaseColor.BLACK;
                            if (name.Contains("  "))
                            {
                                fontSize = 11;
                                fontColor = new BaseColor(128, 128, 128);
                                left = false;
                            }

                            table.AddCell(new PdfPCell(new Phrase(name, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL,fontColor))) 
                            { 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_LEFT, 
                                PaddingTop = 5,
                            });
                            table.AddCell(new PdfPCell(new Phrase(amount, new iTextSharp.text.Font(baseFont, fontSize-1, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                            { 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = (left == true)?Element.ALIGN_LEFT:Element.ALIGN_RIGHT, 
                                PaddingTop = 5,
                            });
                        }

                        table.AddCell(new PdfPCell(new Phrase("Expenses", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_LEFT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5,
                            FixedHeight=28,
                        });
                        table.AddCell(new PdfPCell(new Phrase(label_raport_total_exp.Text, new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5 
                        });

                        foreach (DataGridViewRow row in DataGridView_raport_exp.Rows)
                        {
                            string name = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string amount = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0";

                            int fontSize = 13;
                            bool left = true;
                            BaseColor fontColor = BaseColor.BLACK;
                            if (name.Contains("  "))
                            {
                                fontSize = 11;
                                fontColor = new BaseColor(128, 128, 128);
                                left = false;
                            }

                            table.AddCell(new PdfPCell(new Phrase(name, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL, fontColor)))
                            {
                                Border = iTextSharp.text.Rectangle.NO_BORDER,
                                HorizontalAlignment = Element.ALIGN_LEFT,
                                PaddingTop = 5,
                            });
                            table.AddCell(new PdfPCell(new Phrase(amount, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)))
                            {
                                Border = iTextSharp.text.Rectangle.NO_BORDER,
                                HorizontalAlignment = (left == true) ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT,
                                PaddingTop = 5,
                            });
                        }

                        table.SpacingBefore = 10;
                        table.SpacingAfter = 10;
                        table.HorizontalAlignment = Element.ALIGN_LEFT;
                        
                        float[] columnWidths = { 1.8f, 0.8f};
                        table.SetWidths(columnWidths);
                        doc.Add(table);

                        doc.Close();
                        System.Windows.Forms.MessageBox.Show("Successful download of the report ", "Download Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("An error occurred while creating the PDF file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            HomeForm home = new HomeForm();
            home.Show();
            this.Hide();
        }
        private void Button_more_trns_Click(object sender, EventArgs e)
        {
            TransactionsHistoryForm trns = new TransactionsHistoryForm();
            trns.Show();
            this.Hide();
        }

        private void Button_more_trns_exp_Click(object sender, EventArgs e)
        {
            TransactionsHistoryForm transactionsHistoryForm = new TransactionsHistoryForm();
            transactionsHistoryForm.Show();
            this.Hide();
        }
        private void button_print_raport_mf_Click(object sender, EventArgs e)
        {
            printMf();
        }

        private void button_print_raport_ledger_Click_1(object sender, EventArgs e)
        {
            printLedger();
        }

    }
}


