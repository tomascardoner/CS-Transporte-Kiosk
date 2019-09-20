using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    public class Imagen
    {
        #region Entity definition properties

        private const string EntityDBName = "Imagen";

        private const string EntityFieldNameIdImagen = "IDImagen";
        private const string EntityFieldNameNombre = "Nombre";
        private const string EntityFieldNameImagenData = "ImagenData";

        private const bool EntityDisplayNameIsFemale = true;
        private const string EntityDisplayName = "Imagen";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        public Imagen()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        #endregion

        #region Object private properties

        private short _IdImagen;
        private string _Nombre;
        private Stream _ImagenData;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public short IdImagen { get => _IdImagen; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public Stream ImagenData { get => _ImagenData; }
        public Image ImagenDataAsBitmap
        {
            get
            {
                try
                {
                    return Bitmap.FromStream(_ImagenData);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, short idImagen)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Imagen_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDImagen", idImagen);

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
                _IdImagen = SQLServer.DataReaderGetShort(dataReader, EntityFieldNameIdImagen);
                _Nombre = SQLServer.DataReaderGetString(dataReader, EntityFieldNameNombre);
                _ImagenData = SQLServer.DataReaderGetStream(dataReader, EntityFieldNameImagenData);
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
