using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUESYSv._01
{
    public partial class NewOrder : Form
    {
        private string varBookingInfo;
        private string varBuilding;
        private string varFloor;
        private string varRoom;
        public NewOrder(string building, string floor, string room)
        {
            InitializeComponent();
            switch (floor) {
                case "Ground":
                    varFloor = "G";
                    break;
                case "First":
                    varFloor = "1";
                    break;
                case "Second":
                    varFloor = "2";
                    break;
                case "Third":
                    varFloor = "3";
                    break;
                case "Fourth":
                    varFloor = "4";
                    break;
                default:
                    break;
            }
            varBookingInfo = building + " - " + varFloor + room;
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            lbBookingInfo.Text = varBookingInfo;
        }

        private void btBook_Click(object sender, EventArgs e)
        {

        }

//        string varDateTime = "";
//        string varPaid;
//            if (cbPaid.Checked == true) { varPaid = "Y"; }
//            else { varPaid = "N"; }
//dbConn mysqlConn = new dbConn();
//mysqlConn.insertBooking(tbCustomer.Text, varBuilding, varFloor, varRoom, varDateTime, tbCost.Text, varPaid);
    }
}

// '2018-11-15 09:00:12'
//insertBooking(string custContact, string bookingBuilding, string bookingFloor, string bookingRoom, string bookingDateTime, string bookingCost, string bookingPaid)
//open form and pass building and floor and room to labels, allow user to pick date time and customer (from dropdown?) 
