
namespace student_management_admin
{
    partial class Main_Form_Admin
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
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnSubject = new System.Windows.Forms.Button();
            this.btnTeacher = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dtgrvData = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlToolBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.Controls.Add(this.btnSchedule);
            this.pnlToolBar.Controls.Add(this.btnSubject);
            this.pnlToolBar.Controls.Add(this.btnTeacher);
            this.pnlToolBar.Controls.Add(this.btnStudent);
            this.pnlToolBar.Controls.Add(this.btnLogout);
            this.pnlToolBar.Controls.Add(this.panel1);
            this.pnlToolBar.Location = new System.Drawing.Point(12, 12);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(189, 487);
            this.pnlToolBar.TabIndex = 0;
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(21, 132);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(5);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(140, 30);
            this.btnSchedule.TabIndex = 7;
            this.btnSchedule.Text = "Lịch giảng";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnSubject
            // 
            this.btnSubject.Location = new System.Drawing.Point(21, 92);
            this.btnSubject.Margin = new System.Windows.Forms.Padding(5);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Size = new System.Drawing.Size(140, 30);
            this.btnSubject.TabIndex = 6;
            this.btnSubject.Text = "Môn học";
            this.btnSubject.UseVisualStyleBackColor = true;
            this.btnSubject.Click += new System.EventHandler(this.btnSubject_Click);
            // 
            // btnTeacher
            // 
            this.btnTeacher.Location = new System.Drawing.Point(21, 52);
            this.btnTeacher.Margin = new System.Windows.Forms.Padding(5);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.Size = new System.Drawing.Size(140, 30);
            this.btnTeacher.TabIndex = 5;
            this.btnTeacher.Text = "Giảng viên";
            this.btnTeacher.UseVisualStyleBackColor = true;
            this.btnTeacher.Click += new System.EventHandler(this.btnTeacher_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(21, 12);
            this.btnStudent.Margin = new System.Windows.Forms.Padding(5);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(140, 30);
            this.btnStudent.TabIndex = 4;
            this.btnStudent.Text = "Sinh viên";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Location = new System.Drawing.Point(55, 459);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(528, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 20);
            this.lblTitle.TabIndex = 1;
            // 
            // dtgrvData
            // 
            this.dtgrvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgrvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvData.Location = new System.Drawing.Point(218, 109);
            this.dtgrvData.Name = "dtgrvData";
            this.dtgrvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrvData.Size = new System.Drawing.Size(754, 390);
            this.dtgrvData.TabIndex = 2;
            this.dtgrvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrvData_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(218, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(738, 82);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(152, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(896, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Main_Form_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtgrvData);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "Main_Form_Admin";
            this.Text = "Main_Form_Admin";
            this.pnlToolBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnTeacher;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dtgrvData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSubject;
        private System.Windows.Forms.Button btnSchedule;
    }
}