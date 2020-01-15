using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace LINQWebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {





        }

        public void DoADOStuff()
        {


            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string sql = "Select * from Students";
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, conn);

            List<StudentClass> liststudents = new List<StudentClass>();

            conn.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {

                StudentClass student = new StudentClass();

                student.id = Convert.ToInt32(rd["Id"]);
                student.FName = rd["fName"].ToString();
                student.LName = rd["lName"].ToString();
                student.Gender = rd["gender"].ToString();

                liststudents.Add(student);


            }

            conn.Close();

            GridView1.DataSource = liststudents;

            GridView1.DataBind();



        }

        public void DoLINQStuff()
        {



            Database1DataContext dataContext = new Database1DataContext();

            GridView1.DataSource = from student in dataContext.Students
                                   where student.gender == "Female"
                                   select student;

            GridView1.DataBind();

            GridView1.Visible = true;
        }


        protected void btnLinq_Click(object sender, EventArgs e)
        {
            DoLINQStuff();
        }

        protected void btnLinqArray_Click(object sender, EventArgs e)
        {
            DoLinqArrayStuff();
        }

        protected void btnAdo_Click(object sender, EventArgs e)
        {

            DoADOStuff();
        }


        public void DoLinqArrayStuff()
        {

            int[] myints = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19 };


            GridView2.DataSource = from myint in myints
                                   where (myint < 14) && (myint % 2 == 0)
                                   select myint;

            GridView2.DataBind();


        }

        protected void btnLambdaGetStudents_Click(object sender, EventArgs e)
        {

            StudentClass studentclass = new StudentClass();
            //GridView3.DataSource = studentclass.GetAllStudents();
            //GridView3.DataBind();

            //IEnumarable<StudentClass> StudentClass.
            IEnumerable<StudentClass> qryResult = studentclass.GetAllStudents().Where(student => student.Gender == "Male");
            GridView3.DataSource = qryResult;

            GridView3.DataBind();


        }
    }



    public class StudentClass
    {
        public int id { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }
        public string Gender { set; get; }

        public List<StudentClass> GetAllStudents()
        {
            List<StudentClass> listStudentClass = new List<StudentClass>();

            StudentClass student1 = new StudentClass();
            student1.id = 101;
            student1.FName = "Minnie";
            student1.LName = "Mouse";
            student1.Gender = "Female";
            listStudentClass.Add(student1);

            StudentClass student2 = new StudentClass();
            student2.id = 102;
            student2.FName = "Steve";
            student2.LName = "Martin";
            student2.Gender = "Male";
            listStudentClass.Add(student2);

            StudentClass student3 = new StudentClass();
            student3.id = 103;
            student3.FName = "Jane";
            student3.LName = "Doe";
            student3.Gender = "Female";
            listStudentClass.Add(student3);

            StudentClass student4 = new StudentClass();
            student4.id = 104;
            student4.FName = "Joe";
            student4.LName = "Dirt";
            student4.Gender = "Male";
            listStudentClass.Add(student4);

            //IEnumerable<StudentClass> students = GetAllStudents().Where(student => student.Gender == "Male");
            //return students;
            //return student1.ToList();
            return listStudentClass.ToList();

        }

    }

}