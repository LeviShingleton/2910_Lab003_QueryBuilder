using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryBuilder.Models;

namespace QueryBuilder
{
    internal class BannedGame : IClassModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null;
        public string Series { get; set; } = null;
        public string Country { get; set; } = null;
        public string Details { get; set; } = null;
    }
}
