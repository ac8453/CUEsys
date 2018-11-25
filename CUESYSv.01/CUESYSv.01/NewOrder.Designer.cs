namespace CUESYSv._01
{
    partial class NewOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNewBooking = new System.Windows.Forms.Label();
            this.lbBookingInfo = new System.Windows.Forms.Label();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.tbCustomer = new System.Windows.Forms.TextBox();
            this.cbPaid = new System.Windows.Forms.CheckBox();
            this.mcDate = new System.Windows.Forms.MonthCalendar();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.MaskedTextBox();
            this.btBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNewBooking
            // 
            this.lbNewBooking.AutoSize = true;
            this.lbNewBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewBooking.Location = new System.Drawing.Point(13, 13);
            this.lbNewBooking.Name = "lbNewBooking";
            this.lbNewBooking.Size = new System.Drawing.Size(240, 25);
            this.lbNewBooking.TabIndex = 0;
            this.lbNewBooking.Text = "Create new booking for:";
            // 
            // lbBookingInfo
            // 
            this.lbBookingInfo.AutoSize = true;
            this.lbBookingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBookingInfo.Location = new System.Drawing.Point(13, 47);
            this.lbBookingInfo.Name = "lbBookingInfo";
            this.lbBookingInfo.Size = new System.Drawing.Size(133, 25);
            this.lbBookingInfo.TabIndex = 1;
            this.lbBookingInfo.Text = "xxxxxxxxxxx";
            // 
            // tbCost
            // 
            this.tbCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCost.Location = new System.Drawing.Point(127, 357);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(227, 29);
            this.tbCost.TabIndex = 2;
            // 
            // tbCustomer
            // 
            this.tbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.Location = new System.Drawing.Point(127, 119);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.Size = new System.Drawing.Size(227, 29);
            this.tbCustomer.TabIndex = 3;
            // 
            // cbPaid
            // 
            this.cbPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaid.Location = new System.Drawing.Point(134, 402);
            this.cbPaid.Name = "cbPaid";
            this.cbPaid.Size = new System.Drawing.Size(25, 25);
            this.cbPaid.TabIndex = 4;
            this.cbPaid.UseVisualStyleBackColor = true;
            // 
            // mcDate
            // 
            this.mcDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcDate.Location = new System.Drawing.Point(127, 159);
            this.mcDate.Name = "mcDate";
            this.mcDate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Paid (Y/N)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cost       £";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(127, 331);
            this.tbTime.Mask = "00:00";
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(40, 20);
            this.tbTime.TabIndex = 14;
            this.tbTime.ValidatingType = typeof(System.DateTime);
            // 
            // btBook
            // 
            this.btBook.Location = new System.Drawing.Point(279, 402);
            this.btBook.Name = "btBook";
            this.btBook.Size = new System.Drawing.Size(75, 23);
            this.btBook.TabIndex = 15;
            this.btBook.Text = "BOOK";
            this.btBook.UseVisualStyleBackColor = true;
            this.btBook.Click += new System.EventHandler(this.btBook_Click);
            // 
            // NewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 442);
            this.Controls.Add(this.btBook);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mcDate);
            this.Controls.Add(this.cbPaid);
            this.Controls.Add(this.tbCustomer);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.lbBookingInfo);
            this.Controls.Add(this.lbNewBooking);
            this.Name = "NewOrder";
            this.Text = "Add New Booking";
            this.Load += new System.EventHandler(this.NewOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNewBooking;
        private System.Windows.Forms.Label lbBookingInfo;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.TextBox tbCustomer;
        private System.Windows.Forms.CheckBox cbPaid;
        private System.Windows.Forms.MonthCalendar mcDate;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbTime;
        private System.Windows.Forms.Button btBook;
    }
}