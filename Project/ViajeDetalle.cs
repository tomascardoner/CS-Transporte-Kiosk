using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSTransporteKiosko
{
    class ViajeDetalle
    {
        public bool RealizarCheckIn(SqlConnection connection, byte idEmpresa, int idViajeDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand command = new SqlCommand("usp_ViajeDetalle_RealizarCheckIn", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDEmpresa", idEmpresa);
                command.Parameters.AddWithValue("@IDViajeDetalle", idViajeDetalle);

                command.ExecuteNonQuery();

                command.Dispose();
                command = null;

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CardonerSistemas.Error.ProcessError(ex, "Error al hacer el check-in de la Reserva.");
                return false;
            }
        }
    }
}
