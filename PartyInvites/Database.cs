using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites
{
    public class Database
    {
        //this allows session object to be exposed to code for controller to use
        public static ISession Session
        {
            get { return (ISession)HttpContext.Current.Items[SessionKey]; }
        }

        //unique identifier for current session
        private const string SessionKey = "PartyInvites.Database.SessionKey";
        private static ISessionFactory _sessionFactory;

        public static void Configure()
        {//configure database using nhibernate 
            var config = new Configuration();

            //configure the connection string
            //picks up settings from webconfig as default behavior
            config.Configure();

            //add mappings for Nhibernate
            var mapper = new ModelMapper();
            mapper.AddMapping<GuestMap>();

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            //create session factory
            _sessionFactory = config.BuildSessionFactory();

        }

        public static void OpenSession()
        {
            //open session to database
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {
            //ISession used by NHibernate to represent a session
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
                session.Close(); //close session to database

            HttpContext.Current.Items.Remove(SessionKey);//remove current session key from item array


        }
    }
}