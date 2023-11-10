
namespace student_management
{
    partial class Main_Form_Teacher
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
            this.pnActivity = new System.Windows.Forms.Panel();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.cbDateOfWeek = new System.Windows.Forms.ComboBox();
            this.dtgrvData = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.btnTeacher = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvData)).BeginInit();
            this.pnlToolBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnActivity
            // 
            this.pnActivity.Controls.Add(this.cbYear);
            this.pnActivity.Controls.Add(this.cbDateOfWeek);
            this.pnActivity.Controls.Add(this.dtgrvData);
            this.pnActivity.Location = new System.Drawing.Point(204, 56);
            this.pnActivity.Name = "pnActivity";
            this.pnActivity.Size = new System.Drawing.Size(772, 435);
            this.pnActivity.TabIndex = 6;
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(10, 10);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(103, 21);
            this.cbYear.TabIndex = 16;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // cbDateOfWeek
            // 
            this.cbDateOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDateOfWeek.FormattingEnabled = true;
            this.cbDateOfWeek.Location = new System.Drawing.Point(119, 10);
            this.cbDateOfWeek.Name = "cbDateOfWeek";
            this.cbDateOfWeek.Size = new System.Drawing.Size(214, 21);
            this.cbDateOfWeek.TabIndex = 15;
            this.cbDateOfWeek.SelectedIndexChanged += new System.EventHandler(this.cbDateOfWeek_SelectedIndexChanged);
            // 
            // dtgrvData
            // 
            this.dtgrvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgrvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvData.Location = new System.Drawing.Point(9, 37);
            this.dtgrvData.Name = "dtgrvData";
            this.dtgrvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgrvData.Size = new System.Drawing.Size(754, 390);
            this.dtgrvData.TabIndex = 9;
            this.dtgrvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrvData_CellDoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(525, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(125, 20);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Lịch giảng của";
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnTeacher);
            this.pnlToolBar.Controls.Add(this.btnSchedule);
            this.pnlToolBar.Controls.Add(this.btnLogout);
            this.pnlToolBar.Controls.Add(this.panel1);
            this.pnlToolBar.Location = new System.Drawing.Point(9, 4);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(189, 487);
            this.pnlToolBar.TabIndex = 4;
            // 
            // btnTeacher
            // 
            this.btnTeacher.Location = new System.Drawing.Point(21, 52);
            this.btnTeacher.Margin = new System.Windows.Forms.Padding(5);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.Size = new System.Drawing.Size(140, 30);
            this.btnTeacher.TabIndex = 1;
            this.btnTeacher.Text = "Thông tin";
            this.btnTeacher.UseVisualStyleBackColor = true;
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(21, 12);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(5);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(140, 30);
            this.btnSchedule.TabIndex = 0;
            this.btnSchedule.Text = "Lịch giảng";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Location = new System.Drawing.Point(55, 459);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(3, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 38);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chào mừng,";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(82, 12);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 16);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label2";
            // 
            // Main_Form_Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 495);
            this.Controls.Add(this.pnActivity);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "Main_Form_Teacher";
            this.Text = "Main_Form_Teacher";
            this.Load += new System.EventHandler(this.Main_Form_Teacher_Load);
            this.pnActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvData)).EndInit();
            this.pnlToolBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnActivity;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbDateOfWeek;
        private System.Windows.Forms.DataGridView dtgrvData;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlToolBar;
        private System.Windows.Forms.Button btnTeacher;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
    }
}