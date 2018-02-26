using Bible2PPT.Bibles;
using Microsoft.Database.Isam;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Bible2PPT
{
    class BibleDb : IDisposable
    {
        public IsamInstance Instance = new IsamInstance(null);

        public IsamSession Session;
        public IsamDatabase Database;

        public IsamTransaction Transaction => new IsamTransaction(Session);

        public Cursor Bibles => Database.OpenCursor(typeof(Bible).Name);
        public Cursor Books => Database.OpenCursor(typeof(BibleBook).Name);
        public Cursor Chapters => Database.OpenCursor(typeof(BibleChapter).Name);
        public Cursor Verses => Database.OpenCursor(typeof(BibleVerse).Name);

        public BibleDb()
        {
            Session = Instance.CreateSession();

            if (Session.Exists(AppConfig.DatabasePath))
            {
                Session.AttachDatabase(AppConfig.DatabasePath);
            }
            else
            {
                Session.CreateDatabase(AppConfig.DatabasePath);
            }

            Database = Session.OpenDatabase(AppConfig.DatabasePath);

            InitializeTable(typeof(Bible));
            InitializeTable(typeof(BibleBook));
            InitializeTable(typeof(BibleChapter));
            InitializeTable(typeof(BibleVerse));
        }

        public static T MapEntity<T>(FieldCollection record) where T : new()
        {
            var entity = new T();
            foreach (var field in record)
            {
                typeof(T).GetProperty(field.Name).SetValue(entity, field[0], null);
            }
            return entity;
        }

        public static void MapEntity<T>(Cursor cursor, T entity)
        {
            foreach (var property in GetStorableProperties(typeof(T)))
            {
                cursor.EditRecord[property.Name] = property.GetValue(entity, null);
            }
        }

        private bool IsMetadataHealthy(Type type)
        {
            using (var cursor = Database.OpenCursor(type.Name))
            {
                var columns = cursor.TableDefinition.Columns.Cast<ColumnDefinition>();
                return !GetStorableProperties(type).Select(i => i.Name).Except(columns.Select(i => i.Name)).Any();
            }
        }

        private static IEnumerable<PropertyInfo> GetStorableProperties(Type type) =>
            type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => !Attribute.IsDefined(p, typeof(IgnoreDataMemberAttribute)))
                .Where(p => p.GetGetMethod(true)?.IsPublic == true)
                .Where(p => p.GetSetMethod(true)?.IsPublic == true);

        public void InitializeTable(Type type)
        {
            using (var tx = new IsamTransaction(Session))
            {
                if (Database.Exists(type.Name))
                {
                    if (IsMetadataHealthy(type))
                    {
                        return;
                    }

                    Database.DropTable(type.Name);
                }

                var table = new TableDefinition(type.Name);
                foreach (var property in GetStorableProperties(type))
                {
                    table.Columns.Add(new ColumnDefinition(property.Name)
                    {
                        Type = property.PropertyType,
                    });
                }

                Database.CreateTable(table);

                tx.Commit();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Database.Dispose();
                    Session.Dispose();
                    Instance.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BibleDb() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
