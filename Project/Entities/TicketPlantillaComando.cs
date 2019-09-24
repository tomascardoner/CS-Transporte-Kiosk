using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CardonerSistemas.Database.ADO;

namespace CSTransporteKiosko
{
    public class TicketPlantillaComando
    {

        #region Entity definition properties

        private const string EntityDBName = "TicketPlantillaComando";

        private const string EntityFieldNameIdTicketPlantilla = "IDTicketPlantilla";
        private const string EntityFieldNameIdComando = "IDComando";
        private const string EntityFieldNameTexto = "Texto";
        private const string EntityFieldNameIdImagen = "IDImagen";
        private const string EntityFieldNameImagenAncho = "ImagenAncho";
        private const string EntityFieldNameImagenPosicion = "ImagenPosicion";
        private const string EntityFieldNameImagenData = "ImagenData";

        private const bool EntityDisplayNameIsFemale = false;
        private const string EntityDisplayName = "Comando de Plantilla de Ticket";

        private string EntityLoadErrorMessage;
        private string EntityLoadPropertiesErrorMessage;

        public TicketPlantillaComando()
        {
            EntityLoadErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
            EntityLoadPropertiesErrorMessage = CardonerSistemas.Database.Framework.Lite.GetEntityLoadPropertiesErrorMessage(EntityDisplayName, EntityDisplayNameIsFemale);
        }

        private const string FieldDelimiterStartChar = "@";
        private const string FieldDelimiterEndChar = "@";

        #endregion

        #region Object private properties

        private byte _IdTicketPlantilla;
        private byte _IdComando;
        private string _Texto;
        private short? _IdImagen;
        private Stream _ImagenData;
        private short? _ImagenAncho;
        private short? _ImagenPosicion;

        private bool _IsFound = false;

        #endregion

        #region Object public properties

        public byte IdTicketPlantilla { get => _IdTicketPlantilla; }
        public byte IdComando { get => _IdComando; }
        public string Texto { get => _Texto; set => _Texto = value; }
        public short? IdImagen { get => _IdImagen; set => _IdImagen = value; }
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
        public short? ImagenAncho { get => _ImagenAncho; set => _ImagenAncho = value; }
        public short? ImagenPosicion { get => _ImagenPosicion; set => _ImagenPosicion = value; }

        public bool IsFound { get => _IsFound; }

        #endregion

        #region Related entities

        private Imagen _Imagen;

        public bool ImagenCargar(SqlConnection connection)
        {
            if (_IdImagen.HasValue)
            {
                _Imagen = new Imagen();
                if (_Imagen.CargarPorID(connection, _IdImagen.Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Imagen Imagen { get => _Imagen; }

        #endregion

        #region Load data from database

        public bool CargarPorID(SqlConnection connection, byte idTicketPlantilla, string idComando)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_TicketPlantillaComando_ObtenerPorID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDTicketPlantilla", idTicketPlantilla);
                command.Parameters.AddWithValue("@IDComando", idComando);

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

        public bool CargarPropiedades(SqlDataReader dataReader)
        {
            try
            {
                _IdTicketPlantilla = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdTicketPlantilla);
                _IdComando = SQLServer.DataReaderGetByte(dataReader, EntityFieldNameIdComando);
                _Texto = SQLServer.DataReaderGetStringSafeAsNull(dataReader, EntityFieldNameTexto);
                _IdImagen = SQLServer.DataReaderGetShortSafeAsNull(dataReader, EntityFieldNameIdImagen);
                _ImagenData = SQLServer.DataReaderGetStream(dataReader, EntityFieldNameImagenData);
                _ImagenAncho = SQLServer.DataReaderGetShortSafeAsNull(dataReader, EntityFieldNameImagenAncho);
                _ImagenPosicion = SQLServer.DataReaderGetShortSafeAsNull(dataReader, EntityFieldNameImagenPosicion);
                
                return true;
            }
            catch (Exception ex)
            {
                CardonerSistemas.Error.ProcessError(ex, EntityLoadPropertiesErrorMessage);
                return false;
            }
        }

        #endregion

        #region Other methods

        public string GetTextReplacedWithFields(BusquedaReservas.Persona persona)
        {
            string replacedText = _Texto;
            replacedText = replacedText.Replace("LugarGrupoOrigen", persona.LugarGrupoOrigen);
            replacedText = replacedText.Replace("FechaHoraOrigen", persona.FechaHoraOrigen.ToShortDateString() + " " + persona.FechaHoraOrigen.ToShortDateString());
            replacedText = replacedText.Replace("FechaOrigen", persona.FechaHoraOrigen.ToShortDateString());
            replacedText = replacedText.Replace("HoraOrigen", persona.FechaHoraOrigen.ToShortTimeString());

            replacedText = replacedText.Replace("LugarGrupoDestino", persona.LugarGrupoDestino);
            replacedText = replacedText.Replace("FechaHoraDestino", persona.FechaHoraDestino.ToShortDateString() + " " + persona.FechaHoraDestino.ToShortDateString());
            replacedText = replacedText.Replace("FechaDestino", persona.FechaHoraDestino.ToShortDateString());
            replacedText = replacedText.Replace("HoraDestino", persona.FechaHoraDestino.ToShortTimeString());

            replacedText = replacedText.Replace("Vehiculo", persona.VehiculoNombre);

            replacedText = replacedText.Replace("ApellidoNombre", persona.ApellidoNombre);
            replacedText = replacedText.Replace("Apellido", persona.Apellido);
            replacedText = replacedText.Replace("Nombre", persona.Nombre);

            return replacedText;
        }

        private string ReplaceField(string textoComando, string fieldName, string valor)
        {
            string textoParaReemplazar = String.Format("{0}{1}{2}", FieldDelimiterStartChar, fieldName, FieldDelimiterEndChar);
            return textoComando.Replace(textoParaReemplazar, valor);
        }

        #endregion

    }
}