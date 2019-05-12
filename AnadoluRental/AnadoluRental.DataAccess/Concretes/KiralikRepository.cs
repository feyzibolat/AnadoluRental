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
    public class KiralikRepository : IRepository<Kiralik>, IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public KiralikRepository()
        {
            _connectionString = DBHelper.GetConnectionString();
            _dbProviderName = DBHelper.GetConnectionProvider();
            _dbProviderFactory = DbProviderFactories.GetFactory(_dbProviderName);
        }

        public bool DeletedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("DELETE ");
                query.Append("FROM [dbo].[Kiralik] ");
                query.Append("WHERE ");
                query.Append("[kiraID] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [Kiralik] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters
                        DBHelper.AddParameter(dbCommand, "@id", CsType.Int, ParameterDirection.Input, id);

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();
                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception(
                                "Deleting Error for entity [Kiralik] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //sonuclari getirir
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KiralikRepository::Insert:Error occured.", ex);
            }
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

        public bool Insert(Kiralik entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[Kiralik] ");
                query.Append(" ( [kiralananAracID], [kiraTarihi], [verilisKM], [kiraBitisKM], [kiraAlinanUcret], [kiralayanKulID] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @kiralananAracID, @kiraTarihi, @verilisKM, @kiraBitisKM, @kiraAlinanUcret, @kiralayanKulID ) ");
                query.Append("SELECT @intErrorCode=@@ERROR;");

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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Kiralik] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@kiralananAracID", CsType.Int, ParameterDirection.Input, entity.kiralananAracID);
                        DBHelper.AddParameter(dbCommand, "@kiraTarihi", CsType.DateTime, ParameterDirection.Input, entity.kiraTarihi);
                        DBHelper.AddParameter(dbCommand, "@verilisKM", CsType.Int, ParameterDirection.Input, entity.verilisKM);
                        DBHelper.AddParameter(dbCommand, "@kiraBitisKM", CsType.Int, ParameterDirection.Input, entity.kiraBitisKM);
                        DBHelper.AddParameter(dbCommand, "@kiraAlinanUcret", CsType.Int, ParameterDirection.Input, entity.kiraAlinanUcret);
                        DBHelper.AddParameter(dbCommand, "@kiralayanKulID", CsType.Int, ParameterDirection.Input, entity.kiralayanKulID);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [Kiralik] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KiralikRepository::Insert:Error occured.", ex);
            }
        }

        public IList<Kiralik> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Kiralik> kiralananListesi = new List<Kiralik>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[kiraID], [kiralananAracID], [kiraTarihi], [verilisKM], [kiraBitisKM], [kiraAlinanUcret], [kiralayanKulID] ");
                query.Append("FROM [dbo].[Kiralik] ");
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
                                "dbCommand" + " The db SelectById command for entity [Kiralik] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Parameters - None

                        //Output Parameters
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int,
                            ParameterDirection.Output, null);

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
                                    var entity = new Kiralik();
                                    entity.kiraID = reader.GetInt32(0);
                                    entity.kiralananAracID = reader.GetInt32(1);
                                    entity.kiraTarihi = reader.GetDateTime(2);
                                    entity.verilisKM = reader.GetInt32(3);
                                    entity.kiraBitisKM = reader.GetInt32(4);
                                    entity.kiraAlinanUcret = reader.GetInt32(5);
                                    entity.kiralayanKulID = reader.GetInt32(6);
                                    kiralananListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Kiralik] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return kiralananListesi;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KiralikRepository::SelectAll:Error occured.", ex);
            }
        }

        public Kiralik SelectedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Kiralik kiralik = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[kiraID], [kiralananAracID], [kiraTarihi], [verilisKM], [kiraBitisKM], [kiraAlinanUcret], [kiralayanKulID] ");
                query.Append("FROM [dbo].[Kiralik] ");
                query.Append("WHERE ");
                query.Append("[kiraID] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [Kiralik] can't be null. ");

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
                                    var entity = new Kiralik();
                                    entity.kiraID = reader.GetInt32(0);
                                    entity.kiralananAracID = reader.GetInt32(1);
                                    entity.kiraTarihi = reader.GetDateTime(2);
                                    entity.verilisKM = reader.GetInt32(3);
                                    entity.kiraBitisKM = reader.GetInt32(4);
                                    entity.kiraAlinanUcret = reader.GetInt32(5);
                                    entity.kiralayanKulID = reader.GetInt32(6);
                                    kiralik = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Kiralik] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                //Aracin kiralama geçmişi
                //kiralik.Kiralik = new KiralikRepository().SelectAll().Where(x => x.TransactorAccountNumber.Equals(customer.CustomerID) || x.ReceiverAccountNumber.Equals(customer.CustomerID)).ToList();
                return kiralik;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KiralikRepository::SelectById:Error occured.", ex);
            }
        }

        public bool Update(Kiralik entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[Kiralik] ");
                query.Append(" SET [kiralananAracID] = @kiralananAracID, [kiraTarihi] = @kiraTarihi, [verilisKM] =  @verilisKM, [kiraBitisKM] = @kiraBitisKM, [kiraAlinanUcret] = @kiraAlinanUcret, [kiralayanKulID] = @kiralayanKulID ");
                query.Append(" WHERE ");
                query.Append(" [kiraID] = @kiraID ");
                query.Append(" SELECT @intErrorCode = @@ERROR; ");

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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Kiralik] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@kiraID", CsType.Int, ParameterDirection.Input, entity.kiraID);
                        DBHelper.AddParameter(dbCommand, "@kiralananAracID", CsType.Int, ParameterDirection.Input, entity.kiralananAracID);
                        DBHelper.AddParameter(dbCommand, "@kiraTarihi", CsType.DateTime, ParameterDirection.Input, entity.kiraTarihi);
                        DBHelper.AddParameter(dbCommand, "@verilisKM", CsType.Int, ParameterDirection.Input, entity.verilisKM);
                        DBHelper.AddParameter(dbCommand, "@kiraBitisKM", CsType.Int, ParameterDirection.Input, entity.kiraBitisKM);
                        DBHelper.AddParameter(dbCommand, "@kiraAlinanUcret", CsType.Int, ParameterDirection.Input, entity.kiraAlinanUcret);
                        DBHelper.AddParameter(dbCommand, "@kiralayanKulID", CsType.Int, ParameterDirection.Input, entity.kiralayanKulID);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [Kiralik] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("KiralikRepository::Update:Error occured.", ex);
            }
        }
    }
}
