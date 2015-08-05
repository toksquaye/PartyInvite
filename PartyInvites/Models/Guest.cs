using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class Guest
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
    }

    //maps entity to user table in database
    public class GuestMap : ClassMapping<Guest>
    {
        public GuestMap()
        {
            Table("guests"); //tablename
            Id(x => x.Id, x => x.Generator(Generators.Identity)); //primary key
            Property(x => x.Name, x => x.NotNullable(true));
            Property(x => x.Email, x => x.NotNullable(true));
        }
    }
}