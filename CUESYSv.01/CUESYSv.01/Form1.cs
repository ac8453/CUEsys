using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace CUESYSv._01
{
    public partial class Form1 : Form
    {
        ///// NOTES START //////////////////////////////////////////////////////////
        // Should include log items stored on database
        // Bookings only in single hour "slots", would be better to custom set
        // Cannot search for booking (by room, date or customer)
        // Only view and edit upcoming x days
        // User+Pass check, insecure - later versions should use a database lookup
        // formatting odd on maximize/resize/different screen resolutions
        // menu is shown when software ran, this allows modification of customer entries before login - not secure
        // devlog out of sync with actions
        // autoscroll devlogs
        ///// NOTES END ////////////////////////////////////////////////////////////


        ///// VARIABLES START //////////////////////////////////////////////////////
        public int daysToView = 5;//Number of days ahead bookings are shown on landing page
        dbConn mysqlConn = new dbConn();
        ///// VARIABLES END ////////////////////////////////////////////////////////





        //  devLogs("xxxxxxxxx");





        ///// METHODS START ////////////////////////////////////////////////////////
        public void devLogs(string logItem)
        {//Write development log to DevLog
            using (StreamWriter devlog = new StreamWriter("DevLog.txt", append: true))
            { devlog.WriteLine(DateTime.Now + " --- " + logItem); }//Concat current time and logItem and write to DevLog file
        }
        public bool dbConfig()
        {
            try
            {
                mysqlConn.varConfigServer = "ac8453.cucstudents.org";
                mysqlConn.varConfigDatabase = "ac8453_CUEsys";
                mysqlConn.varConfigUser = "ac8453_CUEDadmin";
                mysqlConn.varConfigPass = "Password123!";
                return true;
            }
            catch { return false; }
        }

        public void resetControls(string newFocus)
        {//Hide all controls and only show those needed
            devLogs("resetControls triggered");
            foreach (Control control in this.Controls) { control.Visible = false; }//Hide all controls
            lbCueSys.Visible = true;//Show logo
            panClock.Visible = true;//Show clock panel
            mainMenu.Visible = true;//Show menu
            foreach (var clockLbl in panClock.Controls.OfType<Label>()){ clockLbl.Visible = true; };//Show clock in panel
            switch (newFocus)//Use control statement to selectively show controls based on newFocus argument
            {
                case "Program started":
                    lbUserName.Visible = lbUserPass.Visible = tbUserName.Visible = tbUserPass.Visible = btLogin.Visible = true;//make login controls visible
                    devLogs("Login controls visible");
                    break;
                case "landing":
                    dgRoomBookingsSummary.Visible = true;
                    dbReturn("SELECT * FROM `tblBookings` WHERE `bookingDateTime` >= CURDATE()");
                    break;
                case "Book Room":
                    panFloorLayout.Visible = true;
                    cbBuilding.Visible = true;
                    cbFloor.Visible = true;
                    foreach (var x in panFloorLayout.Controls.OfType<Button>())
                    {//Make each button transparent
                        x.Parent = panFloorLayout;
                        x.Visible = true;
                        x.BackColor = Color.Transparent;
                        x.FlatAppearance.MouseDownBackColor = Color.Transparent;
                        x.FlatAppearance.MouseOverBackColor = Color.Transparent;
                        x.FlatStyle = FlatStyle.Flat;
                        x.ForeColor = BackColor;
                        x.UseVisualStyleBackColor = true;
                        x.FlatAppearance.BorderSize = 0;
                    };
                    break;
                case "create customer":
                    lbCustAdd1.Visible = true;
                    lbCustAdd2.Visible = true;
                    lbCustContact.Visible = true;
                    lbCustEmail.Visible = true;
                    lbCustPostcode.Visible = true;
                    lbCustTel.Visible = true;
                    lbCustTitle.Visible = true;
                    lbCustTownCity.Visible = true;
                    tbCustAdd1.Visible = true;
                    tbCustAdd2.Visible = true;
                    tbCustContact.Visible = true;
                    tbCustEmail.Visible = true;
                    tbCustPostcode.Visible = true;
                    tbCustTel.Visible = true;
                    tbCustTownCity.Visible = true;
                    btCustSave.Visible = true;
                    lbCustTitle.Text = "Create Customer";
                    break;
                case "view customers":
                    //show all customers
                    dgRoomBookingsSummary.Visible = true;
                    dbReturn("SELECT * FROM `tblCustomer`");
                    break;
                case "Exit":
                    Application.Exit();
                    break;
                default:
                    devLogs("resetControls default case triggered");
                    MessageBox.Show("default");
                    break;
            }
            devLogs("Focus changed to " + newFocus);
        }
        public void dbReturn(string returnWhat)
        {
            devLogs(returnWhat + " sql run");
            if (mysqlConn.connOpen() == true)
            {
                dgRoomBookingsSummary.DataSource = mysqlConn.qry(returnWhat).Tables[0];
            }
        }
        ///// METHODS END //////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            File.WriteAllText("DevLog.txt", String.Empty);//Clear contents of DevLog
            lbCueSys.Font = new Font("Comic Sans MS", 40, FontStyle.Bold);
            this.ActiveControl = tbUserName;
            dbConfig();
            mysqlConn.connect();
            resetControls("Program started");
            devLogs("Program started");
        }

        ///// EVENTS START /////////////////////////////////////////////////////////


        private void timeClock_Tick(object sender, EventArgs e)
        {//Timer to control clock
            lbClockTime.Text = DateTime.Now.ToString("HH:mm");
            lbClockSeconds.Text = DateTime.Now.ToString("ss");
            lbClockDate.Text = DateTime.Now.ToString("ddd")+"  "+DateTime.Now.ToString("dd/MM/yyyy");
        }


        private void btLogin_Click(object sender, EventArgs e)
        {
            devLogs("Login button clicked");
            //User+Pass check, not secure and only allows one login
            if (tbUserName.Text == "admin" && tbUserPass.Text == "admin")
            { resetControls("landing"); devLogs("Login success for user " + tbUserName.Text); }//Login success
            else
            { MessageBox.Show("Sorry, wrong password/user combo!"); devLogs("Login failure for user " + tbUserName.Text); }//Login failure
            tbUserName.Text = ""; tbUserPass.Text = ""; //Clear logon credentials
        }
        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {//Change focus to password box on enter key
                this.ActiveControl = tbUserPass;
                devLogs("enter key detected in tbUserName");
            }
        }
        private void tbUserPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {//Trigger login button on enter key
                btLogin_Click(this, new EventArgs());
                devLogs("enter key detected in tbUserPass");
            }
        }

        private void dgRoomBookingsSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string dgRoomBookingsSummarySelected = Convert.ToString(dgRoomBookingsSummary.CurrentRow.Cells[0].Value);devLogs("dgRoomBookingsSummary cell "+ dgRoomBookingsSummarySelected + " selected");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {//Generic keyboard shortcuts
            if (keyData == (Keys.Alt | Keys.L))
            {
                devLogs("alt-l shortcut intercepted");
                resetControls("Program started");
                return true;
            }
            if (keyData == (Keys.Alt | Keys.X))
            {
                devLogs("alt-x shortcut intercepted");
                resetControls("Exit");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void viewDevLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form devForm = new Form();
            devForm.Text = "DevLogs";
            RichTextBox rtbDevLogs = new RichTextBox();
            Timer timerRefreshDevLogs = new Timer();
            timerRefreshDevLogs.Interval = 2500;
            timerRefreshDevLogs.Tick += new EventHandler(devRefreshTimer_Tick);
            timerRefreshDevLogs.Start();
            rtbDevLogs.Location = new Point(0, 0);
            rtbDevLogs.Size = new Size(300, 380);
            rtbDevLogs.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            devForm.Size = new Size(300, 400);
            devForm.Controls.Add(rtbDevLogs);
            devLogs("devlogs viewed");
            void devRefreshTimer_Tick(object timer, EventArgs args)
            {
                rtbDevLogs.Text = "";
                string line;
                try
                {
                    StreamReader sr = new StreamReader("DevLog.txt");
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        rtbDevLogs.Text += line + "\r\n";
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch (Exception ex) { devLogs("error reading devlogs"); }
            }
            devForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetControls("Program started");devLogs("user logged out");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetControls("Exit"); devLogs("application exit request");
        }

        private void bookRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetControls("Book Room");devLogs("book room request");
        }

        private void btRoomA_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder(cbBuilding.Text, cbFloor.Text, "1");
            newOrder.ShowDialog();
            devLogs("room a clicked");
        }

        private void btRoomB_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder(cbBuilding.Text, cbFloor.Text, "2");
            newOrder.ShowDialog();
            devLogs("room b clicked");
        }

        private void btRoomC_Click(object sender, EventArgs e)
        { 
            NewOrder newOrder = new NewOrder(cbBuilding.Text, cbFloor.Text, "3");
            newOrder.ShowDialog();
            devLogs("room c clicked");
        }

        private void btRoomD_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder(cbBuilding.Text, cbFloor.Text, "4");
            newOrder.ShowDialog();
            devLogs("room d clicked");
        }

        private void btRoomE_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder(cbBuilding.Text, cbFloor.Text, "5");
            newOrder.ShowDialog();
            devLogs("room e clicked");
        }

        private void btRoomF_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder(cbBuilding.Text, cbFloor.Text, "6");
            newOrder.ShowDialog();
            devLogs("room f clicked");
        }

        private void btRoomG_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder(cbBuilding.Text, cbFloor.Text, "7");
            newOrder.ShowDialog();
            devLogs("room g clicked");
        }

        private void btRoomH_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder(cbBuilding.Text, cbFloor.Text, "8");
            newOrder.ShowDialog();
            devLogs("room h clicked");
        }

        private void createCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetControls("create customer"); devLogs("create customer request");
        }
        
        private void viewBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetControls("landing"); devLogs("show bookings");
        }

        private void viewCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetControls("view customers"); devLogs("show customers");
        }

        private void btCustSave_Click(object sender, EventArgs e)
        {
            devLogs("insert new customer");
            if (mysqlConn.connOpen() == true)
            {
                mysqlConn.insertCustomer(tbCustContact.Text, tbCustEmail.Text, tbCustTel.Text, tbCustAdd1.Text, tbCustAdd2.Text, tbCustTownCity.Text, tbCustPostcode.Text);
            }
            tbCustContact.Text = tbCustEmail.Text = tbCustTel.Text = tbCustAdd1.Text = tbCustAdd2.Text = tbCustTownCity.Text = tbCustPostcode.Text = "";
        }





        ///// EVENTS END ///////////////////////////////////////////////////////////




    }
}
