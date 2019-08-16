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

        private string EntityLoadByIdErrorMessage = String.Format("Error al cargar {0} {1} por Id.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);
        private string EntityLoadPropertiesErrorMessage = String.Format("Error al cargar las propiedades de {0} {1}.", EntityDisplayNameIsFemale ? " la " : " el ", EntityDisplayName);

        #endregion

        #region Object private properties

        private short _IdImagen;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public short IdImagen { get => _IdImagen; }
        public string Nombre { get; set; }
        public Stream ImagenData { get; set; }
        public Image ImagenDataAsBitmap { get => Bitmap.FromStream(ImagenData); }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Carga de datos desde la base

        public bool CargarPorID(SqlConnection connection, short idImagen)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_Imagen_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDImagen", idImagen);

                Cursor.Current = Cursors.Default;
                return CargarComun(command, EntityLoadByIdErrorMessage);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, EntityLoadByIdErrorMessage);
                return false;
            }
        }

        private bool CargarComun(SqlCommand command, string errorMessage)
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
                Nombre = SQLServer.DataReaderGetString(dataReader, EntityFieldNameNombre);
                ImagenData = SQLServer.DataReaderGetStream(dataReader, EntityFieldNameImagenData);
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
