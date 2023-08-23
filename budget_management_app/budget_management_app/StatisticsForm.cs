using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace budget_management_app
{
    public partial class StatisticsForm : Form
    {
        // Declare instance variables for logic and components
        private ExpensesTabLogic expensesTabLogic;
        private MoneyFlowTabLogic moneyFlowTabLogic;
        private ReportsTabLogic reportsFlowTabLogic;

        private DBConnection dbConnection = new DBConnection();
        private bool bottomBarExpand;
        private int selectedAccountId;
        private DateTime currentDate = DateTime.Today;
        private int selectedDay;
        private int selectedMonth;
        private int selectedYear;

        private string expensesTooltip = "";

        public StatisticsForm()
        {
            InitializeComponent();
            InitializeLogic();
            InitializeSelectedDate();

            // Set default tab and load accounts
            menuTabControl.SelectedIndex = 1;
            LoadAccounts();
            comboBoxAccount.SelectedIndex = 0;
            LoadSelectedAccount();

            // Set column widths and initial bottom bar state
            DataGridViewHighestExpenses.Columns[1].Width = 100;
            DataGridViewHighestExpenses.Columns[2].Width = 90;
            bottomBarPanel.Height = bottomBarPanel.MinimumSize.Height;
            bottomBarExpand = false;
        }

        // Initialization methods
        private void InitializeLogic()
        {
            expensesTabLogic = new ExpensesTabLogic();
            moneyFlowTabLogic = new MoneyFlowTabLogic();
            reportsFlowTabLogic = new ReportsTabLogic();
        }

        private void InitializeSelectedDate()
        {
            DateTime startDateTime = currentDate.AddMonths(-2);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;
            UpdateSelectedDate(1, startMonth, startYear);
        }

        // Update selected date and ensure its validity
        private void UpdateSelectedDate(int startDay, int startMonth, int startYear)
        {
            // Adjust month and year if they go out of range
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

            // Ensure day is within the selected month's range
            int daysInSelectedMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
            if (selectedDay > daysInSelectedMonth)
            {
                selectedDay = daysInSelectedMonth;
            }

            // Update labels and charts
            startDateColumnChartLabel.Text = selectedDay.ToString() + "." + selectedMonth.ToString() + "." + selectedYear.ToString();
            UpdateCharts();
        }

        // Update charts based on selected date
        private void UpdateCharts()
        {
            // Update pie chart and highest expenses data
            expensesTabLogic.GeneratePieChart(selectedAccountId, selectedYear,selectedMonth,selectedDay,expensesPieChart);
            expensesTabLogic.GenerateHighestExpenses(selectedAccountId, selectedYear, selectedMonth, selectedDay,DataGridViewHighestExpenses);

            // Calculate days difference between current and selected dates
            DateTime selectedDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            DateTime currentDate = DateTime.Today;
            int daysDifference = (currentDate - selectedDate).Days;

            // Choose appropriate chart based on days difference
            if (daysDifference > 123)
            {
                expensesTabLogic.GenerateColumnChartMonth(selectedAccountId, selectedYear, selectedMonth, selectedDay,expensesColumnChart);
                moneyFlowTabLogic.getCartesianChart_Month(selectedAccountId, selectedYear,selectedMonth,selectedDay,cashFlowCartesianChart);
            }
            else if (daysDifference > 31 && daysDifference <= 123)
            {
                expensesTabLogic.GenerateColumnChartWeek(selectedAccountId, selectedYear, selectedMonth, selectedDay, expensesColumnChart);
                moneyFlowTabLogic.getCartesianChart_Week(selectedAccountId, selectedYear, selectedMonth, selectedDay, cashFlowCartesianChart);
            }
            else
            {
                expensesTabLogic.GenerateColumnChartDay(selectedAccountId, selectedYear, selectedMonth, selectedDay, expensesColumnChart);
                moneyFlowTabLogic.getCartesianChart_Day(selectedAccountId, selectedYear, selectedMonth, selectedDay, cashFlowCartesianChart);
            }

            // Update money flow charts and reports
            moneyFlowTabLogic.getMoneyFlowChart(selectedAccountId, selectedYear, selectedMonth, selectedDay,moneyFlowExpensesChart,moneyFlowIncomeChart,amountDiffrenceLabel,amountExpensesLabel,amountIncomeLabel);
            reportsFlowTabLogic.GenerateMoneyFlowReport(selectedAccountId, selectedYear, selectedMonth, selectedDay, DataGridView_raport_mf, amountDifferenceMFReportLabel);
            amountDifferenceLedgerReportLabel.Text = amountDifferenceMFReportLabel.Text;
            reportsFlowTabLogic.GenerateExpensesReport(selectedAccountId, selectedYear, selectedMonth, selectedDay,DataGridView_raport_exp, amountExpensesLedgerLabel);
            reportsFlowTabLogic.GenerateIncomeReport(selectedAccountId, selectedYear, selectedMonth, selectedDay, DataGridView_raport_in, amountIncomeLedgerLabel);
        }

        // Event handlers for time interval buttons
        private void oneWeekButton_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddDays(-6);
            int startDay = startDateTime.Day;
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;

            // Update labels and selected date
            startDatePieChartLabel.Text = "LAST 7 DAYS";
            startDateCashFlowLabel.Text = "LAST 7 DAYS";
            startDateMoneyFlowLabel.Text = "LAST 7 DAYS";
            startDateMFReportLabel.Text = "LAST 7 DAYS";
            startDateLedgerLabel.Text = "LAST 7 DAYS";
            UpdateSelectedDate(startDay, startMonth, startYear);

            // Update the expenses column chart
            expensesTabLogic.GenerateColumnChartDay(selectedAccountId, selectedYear, selectedMonth, selectedDay, expensesColumnChart);
        }

        private void oneMonthButton_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddDays(-30);
            int startDay = startDateTime.Day;
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;

            // Update labels and selected date
            startDatePieChartLabel.Text = "LAST 30 DAYS";
            startDateCashFlowLabel.Text = "LAST 30 DAYS";
            startDateMoneyFlowLabel.Text = "LAST 30 DAYS";
            startDateMFReportLabel.Text = "LAST 30 DAYS";
            startDateLedgerLabel.Text = "LAST 30 DAYS";
            UpdateSelectedDate(startDay, startMonth, startYear);

            // Update the expenses column chart
            expensesTabLogic.GenerateColumnChartDay(selectedAccountId, selectedYear, selectedMonth, selectedDay, expensesColumnChart);
        }

        private void twelveWeeksButton_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddMonths(-2);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;

            // Update labels and selected date
            startDatePieChartLabel.Text = "LAST 3 MONTH";
            startDateCashFlowLabel.Text = "LAST 3 MONTH";
            startDateMoneyFlowLabel.Text = "LAST 3 MONTH";
            startDateMFReportLabel.Text = "LAST 3 MONTH";
            startDateLedgerLabel.Text = "LAST 3 MONTH";
            UpdateSelectedDate(1, startMonth, startYear);

            // Update the expenses column chart
            expensesTabLogic.GenerateColumnChartWeek(selectedAccountId, selectedYear, selectedMonth, selectedDay, expensesColumnChart);
        }

        private void halfYearButton_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = currentDate.AddMonths(-5);
            int startMonth = startDateTime.Month;
            int startYear = startDateTime.Year;

            // Update labels and selected date
            startDatePieChartLabel.Text = "LAST 6 MONTH";
            startDateCashFlowLabel.Text = "LAST 6 MONTH";
            startDateMoneyFlowLabel.Text = "LAST 6 MONTH";
            startDateMFReportLabel.Text = "LAST 6 MONTH";
            startDateLedgerLabel.Text = "LAST 6 MONTH";
            UpdateSelectedDate(1, startMonth, startYear);

            // Update the expenses column chart
            expensesTabLogic.GenerateColumnChartMonth(selectedAccountId, selectedYear, selectedMonth, selectedDay, expensesColumnChart);
        }

        private void oneYearButton_Click(object sender, EventArgs e)
        {
            // Update labels and selected date
            startDatePieChartLabel.Text = "LAST 12 MONTH";
            startDateCashFlowLabel.Text = "LAST 12 MONTH";
            startDateMoneyFlowLabel.Text = "LAST 12 MONTH";
            startDateMFReportLabel.Text = "LAST 12 MONTH";
            startDateLedgerLabel.Text = "LAST 12 MONTH";
            UpdateSelectedDate(1, 1, currentDate.Year);

            // Update the expenses column chart
            expensesTabLogic.GenerateColumnChartMonth(selectedAccountId, selectedYear, selectedMonth, selectedDay, expensesColumnChart);
        }

        // Button to expand the bottom bar
        private void buttonBarUp_Click(object sender, EventArgs e)
        {
            bottomBarTimer.Start();
            buttonBarUp.Visible = false;
            buttonBarDown.Visible = true;
        }

        private void buttonBarDown_Click(object sender, EventArgs e)
        {
            bottomBarTimer.Start();
            buttonBarUp.Visible = true;
            buttonBarDown.Visible = false;
        }
        private void bottomBarTimer_Tick(object sender, EventArgs e)
        {
            if (bottomBarExpand)
            {
                bottomBarPanel.Location = new System.Drawing.Point(bottomBarPanel.Location.X, bottomBarPanel.Location.Y + 10);
                bottomBarPanel.Height -= 10;
                if (bottomBarPanel.Height == bottomBarPanel.MinimumSize.Height)
                {
                    bottomBarExpand = false;
                    bottomBarTimer.Stop();
                }
            }
            else
            {
                bottomBarPanel.Width = 580;
                bottomBarPanel.Location = new System.Drawing.Point(bottomBarPanel.Location.X, bottomBarPanel.Location.Y - 10);
                bottomBarPanel.Height += 10;
                if (bottomBarPanel.Height == bottomBarPanel.MaximumSize.Height)
                {
                    bottomBarExpand = true;
                    bottomBarTimer.Stop();
                }
            }
        }

        // Load user accounts from the database
        private void LoadAccounts()
        {
            string selectQuery = "SELECT AccName FROM Account WHERE UserId = " + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon());
            dbConnection.OpenCon();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string data = reader.GetString(0);
                comboBoxAccount.Items.Add(data.Trim());
            }
            reader.Close();
            dbConnection.CloseCon();
        }

        // Load selected account's ID
        private void LoadSelectedAccount()
        {
            string selectQuery = "SELECT AccId FROM Account WHERE AccName ='" + comboBoxAccount.SelectedItem.ToString() + "' AND UserId=" + LoginForm.userId;
            SqlCommand command = new SqlCommand(selectQuery, dbConnection.GetCon());
            dbConnection.OpenCon();
            object result = command.ExecuteScalar();
            if (result != null)
            {
                selectedAccountId = Convert.ToInt32(result);
            }
            dbConnection.CloseCon();
        }

        // Event handler when account selection changes
        private void comboBoxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAccount.SelectedItem != null)
            {
                LoadSelectedAccount();
                DateTime startDateTime = currentDate.AddMonths(-2);
                int startMonth = startDateTime.Month;
                int startYear = startDateTime.Year;
                UpdateSelectedDate(1, startMonth, startYear);
            }
        }

        // Event handler for chart mouse move to show tooltips
        private void expensesColumnChart_MouseMove(object sender, MouseEventArgs e)
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

        // Method to print the Money Flow report as a PDF
        private void PrintMoneyFlowReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);

            // Create a SaveFileDialog to allow the user to choose the save location
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "Report.pdf";

            // Show the SaveFileDialog and proceed if the user selects a location
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a FileStream to write the PDF content
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        // Initialize PDF writer and open the document
                        PdfWriter.GetInstance(document, stream);
                        document.Open();

                        // Set up positions and fonts for content rendering
                        int x = 50;
                        int y = 50;
                        int lineHeight = 20;

                        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                        
                        // Create various font styles for different parts of the document
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(128, 128, 128));
                        iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD, new BaseColor(128, 128, 128));
                        iTextSharp.text.Font incomeFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font expensesFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(255, 0, 0));

                        // Add a title to the document
                        iTextSharp.text.Paragraph titleParagraph = new iTextSharp.text.Paragraph("Money flow table", boldFont);
                        document.Add(titleParagraph);

                        y += 5 * lineHeight;

                        // Add time interval label and selected date information
                        iTextSharp.text.Paragraph timeIntervalParagraph = new iTextSharp.text.Paragraph(startDateMFReportLabel.Text, font);
                        timeIntervalParagraph.SpacingAfter = 20;
                        document.Add(timeIntervalParagraph);

                        // Create a table for displaying quick view, income, and expenses
                        PdfPTable table = new PdfPTable(3);
                        BaseColor smokeWhite = new BaseColor(245, 245, 245);

                        // Add headers to the table
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

                        // Iterate through DataGridView rows and add data to the table
                        foreach (DataGridViewRow row in DataGridView_raport_mf.Rows)
                        {
                            string column1Value= row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string incomeValue = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0";
                            string expValue = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "0";

                            // Alternate row background colors for better readability
                            BaseColor baseColor;
                            if (table.Rows.Count % 2 == 1) { baseColor = smokeWhite; }
                            else { baseColor = BaseColor.WHITE; }

                            // Add cell content to the table
                            table.AddCell(new PdfPCell(new Phrase(column1Value, font)) 
                            { 
                                BackgroundColor = baseColor, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT ,
                                FixedHeight = 20,
                            });
                            table.AddCell(new PdfPCell(new Phrase(incomeValue, incomeFont))
                            { 
                                BackgroundColor = baseColor, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT ,
                                FixedHeight = 20,
                            });
                            table.AddCell(new PdfPCell(new Phrase(expValue, expensesFont)) 
                            { 
                                BackgroundColor = baseColor, 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = Element.ALIGN_RIGHT,
                                FixedHeight=20,
                            });
                        }

                        // Customize the table appearance and add it to the document
                        table.SpacingBefore = 10;
                        table.SpacingAfter = 10;
                        table.HorizontalAlignment = Element.ALIGN_LEFT;

                        float[] columnWidths = { 0.35f, 0.5f, 0.5f };
                        table.SetWidths(columnWidths);
                        document.Add(table);

                        // Add a paragraph displaying money flow amount difference and close the document
                        iTextSharp.text.Paragraph amountDiffParagraph = new iTextSharp.text.Paragraph("Money flow : "+amountDifferenceMFReportLabel.Text, new iTextSharp.text.Font(baseFont, 13, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                        amountDiffParagraph.Alignment = Element.ALIGN_LEFT;
                        document.Add(amountDiffParagraph);

                        document.Close();
                        System.Windows.Forms.MessageBox.Show("Successful download of the report ", "Download Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("An error occurred while creating the PDF file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Method to print the Ledger report as a PDF
        private void PrintLedgerReport()
        {
            // Create a new PDF document
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);

            // Create a SaveFileDialog to allow the user to choose the save location
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "Report_Ledger.pdf";

            // Show the SaveFileDialog and proceed if the user selects a location
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a FileStream to write the PDF content
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        // Initialize PDF writer and open the document
                        PdfWriter.GetInstance(document, stream);
                        document.Open();

                        // Set up positions and fonts for content rendering
                        int x = 50;
                        int y = 50;
                        int lineHeight = 20;

                        // Set up fonts and styles
                        BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font subHeaderFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, new BaseColor(128, 128, 128));
                        iTextSharp.text.Font amountFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        // Add title to the document
                        iTextSharp.text.Paragraph titleParagraph = new iTextSharp.text.Paragraph();
                        titleParagraph.Font = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        y += 5 * lineHeight;

                        // Add date and total amount information
                        iTextSharp.text.Paragraph timeIntervalParagraph = new iTextSharp.text.Paragraph(startDateLedgerLabel.Text, subHeaderFont);
                        iTextSharp.text.Paragraph totalAmountParagraph = new iTextSharp.text.Paragraph(amountDifferenceLedgerReportLabel.Text, amountFont);
                        totalAmountParagraph.SpacingAfter = 20;
                        document.Add(timeIntervalParagraph);
                        document.Add(totalAmountParagraph);

                        // Create and format the table
                        PdfPTable table = new PdfPTable(2);
                        BaseColor smokeWhite = new BaseColor(245, 245, 245);

                        // Add headers for income section
                        table.AddCell(new PdfPCell(new Phrase("Income", headerFont)) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_LEFT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5,
                            FixedHeight = 28,
                        });
                        table.AddCell(new PdfPCell(new Phrase(amountIncomeLedgerLabel.Text, headerFont)) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5 
                        });

                        // Iterate through income rows and add data to the table
                        foreach (DataGridViewRow row in DataGridView_raport_in.Rows)
                        {
                            string name = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string amount = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0.00";

                            int fontSize = name.Contains("  ") ? 11 : 13;
                            BaseColor fontColor = name.Contains("  ") ? new BaseColor(128, 128, 128) : BaseColor.BLACK;
                            bool alignLeft = !name.Contains("  ");

                            table.AddCell(new PdfPCell(new Phrase(name, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL, fontColor))) 
                            { 
                                Border = iTextSharp.text.Rectangle.NO_BORDER, 
                                HorizontalAlignment = alignLeft ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT,
                                PaddingTop = 5,
                            });
                            table.AddCell(new PdfPCell(new Phrase(amount, new iTextSharp.text.Font(baseFont, fontSize-1, iTextSharp.text.Font.NORMAL, BaseColor.BLACK))) 
                            { 
                                Border = iTextSharp.text.Rectangle.NO_BORDER,
                                HorizontalAlignment = alignLeft ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT,
                                PaddingTop = 5,
                            });
                        }

                        // Add headers for expenses section
                        table.AddCell(new PdfPCell(new Phrase("Expenses", headerFont)) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_LEFT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5,
                            FixedHeight=28,
                        });
                        table.AddCell(new PdfPCell(new Phrase(amountExpensesLedgerLabel.Text, headerFont)) 
                        { 
                            Border = iTextSharp.text.Rectangle.NO_BORDER, 
                            HorizontalAlignment = Element.ALIGN_RIGHT, 
                            BackgroundColor = new BaseColor(245, 245, 245), 
                            PaddingTop = 5 
                        });

                        // Iterate through expense rows and add data to the table
                        foreach (DataGridViewRow row in DataGridView_raport_exp.Rows)
                        {
                            string name = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : "";
                            string amount = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "0";

                            int fontSize = name.Contains("  ") ? 11 : 13;
                            BaseColor fontColor = name.Contains("  ") ? new BaseColor(128, 128, 128) : BaseColor.BLACK;
                            bool alignLeft = !name.Contains("  ");

                            table.AddCell(new PdfPCell(new Phrase(name, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL, fontColor)))
                            {
                                Border = iTextSharp.text.Rectangle.NO_BORDER,
                                HorizontalAlignment = alignLeft ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT,
                            PaddingTop = 5,
                            });
                            table.AddCell(new PdfPCell(new Phrase(amount, new iTextSharp.text.Font(baseFont, fontSize, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)))
                            {
                                Border = iTextSharp.text.Rectangle.NO_BORDER,
                                HorizontalAlignment = alignLeft ? Element.ALIGN_LEFT : Element.ALIGN_RIGHT,
                                PaddingTop = 5,
                            });
                        }

                        // Customize and add the table to the document
                        table.SpacingBefore = 10;
                        table.SpacingAfter = 10;
                        table.HorizontalAlignment = Element.ALIGN_LEFT;
                        float[] columnWidths = { 1.8f, 0.8f};
                        table.SetWidths(columnWidths);
                        document.Add(table);

                        // Close the document and display success message
                        document.Close();
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
        private void moreTransactionButton_Click(object sender, EventArgs e)
        {
            TransactionsHistoryForm transactionsHistory = new TransactionsHistoryForm();
            transactionsHistory.Show();
            this.Hide();
        }

        private void printMoneyFlowButton_Click(object sender, EventArgs e)
        {
            PrintMoneyFlowReport();
        }

        private void printLedgerButton_Click(object sender, EventArgs e)
        {
            PrintLedgerReport();
        }
    }
}