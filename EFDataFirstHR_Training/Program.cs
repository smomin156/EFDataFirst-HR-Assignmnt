using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataFirstHR_Training
{
    class Program
    {
        static void Main(string[] args)
        {
            TRAININGEntities db = new TRAININGEntities();

            ////LIST ALL THE DATA FROM THE EMPLOYEE TABLE
            //IEnumerable<EMP> query1 = db.EMPs.Select(e => e);
            //query1 = from e in db.EMPs select e;

            //foreach (var item in query1)
            //{
            //    Console.WriteLine(item.ENAME);
            //}

            ////LIST ALL THE DATA FROM THE EMPLOYEE TABLE ORDER BY JOB
            //IEnumerable<EMP> query2 = db.EMPs.OrderBy(e => e.JOB);
            //query2 = from e in db.EMPs orderby e.JOB select e;

            //foreach (var item in query1)
            //{
            //    Console.WriteLine(item.ENAME+"\t"+item.JOB );
            //}

            ////LIST ALL THE DATA FROM THE EMPLOYEE TABLE WHOSE NAME START WITH S
            //IEnumerable<EMP> query3 = db.EMPs.Where(e => e.ENAME.StartsWith("S"));
            //query3 = from e in db.EMPs where e.ENAME.StartsWith("S") select e;

            //foreach (var item in query3)
            //{
            //    Console.WriteLine(item.ENAME);
            //}

            ////LIST DISTINCT JOB
            //var query4 = db.EMPs.Select(e => e.JOB).Distinct();
            //query4 = (from e in db.EMPs select e.JOB).Distinct();

            //foreach (var item in query4)
            //{
            //    Console.WriteLine(item);
            //}

            ////5. FIND THE DETAILS OF ALL MANAGER (IN ANY DEPT) AND ALL CLERKS IN DEPT 10
            //var query5 = db.EMPs.Where(e => e.JOB == "clerk" && e.DEPTNO == 10 || e.JOB == "Manager");
            //query5 = from e in db.EMPs where (e.JOB == "MANAGER" || (e.JOB == "CLERK" && e.DEPTNO == 10)) select e;

            //foreach (var item in query5)
            //{
            //    Console.WriteLine($"{item.ENAME}\t{item.JOB}\t {item.DEPTNO} ");
            //}

            ////6.FIND THE EMPLOYEES WHO DO NOT RECEIVE A COMMISSION
            //var query6 = db.EMPs.Where(e => e.COMM == null);
            //query6 = from e in db.EMPs where e.COMM == null select e;

            //foreach (var item in query6)
            //{
            //    Console.WriteLine(item.ENAME);
            //}

            ////7.FIND ALL EMPLOYEES WHOSE NET EARNINGS (SAL + COMM) Is GREATER THAN RS. 2000
            //var query7= db.EMPs.Where(e => (e.COMM==null?0:e.COMM + e.SAL) > 2000).Select(e=>e);

            //var query7a = from e in db.EMPs let NetEarnings = e.SAL + e.COMM == null ? 0 : e.COMM where NetEarnings > 2000 select e;
            //Console.WriteLine("==============");
            //foreach (var item in query7)
            //{
            //    Console.WriteLine(item.ENAME+"\t"+item.SAL+"\t"+item.COMM+"\t");
            //}

            ////8.FIND ALL EMPLOYEE HIRED IN MONTH OF FEBUARY (OF ANY YEAR)
            //var query8 = db.EMPs.Where(e => SqlFunctions.DatePart("mm", e.HIREDATE) == 2);
            //query8=  from e in db.EMPs where e.HIREDATE.Value.Month.Equals(2) select e;

            //foreach (var item in query8)
            //{
            //    Console.WriteLine(item.ENAME + "\t" + item.HIREDATE );
            //}

            ////9.. LIST TOTAL SALARY FOR THE ORGANIZATION
            //var query9 = db.EMPs.Sum(e => e.SAL);
            //query9 = (from e in db.EMPs select e).Sum(e => e.SAL);


            //Console.WriteLine("salary: " + query9);


            ////10.LIST TOTAL EMPLOYEES WORKS IN EACH DEPARTMENT

            //var query10 = db.EMPs.GroupBy(e => e.DEPTNO).Select(empgrp => new { grpname = empgrp.Key, sumgrp = empgrp.Count() });
            //var query10a = from e in db.EMPs
            //          group e by e.DEPTNO into empGrp
            //          select new
            //          {
            //              grpName = empGrp.Key,
            //              count = empGrp.Count()
            //          };
            //foreach (var item in query10)
            //{
            //    Console.WriteLine(item.grpname + "\t" + item.sumgrp);
            //}

            ////11.LIST FIRST THREE HIGHEST PAID EMPLOYEES
            //var query11 = db.EMPs.OrderByDescending(e => e.SAL).Take(3);
            //query11 = (from e in db.EMPs orderby e.SAL descending select e).Take(3);
            //foreach (var item in query11)
            //{
            //    Console.WriteLine("" + item.ENAME + "\t" + item.SAL);
            //}

            ////12.DISPLAY THE NAMES, JOB AND SALARY OF ALL EMPLOYEES, SORTED ON DESCENDING ORDER OF JOB AND WITHIN JOB,SORTED ON THE DESCENDING ORDER OF SALARY

            //var query12=db.EMPs.OrderBy(e => e.JOB).ThenByDescending(e => e.SAL);
            //var query12a = from e in db.EMPs orderby e.JOB descending, e.SAL descending select new { Name = e.ENAME, Job = e.JOB, Salary = e.SAL };
            //foreach (var item in query11)
            //{
            //    Console.WriteLine($"{item.ENAME}\t{item.JOB}\t{item.SAL}");
            //}

            ////13.LIST DEPARTMENT NAME, EMPLOYEE NAME AND JOB
            //var query13 = db.EMPs.Join(db.DEPTs, e => e.DEPTNO, d => d.DEPTNO, (e, d) => new { d.DNAME, e.ENAME, e.JOB });
            //query13 = from e in db.EMPs join d in db.DEPTs on e.DEPTNO equals d.DEPTNO select new { d.DNAME, e.ENAME, e.JOB };
            //foreach (var item in query13)
            //{
            //    Console.WriteLine($"{item.DNAME}\t{item.ENAME}\t{item.JOB}");
            //}

            ////14. LIST DEPARTMENT NAME AND MAX SALARY FOR EACH DEPARTMENT
            //var query14 = db.DEPTs.Join(db.EMPs, d => d.DEPTNO, e => e.DEPTNO, (d, e) => new { d.DNAME, e.SAL }).
            //                GroupBy(d => d.DNAME).Select(grp => new { grpname = grp.Key, totalsal = grp.Max(e => e.SAL) });


            //var query14a = from e in db.EMPs
            //              join d in db.DEPTs on e.DEPTNO equals d.DEPTNO
            //              group e by d.DNAME into grp
            //              select new { Department = grp.Key, MaxSal = grp.Max(e => e.SAL) };

            //Console.WriteLine("==============");
            //foreach (var item in query14a)
            //{
            //    Console.WriteLine(item.Department + " " + item.MaxSal);
            //}

            ////15 LIST DEPARTMENT NAME AND TOTAL EMPLOYEE WORKING IN EACH DEPARTMENT ALSO INCLUDE DEPARTMENT WHERE NO EMPLOYEES ARE WORKING
            //var query15 = db.DEPTs.GroupJoin(db.EMPs, d => d.DEPTNO, e => e.DEPTNO, (d, e )=>new {d,e }).GroupBy(d=>d.d.DNAME).Select (grp=>new {gname=grp.Key,gcount=grp.Count() });

            //var query15a = from d in db.DEPTs
            //              join e in db.EMPs on d.DEPTNO equals e.DEPTNO into ed
            //              from e in ed.DefaultIfEmpty()
            //              group e by d.DNAME into grp
            //              select new { Dept = grp.Key, TotalEmp = grp.Count() };

            //foreach (var item in query15a)
            //{
            //    Console.WriteLine(item.Dept+ "\t" + item.TotalEmp);
            //}

            ////16 SELECT Dept Name FROM Department TABLE WHILE DISPLAYING DATA ALSO DISPLAY Emp Name BASED ON Department
            var query16 = from d in db.DEPTs select d;

            //Console.WriteLine("==============");

            //foreach (var item in query16)
            //{
            //    Console.WriteLine(item.DNAME);
            //    foreach (var em in item.EMPs)
            //    {
            //        Console.WriteLine("\t"+em.ENAME);
            //    }

            //}



            //17 INSERT NEW DEPARTMENT AND EMPLOYEE FOR THAT DEPARTMENT DEPTNO = 50, DEPTNAME = IT EMPNO = 1001, EMPNAME = RAHUL
            //Console.WriteLine("before insert :" + db.DEPTs.Count() + "\t" + db.EMPs.Count());
            //DEPT newdept = new DEPT()
            //{
            //    DEPTNO = 50,
            //    DNAME = "IT"

            //};
            //db.DEPTs.Add(newdept);
            //db.SaveChanges();
            //EMP newemp = new EMP()
            //{
            //    EMPNO = 1001,
            //    ENAME = "RAHUL",
            //};

            //db.EMPs.Add(newemp);
            //db.SaveChanges();

            //18.UPDATE Rahul RECORD WITH SAL = 20000
            //UPDATE Rahul RECORD WITH SAL = 20000 

            //EMP updemp = db.EMPs.SingleOrDefault(e => e.ENAME == "RAHUL");
            //if (updemp != null)
            //{
            //    updemp.SAL = 20000;

            //    int count = db.SaveChanges();
            //    Console.WriteLine($"{count} record updated");
            //}

            //19.Delete Record of Rahul
            //Delete Record of Rahul 
            //EMP delemp = db.EMPs.SingleOrDefault(e => e.ENAME == "RAHUL");
            //if (delemp != null)
            //{
            //    db.EMPs.Remove(delemp);
            //    Console.WriteLine("Record deleted");
            //    int count = db.SaveChanges();
            //}
            //else
            //{
            //    Console.WriteLine("Record not founs");
            //}

            //20.Write a stored procedure in SQL Server name it as
            //JobWiseDetails which takes Job as in parameter and
            //return Total Employee, Max Salary and Min Salary for
            //the Job

            //ObjectParameter cnt = new ObjectParameter("count", typeof(int));
            //ObjectParameter maxSal = new ObjectParameter("maxSal", typeof(int));
            //ObjectParameter minSal = new ObjectParameter("minSal", typeof(int));
            //db.JobWiseDetails("sales", cnt, maxSal, minSal);

            //Console.WriteLine($"Count:{cnt.Value}\t MaxSal:{maxSal.Value}\tMinSal: {minSal.Value}");



            Console.ReadLine();
        }
    }
}
