import { useEffect, useState } from "react";
import { getTiposContrato } from "../services/tipoContratoService";

function TipoContrato() {

  const [tipos, setTipos] = useState([]);

  useEffect(() => {
    cargarTipos();
  }, []);

    const cargarTipos = async () => {
    const data = await getTiposContrato();
    console.log(data);
    setTipos(data);
  };

  return (
    <div>
      <h1>Tipos de Contrato</h1>

      <ul>
        {tipos.map(t => (
          <li key={t.id}>{t.nombre}</li>
        ))}
      </ul>

    </div>
  );
}

export default TipoContrato;
