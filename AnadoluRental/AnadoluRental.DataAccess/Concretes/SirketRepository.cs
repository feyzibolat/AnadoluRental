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
    public class SirketRepository : IRepository<Sirket>, IDisposable
    {
        private string _connectionString;
        private string _dbProviderName;
        private DbProviderFactory _dbProviderFactory;
        private int _rowsAffected, _errorCode;
        private bool _bDisposed;

        public SirketRepository()
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
                query.Append("FROM [dbo].[Sirket] ");
                query.Append("WHERE ");
                query.Append("[sirketID] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [Sirket] can't be null. ");

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
                                "Deleting Error for entity [Sirket] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //sonuclari getirir
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("SirketRepository::Insert:Error occured.", ex);
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

        public bool Insert(Sirket entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append("INSERT [dbo].[Sirket] ");
                query.Append(" ( [sirketAdi], [sirketSehir], [sirketAdres], [sirketAracSayisi], [sirketPuani] ) ");
                query.Append("VALUES ");
                query.Append(
                    "( @sirketAdi, @sirketSehir, @sirketAdres, @sirketAracSayisi, @sirketPuani ) ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Sirket] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@sirketAdi", CsType.String, ParameterDirection.Input, entity.sirketAdi);
                        DBHelper.AddParameter(dbCommand, "@sirketSehir", CsType.String, ParameterDirection.Input, entity.sirketSehir);
                        DBHelper.AddParameter(dbCommand, "@sirketAdres", CsType.String, ParameterDirection.Input, entity.sirketAdres);
                        DBHelper.AddParameter(dbCommand, "@sirketAracSayisi", CsType.Int, ParameterDirection.Input, entity.sirketAracSayisi);
                        DBHelper.AddParameter(dbCommand, "@sirketPuani", CsType.Int, ParameterDirection.Input, entity.sirketPuani);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Inserting Error for entity [Sirket] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("SirketRepository::Insert:Error occured.", ex);
            }
        }

        public IList<Sirket> SelectAll()
        {
            _errorCode = 0;
            _rowsAffected = 0;

            IList<Sirket> sirketListesi = new List<Sirket>();

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[sirketID], [sirketAdi], [sirketSehir], [sirketAdres], [sirketAracSayisi], [sirketPuani] ");
                query.Append("FROM [dbo].[Sirket] ");
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
                                "dbCommand" + " The db SelectById command for entity [Sirket] can't be null. ");

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
                                    var entity = new Sirket();
                                    entity.sirketID = reader.GetInt32(0);
                                    entity.sirketAdi = reader.GetString(1);
                                    entity.sirketSehir = reader.GetString(2);
                                    entity.sirketAdres = reader.GetString(3);
                                    entity.sirketAracSayisi = reader.GetInt32(4);
                                    entity.sirketPuani = reader.GetInt32(5);

                                    entity.Arac = new AracRepository().SelectAll().Where(arac => arac.aitOlduguSirketID.Equals(entity.sirketID)).ToList();
                                    foreach (Arac temp in entity.Arac)
                                    {
                                        temp.Sirket = null;
                                        temp.Kiralik = null;
                                    }

                                    sirketListesi.Add(entity);
                                }
                            }

                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting All Error for entity [Sirket] reported the Database ErrorCode: " + _errorCode);

                        }
                    }
                }
                // Return list
                return sirketListesi;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("SirketRepository::SelectAll:Error occured.", ex);
            }
        }

        public Sirket SelectedById(int id)
        {
            _errorCode = 0;
            _rowsAffected = 0;

            Sirket sirket = null;

            try
            {
                var query = new StringBuilder();
                query.Append("SELECT ");
                query.Append("[sirketID], [sirketAdi], [sirketSehir], [sirketAdres], [sirketAracSayisi], [sirketPuani] ");
                query.Append("FROM [dbo].[Sirket] ");
                query.Append("WHERE ");
                query.Append("[sirketID] = @id ");
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
                                "dbCommand" + " The db SelectById command for entity [Sirket] can't be null. ");

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
                                    var entity = new Sirket();
                                    entity.sirketID = reader.GetInt32(0);
                                    entity.sirketAdi = reader.GetString(1);
                                    entity.sirketSehir = reader.GetString(2);
                                    entity.sirketAdres = reader.GetString(3);
                                    entity.sirketAracSayisi = reader.GetInt32(4);
                                    entity.sirketPuani = reader.GetInt32(5);

                                    //entity.Arac = new AracRepository().SelectAll().Where(arac => arac.aitOlduguSirketID.Equals(entity.sirketID)).ToList();
                                    //foreach (Arac temp in entity.Arac)
                                    //{
                                    //    temp.Sirket = null;
                                    //    temp.Kiralik = null;
                                    //}

                                    sirket = entity;
                                    break;
                                }
                            }
                        }

                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                        {
                            // Throw error.
                            throw new Exception("Selecting Error for entity [Sirket] reported the Database ErrorCode: " + _errorCode);
                        }
                    }
                }

                return sirket;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("SirketRepository::SelectById:Error occured.", ex);
            }
        }

        public bool Update(Sirket entity)
        {
            _rowsAffected = 0;
            _errorCode = 0;

            try
            {
                var query = new StringBuilder();
                query.Append(" UPDATE [dbo].[Sirket] ");
                query.Append(" SET [sirketAdi] = @sirketAdi, [sirketSehir] = @sirketSehir, [sirketAdres] =  @sirketAdres, [sirketAracSayisi] = @sirketAracSayisi, [sirketPuani] = @sirketPuani ");
                query.Append(" WHERE ");
                query.Append(" [sirketID] = @sirketID ");
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
                            throw new ArgumentNullException("dbCommand" + " The db Insert command for entity [Sirket] can't be null. ");

                        dbCommand.Connection = dbConnection;
                        dbCommand.CommandText = commandText;

                        //Input Params
                        DBHelper.AddParameter(dbCommand, "@sirketID", CsType.Int, ParameterDirection.Input, entity.sirketID);
                        DBHelper.AddParameter(dbCommand, "@sirketAdi", CsType.String, ParameterDirection.Input, entity.sirketAdi);
                        DBHelper.AddParameter(dbCommand, "@sirketSehir", CsType.String, ParameterDirection.Input, entity.sirketSehir);
                        DBHelper.AddParameter(dbCommand, "@sirketAdres", CsType.String, ParameterDirection.Input, entity.sirketAdres);
                        DBHelper.AddParameter(dbCommand, "@sirketAracSayisi", CsType.Int, ParameterDirection.Input, entity.sirketAracSayisi);
                        DBHelper.AddParameter(dbCommand, "@sirketPuani", CsType.Int, ParameterDirection.Input, entity.sirketPuani);

                        //Output Params
                        DBHelper.AddParameter(dbCommand, "@intErrorCode", CsType.Int, ParameterDirection.Output, null);

                        //Open Connection
                        if (dbConnection.State != ConnectionState.Open)
                            dbConnection.Open();

                        //Execute query
                        _rowsAffected = dbCommand.ExecuteNonQuery();
                        _errorCode = int.Parse(dbCommand.Parameters["@intErrorCode"].Value.ToString());

                        if (_errorCode != 0)
                            throw new Exception("Updating Error for entity [Sirket] reported the Database ErrorCode: " + _errorCode);
                    }
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("SirketRepository::Update:Error occured.", ex);
            }
        }
    }
}
