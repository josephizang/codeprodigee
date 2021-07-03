using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Data
{
    public class CodeProdigeeContext : DbContext
    {
        public CodeProdigeeContext(DbContextOptions<CodeProdigeeContext> options) : base(options)
        {

        }

        public CodeProdigeeContext()
        {

        }
    }
}
