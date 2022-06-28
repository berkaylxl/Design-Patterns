using System;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreaterFactory create = new CreaterFactory(new MysqlDatabase());
        }
        public class CreaterFactory
        {
            DatabaseFactory _databaseFactory;
            Connection _connection;
            Command _command;
            public CreaterFactory(DatabaseFactory databaseFactory)
            {
                _databaseFactory = databaseFactory;
                _command = _databaseFactory.CreateCommand();
                _connection = _databaseFactory.CreateConnection();
                Execute();
            }

            public void Execute()
            {
                _command.Execute();
                _connection.Connect();
            }
        }

        public abstract class Connection
        { 
         public abstract void  Connect();
        }
        public abstract class Command
        {
           public  abstract void Execute();
        }

        public  class SqlConnection : Connection
        {
            public override void Connect()
            {
                Console.WriteLine("Sql bağlantısı açıldı");
            }
        }
        public class SqlCommand: Command
        {
            public override void Execute()
            {
                Console.WriteLine("SQl Sorgu çalıştırıldı");
            }
        }
        public  class MysqlConnection : Connection
        {
           public override void Connect()
            {
                Console.WriteLine("Mysql bağlantısı açıldı");
            }
        }
        public class MysqlCommand: Command
        {
            public override void Execute()
            {
                Console.WriteLine("Mysql sorgusu çalıştırıldı");
            }
        }
        public abstract class DatabaseFactory
        {
            public abstract Connection CreateConnection();
            public abstract Command CreateCommand();
        }
        public class MysqlDatabase : DatabaseFactory
        {
            public override Command CreateCommand()
            {
                return new MysqlCommand();
            }

            public override Connection CreateConnection()
            {
                return new MysqlConnection();
            }
        }
        public class SqlDatabase : DatabaseFactory
        {
            public override Command CreateCommand()
            {
                return new SqlCommand();
            }

            public override Connection CreateConnection()
            {
                return new SqlConnection();
            }
        }
    }
}
