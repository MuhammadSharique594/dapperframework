using System.Collections.Generic;

namespace DapperModels
{
	public class InfoDescription
	{
		public long ID {get; set;}
		public string Description {get; set;}
		public long InfoID {get; set;}
		public long IDDD {get; set;}

		public List<Testing> Testing {get; set;}
		public List<Info> Info {get; set;}

	}
}
