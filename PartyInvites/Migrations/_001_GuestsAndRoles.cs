using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PartyInvites.Migrations
{
    [Migration(1)]
    public class _001_GuestsAndRoles : Migration
    {
        public override void Down()
        {
            Delete.Table("guests_role");
            Delete.Table("guests");
            Delete.Table("roles");
        }

        public override void Up()
        {
            Create.Table("guests")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128)
                .WithColumn("password_hash").AsString(128)
                .WithColumn("email").AsCustom("VARCHAR(256)");
                
            Create.Table("roles")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("role").AsString(128);

            Create.Table("guests_role")
                .WithColumn("guest_id").AsInt32().ForeignKey("guests", "id").OnDelete(Rule.Cascade)
                .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(Rule.Cascade);
        }
    }
}