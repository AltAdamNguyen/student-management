using student_management_admin.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student_management_admin
{
    public partial class Form_Insert_Location : Form
    {
        AdminClassesDataContext db = new AdminClassesDataContext();
        Main_Form_Admin main_Form;

        string txtSelect { get; set; }
        string build_id { get; set; }
        string id { get; set; }
        bool isUpdate { get; set; }

        public Form_Insert_Location(string build_id, string id, bool isUpdate, string select, Main_Form_Admin main_Form)
        {
            InitializeComponent();
            this.main_Form = main_Form;
            this.txtSelect = select;
            this.isUpdate = isUpdate;
            this.id = id;
            this.build_id = build_id;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtCode.Text;
            string name = txtName.Text;

            if (string.IsNullOrEmpty(id))
            {
                switch(txtSelect)
                {
                    case "building":
                        lblValidateCode.Text = "Mã toà nhà là bắt buộc";
                        break;
                    case "classroom":
                        lblValidateCode.Text = "Mã phòng học là bắt buộc";
                        break;
                }
            }
            else
            {
                lblValidateCode.Text = "";
            }

            if (string.IsNullOrEmpty(id))
            {
                switch (txtSelect)
                {
                    case "building":
                        lblValidateName.Text = "Tên toà nhà là bắt buộc";
                        break;
                    case "classroom":
                        lblValidateName.Text = "Tên phòng học là bắt buộc";
                        break;
                }
            }
            else
            {
                lblValidateName.Text = "";
            }

            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name))
            {
                switch (txtSelect)
                {
                    case "building":
                        var resultBuild = db.Buildings.SingleOrDefault(b => b.id.Equals(id));
                        if (resultBuild == null)
                        {
                            if (isUpdate)
                            {
                                Building building = db.Buildings.Single(b => b.id.Equals(id));
                                building.name = name;
                            }
                            else
                            {
                                Building building = new Building();
                                building.id = id;
                                building.name = name;

                                db.Buildings.InsertOnSubmit(building);
                            }
                        } else
                        {
                            MessageBox.Show("Toà nhà đã tồn tại");
                        }
                        break;
                    case "classroom":
                        var resultClass = db.Locations.SingleOrDefault(l => l.building_id.Equals(build_id) && l.classroom_id.Equals(build_id + "_" + id));
                        if (resultClass == null)
                        {
                            if (isUpdate)
                            {
                                Classroom classroom = db.Classrooms.Single(c => c.id.Equals(id));
                                classroom.name = name;
                            }
                            else
                            {
                                Classroom classroom = new Classroom();
                                classroom.id = build_id + "_" + id;
                                classroom.name = name;

                                Location location = new Location();
                                location.id = build_id + "_" + id;
                                location.classroom_id = build_id + "_" + id;
                                location.building_id = build_id;

                                db.Classrooms.InsertOnSubmit(classroom);
                                db.Locations.InsertOnSubmit(location);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phòng học trong toà nhà " + build_id + " đã tồn tại");
                        }
                        break;
                }
                string desMes = "Thêm thành công !!!";

                if (isUpdate)
                {
                    desMes = "Cập nhật thành công !!!";
                }

                try
                {
                    db.SubmitChanges();
                    DialogResult dialogResult = MessageBox.Show(desMes, "", MessageBoxButtons.OK);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin");
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Insert_Location_Load(object sender, EventArgs e)
        {
            switch (txtSelect)
            {
                case "building":
                    lblTitle.Text = "Thông tin toà nhà";
                    lblCode.Text = "Mã toà nhà";
                    lblName.Text = "Tên toà nhà";                   
                    break;
                case "classroom":
                    lblTitle.Text = "Thông tin phòng học";
                    lblCode.Text = "Mã phòng học";
                    lblName.Text = "Tên phòng học";
                    break;
            }

            if (isUpdate)
            {
                btnAdd.Text = "Cập nhât";
                txtCode.ReadOnly = true;
                switch (txtSelect)
                {
                    case "building":
                        Building building = db.Buildings.Single(b => b.id.Equals(id));
                        txtCode.Text = building.id;
                        txtName.Text = building.name;
                        break;
                    case "classroom":
                        Classroom classroom = db.Classrooms.Single(c => c.id.Equals(id));
                        txtCode.Text = classroom.id;
                        txtName.Text = classroom.name;
                        break;
                }
            }
        }

        private void Form_Insert_Location_FormClosed(object sender, FormClosedEventArgs e)
        {
            main_Form.DataGridViewRefresh();
        }
    }
}
