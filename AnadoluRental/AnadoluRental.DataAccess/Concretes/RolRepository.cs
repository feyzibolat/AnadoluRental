using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnadoluRental.CrossCutting.Concretes.Data;
using AnadoluRental.CrossCutting.Concretes.Helper;
using AnadoluRental.CrossCutting.Concretes.Logger;
using AnadoluRental.DataAccess.Abstractions;
using AnadoluRental.Models.Models;

namespace AnadoluRental.DataAccess.Concretes
{
    public class RolRepository : IRepository<Rol>, IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public RolRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            // Check the Dispose method called before.
            if (!_bDisposed)
            {
                if (bDisposing)
                {
                    // Clean the resources used.
                    _dbProviderFactory = null;
                }

                _bDisposed = true;
            }
        }

        public Rol SelectedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Rol rol = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[rolID], [rolAdi] ");
                query.Append("FROM [dbo].[Rol] ");
                query.Append("WHERE ");
                query.Append("[rolID] = @id ");
                query.Append("SELECT @intErrorCode=@@ERROR; ");

                var commandText = query.ToString();
                query.Clear();

                using (var dbConnection = _dbProviderFactory.CreateConnection())
                {
                    if (dbConnection == null)
                        throw new ArgumentNullException("dbConnection", "The db connection can't be null.");

                    dbConnection.ConnectionString = _connectionString;

                    using (var dbCommand = _dbProviderFactory.CreateCommand())
                    {
                        if (dbCommand == null)
                            throw new ArgumentNullException(
                                "dbCommand" + " The db SelectById command for entity [Rol] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query.
                        using (var reader = dbCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var entity = new Rol();
                                    entity.rolID = reader.GetInt32(0);
                                    entity.rolAdi = reader.GetString(1);

                                    rol = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Rol] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return rol;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("RolRepository::SelectById:Error occured.", ex);
            }
        }

        public bool Insert(Rol entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rol entity)
        {
            throw new NotImplementedException();
        }

        public bool DeletedById(int id)
        {
            throw new NotImplementedException();
        }

        Rol IRepository<Rol>.SelectedById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Rol> SelectAll()
        {
            throw new NotImplementedException();
        }
    }
}
