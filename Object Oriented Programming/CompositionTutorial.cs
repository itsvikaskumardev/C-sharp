using System;

namespace Object_Oriented_Programming
{
    // Logger class : It is just a helper class.
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    // DbMigrator uses Logger
    public class DbMigrator
    {
        private readonly Logger _logger;
        /*
         private readonly Logger _logger;
          │        │        │      │
          │        │        │      └── Field name
          │        │        └──────── Data type
          │        └───────────────── Cannot be changed after construction
          └────────────────────────── Accessible only inside this class*/

        public DbMigrator(Logger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.Log("Database migration started...");
            _logger.Log("Database migration completed.");
        }
    }

    // Installer also uses Logger
    public class Installer
    {
        private readonly Logger _logger;

        public Installer(Logger logger)
        {
            _logger = logger;
        }

        public void Install()
        {
            _logger.Log("Application installation started...");
            _logger.Log("Application installation completed.");
        }
    }

    internal class CompositionTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Composition ----------------");

            Logger logger = new Logger();

            DbMigrator dbMigrator = new DbMigrator(logger);
            Installer installer = new Installer(logger);

            dbMigrator.Migrate();
            installer.Install();
        }
    }
}

/*
     
 Composition:One class contains or uses another class instead of inheriting from it. 
 For example:
Logger is just a helper class.

An Installer is not a Logger.
A DbMigrator is not a Logger.
Both use a Logger object to write messages.

Why not use inheritance?

Could we do this?
class Installer : Logger
No, because:

An Installer is not a Logger.
Similarly:
class DbMigrator : Logger
is also incorrect because:

A DbMigrator is not a Logger.


Instead:

Installer has a Logger.
DbMigrator has a Logger.

This is the key difference:

Inheritance → is-a relationship.
A Student is a Person.

Composition → has-a relationship.
An Installer has a Logger.
A DbMigrator has a Logger.


Easy way to remember

Inheritance = is-a
Student is a Person
Car is a Vehicle

Composition = has-a
Car has an Engine
Computer has a CPU
Installer has a Logger
DbMigrator has a Logger




 */