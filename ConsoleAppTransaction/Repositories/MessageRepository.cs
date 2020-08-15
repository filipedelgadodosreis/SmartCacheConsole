using ConsoleAppTransaction.Models;
using System;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace ConsoleAppTransaction.Repositories
{
    public delegate void NewMessageHandler(Message message);

#pragma warning disable S3881 // "IDisposable" should be implemented correctly
    public class MessageRepository : IDisposable
#pragma warning restore S3881 // "IDisposable" should be implemented correctly
    {
        private SqlTableDependency<Message> sqlTableDependency;

        public void Start(string connectionString)
        {
            sqlTableDependency = new SqlTableDependency<Message>(connectionString, "Messages", "dbo");
            sqlTableDependency.OnChanged += HandleOnChanged;
            sqlTableDependency.Start();
        }

        public event NewMessageHandler OnNewMessage;
        private void HandleOnChanged(object sender, RecordChangedEventArgs<Message> e)
        {
            if (e.ChangeType == TableDependency.SqlClient.Base.Enums.ChangeType.Insert)
            {
                OnNewMessage?.Invoke(e.Entity);
            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && sqlTableDependency != null)
                {
                    sqlTableDependency.Stop();
                    sqlTableDependency.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
