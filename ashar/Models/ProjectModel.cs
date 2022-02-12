using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ashar.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        [DisplayName("Project Name")]
        public string ProName { get; set; }

        [DisplayName("Start Date")]
        public DateTime Start_date { get; set; }

        [DisplayName("End Date ")]
        public DateTime End_date { get; set; }
    }
}