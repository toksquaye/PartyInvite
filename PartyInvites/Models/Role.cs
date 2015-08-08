using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class RoleNames
    {
        public virtual int Id { get; set; }
        public virtual string Role { get; set; }
    }

    public class RoleMap : ClassMapping<RoleNames>
    {
        public RoleMap()
        {
            Table("roles"); //table this this entity maps to
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.Role, x => x.NotNullable(true));
        }
    }
}