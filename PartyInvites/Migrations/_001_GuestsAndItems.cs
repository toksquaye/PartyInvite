using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PartyInvites.Migrations
{
    [Migration(1)]
    public class _001_GuestsAndItems : Migration
    {
        public override void Down()
        {
            Delete.Table("guests_item");
            Delete.Table("guests");
            Delete.Table("items");
        }

        public override void Up()
        {
            Create.Table("guests")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128)
                .WithColumn("email").AsCustom("VARCHAR(256)");
                
            Create.Table("items")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128);

            Create.Table("guests_item")
                .WithColumn("guest_id").AsInt32().ForeignKey("guests", "id").OnDelete(Rule.Cascade)
                .WithColumn("item_id").AsInt32().ForeignKey("items", "id").OnDelete(Rule.Cascade);
        }
    }
}