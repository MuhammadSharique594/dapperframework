using DapperFramework.Operations;
using DapperModels;
using DapperModels.Operations;
using ModelGenerator.Config;
using ModelGenerator.Process;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using DapperFramework.Attributes;

namespace DapperTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration.ConnectionString = $"Data Source=.;Initial Catalog=DapperModels;User ID=sa;Password=sa";
            //Process.StartProcessing("DapperModels", @"C:\Users\shari\Desktop\Output\New");

            Dapper.SetConnectionString = $"Data Source=.;Initial Catalog=DapperModels;User ID=sa;Password=sa";
            Dapper.SetConnectionString = $"Data Source=.;Initial Catalog=TimeAnalyser;User ID=sa;Password=sa";

			//Dapper.Delete<Info>(shayan => shayan.Id > -1);

			//var info = new Info { Name = "Shaqe", Phone = "03432581909", Detail = "Detail" };
			//var info = new Info {Phone = "03432581909"};

	        var abc = new List<ABC>{ new ABC { a = "a", b = "b", j = "j" }, new ABC { a = "a", b = "b", j = "j" }, new ABC { a = "a", b = "b", j = "j" } };
			//Dapper.Update(abc, x => x.g == "g" && x.h == "abc", x => x.a, x => x.b, x => x.j);
			//Dapper.AddRows(abc);

			//Dapper.Add(info);

			//var s = "shaqe => (shaqe.od > 0)";

			//Console.WriteLine(s);
			//Console.WriteLine(s.IndexOf("=>"));
			//Console.WriteLine(s.Substring(0, s.IndexOf("=>") - 1).Replace(" ","|"));
			//Console.Read();

			//      var HVSZTYP = new HVSZTYP
			//      {
			//       TYPNR = 1,
			//       TYPBEZEICH = "asfdasd"
			//      };
			//Dapper.AddRow(HVSZTYP);
			//Dapper.Delete<HVSZTYP>(x => x.ID > 0);

	        try
	        {
		        Dapper.AddRow(new Record
		        {
			        Name = "Shaqe",
			        Time = DateTime.Now,
			        Type = RecordType.Login
		        });
	        }
	        catch (Exception ex)
	        {

	        }

        }
	}

	public enum RecordType
	{
		Login,
		Logout
	}
	public class Record
	{
		[Identity]
		public long Id { get; set; }
		public string Name { get; set; }
		public DateTime Time { get; set; }
		public RecordType Type { get; set; }
	}

	public class HVSZTYP
	{

		public int TYPNR { get; set; }
		public string TYPBEZEICH { get; set; }
		public string TYPGKUERZT { get; set; }
		[Identity]
		public int ID { get; set; }



	}

	public class ABC
	{
		[Identity]
		public string a { get; set; }
		public string b {get; set;}
		public string c {get; set;}
		public string d {get; set;}
		[Identity]
		public string e {get; set;}
		public string f {get; set;}
		public string g {get; set;}
		public string h {get; set;}
		public string i {get; set;}
		public string j {get; set;}
	}
}
