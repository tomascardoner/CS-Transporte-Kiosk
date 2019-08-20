USE CSTransporte_DelSurBus
GO

GRANT SELECT ON DocumentoTipo TO cstransportekiosko
GRANT SELECT ON Lugar TO cstransportekiosko
GRANT SELECT ON LugarGrupo TO cstransportekiosko
GRANT SELECT ON Persona TO cstransportekiosko
GRANT SELECT ON RutaDetalle TO cstransportekiosko
GRANT SELECT ON Vehiculo TO cstransportekiosko
GRANT SELECT ON Viaje TO cstransportekiosko
GRANT SELECT, UPDATE ON ViajeDetalle TO cstransportekiosko
GO