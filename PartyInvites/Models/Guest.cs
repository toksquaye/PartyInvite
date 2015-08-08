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
        public virtual string PasswordHash { get; set; }
        public virtual IList<RoleNames> Role { get; set; }
        public Guest()
        {
            Role = new List<RoleNames>() { };//initialize list to an empty one
        }
    }

    //maps entity to user table in database
    public class GuestMap : ClassMapping<Guest>
    {
        public GuestMap()
        {
            Table("guests"); //tablename
            Id(x => x.Id, x => x.Generator(Generators.Identity)); //primary key
            Property(x => x.Name, x => x.NotNullable(true));
            Property(x => x.PasswordHash, x =>
                {
                    x.Column("password_hash"); //this maps PasswordHash to password_hash
                    x.NotNullable(true);
                });

            Property(x => x.Email, x => x.NotNullable(true));

            Bag(x => x.Role, x =>
                {
                    x.Table("guests_role");
                    x.Key(k => k.Column("guest_id"));
                }, x => x.ManyToMany(k => k.Column("role_id")));
        }
    }
}