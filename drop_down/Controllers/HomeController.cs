using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using drop_down.Models;

namespace drop_down.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string oradb = "Data Source=dbtest;User ID=psl;Password=psl;";


            var list = new List<DropDown>();

            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "Select d.deptno,d.dname From dept d";
            cmd.Connection = con;
            con.Open();

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new DropDown
                {
                    deptid = reader.GetInt16(0),
                    dname = reader.GetString(1)
                });
            }
            var model = new list();
            ViewBag.drop = new SelectList(list, "deptid", "dname");
            return View();
        }
    }
}