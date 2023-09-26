using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryBuilder.Models;

namespace QueryBuilder
{
    internal class Pokemon : IClassModel
    {
        public int Id { get; set; }
        public int DexNumber { get; set; } = -1;

        public string Name { get; set; } = null;
        public string Form { get; set; } = null;
        public string Type1 { get; set; } = null;
        public string Type2 { get; set; } = null;

        public int Total { get; set; } = 0;
        public int HP { get; set; } = 0;
        public int Attack { get; set; }
        public int Defense { get; set; } = 0;
        public int SpecialAttack { get; set; } = 0;
        public int SpecialDefense { get; set; } = 0;
        public int Speed { get; set; } = 0;
        public int Generation { get; set; } = 0;
    }
}
