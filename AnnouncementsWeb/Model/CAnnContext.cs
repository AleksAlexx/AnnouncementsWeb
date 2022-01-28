using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementsWeb.Model
{
    public class CAnnContext : Microsoft.EntityFrameworkCore.DbContext
    {
        /*public CAnnContext() : base("name=CAnnContext")
        {

        }*/
        public CAnnContext(DbContextOptions<CAnnContext> options) : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<CAnnouncement> CAnnouncements { get; set; }
    }
}
