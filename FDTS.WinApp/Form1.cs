using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FDTS.Models.Repository;

namespace HRIS.WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            List<string> str = new List<string> { "DepartmentName", "Id" };

            var model = unitOfWork.DepartmentsRepo.Get();
            foreach (var i in model)
            {
                foreach (var s in str)
                {
                    Debug.WriteLine($"{s}:{i.GetType().GetProperty(s).GetValue(i, null) }");
                }

            }

        }

        private void OpenFile_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
