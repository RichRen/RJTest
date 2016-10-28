using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Aspose.Cells;
using Web.Helpers;

namespace Web.Controllers
{
    public class AsposeController : BaseController
    {
        // GET: Aspose
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Export()
        {
            DataTable table = new DataTable();
            table.Columns.Add("登录ID", typeof(string));
            table.Columns.Add("姓名", typeof(string));
            table.Columns.Add("密码", typeof(string));

            DataRow row = table.NewRow();
            row["登录ID"] = "登陆1";
            row["姓名"] = "姓名1";
            row["密码"] = "123";

            table.Rows.Add(row);

            ExportExcelHelper.ExportFromDataTable("员工信息.xls", table);
            return resultMsg("导出成功！");
        }

        public ActionResult Import()
        {
            using (FileStream filestream = System.IO.File.OpenRead(Server.MapPath("~/Template/user.xls")))
            {
                Workbook workbook = new Workbook(filestream);
                Worksheet sheet1 = workbook.Worksheets[0];
                Cells cells = sheet1.Cells;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i <= cells.MaxDataRow; i++)
                {
                    for (int j = 0; j <= cells.MaxColumn; j++)
                    {
                        sb.Append(cells[i, j].StringValue);
                    }
                    sb.Append(Environment.NewLine);
                }

                return resultMsg(sb.ToString());
            }
        }
    }
}