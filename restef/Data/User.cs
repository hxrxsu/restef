using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace restef.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string? Feedback {  get; set; }
        public List<string>? SummaryFS { get; set; }
        public List<string>? Order {  get; set; }
        public int Sum {  get; set; }
        public string Login { get; set; }
        public string Password { get; set; }  
    }
}
