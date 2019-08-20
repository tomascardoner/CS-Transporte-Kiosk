using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    public class Empresa
    {
        #region Entity definition properties

        private const string EntityDBName = "Empresa";

        private const string EntityFieldNameIdEmpresa = "IDEmpresa";
        private const string EntityFieldNameCodigo = "Codigo";
        private const string EntityFieldNameNombre = "Nombre";
        private const string EntityFieldNameDatabaseName = "DatabaseName";
        private const string EntityFieldNameActivo = "Activo";

        private const bool EntityDisplayNameIsFemale = true;
        private const string EntityDisplayName = "Empresa";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        public Empresa()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Object private properties

        private byte _IdEmpresa;
        private string _Codigo;
        private string _Nombre;
        private string _DatabaseName;
        private bool _Activo;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdEmpresa { get => _IdEmpresa; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string DatabaseName { get => _DatabaseName; set => _DatabaseName = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Related entities

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, byte idEmpresa)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Empresa_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDEmpresa", idEmpresa);

                Cursor.Current = Cursors.Default;
                return CargarEjecutar(command, EntityLoadErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadErrorMessage);
                return false;
            }
        }

        private bool CargarEjecutar(SqlCommand command, string errorMessage)
        {
            try
            {
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader(CommandBehavior.SingleRow);
                command.Dispose();
                command = null;

                _IsFound = dataReader.HasRows;

                if (IsFound)
                {
                    dataReader.Read();

                    if (CargarPropiedades(dataReader))
                    {
                        dataReader.Close();
                        dataReader = null;
                        return true;
                    }
                    else
                    {
                        dataReader.Close();
                        dataReader = null;
                        return false;
                    }
                }
                else
                {
                    dataReader.Close();
                    dataReader = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, errorMessage);
                return false;
            }
        }

        private bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                _IdEmpresa = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdEmpresa);
                _Codigo = SQLServer.DataReaderGetString(dataReader, EntityFieldNameCodigo);
                _Nombre = SQLServer.DataReaderGetString(dataReader, EntityFieldNameNombre);
                _DatabaseName = SQLServer.DataReaderGetStringSafeAsEmpty(dataReader, EntityFieldNameDatabaseName);
                _Activo = SQLServer.DataReaderGetBoolean(dataReader, EntityFieldNameActivo);
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        #endregion

    }
}