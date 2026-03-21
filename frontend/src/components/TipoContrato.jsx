import { useEffect, useState } from "react";
import TipoContratoForm from "./TipoContratoForm";
import TipoContratoTable from "./TipoContratoTable";

import {
  getTiposContrato,
  createTipoContrato,
  updateTipoContrato,
  deleteTipoContrato,
} from "../services/tipoContratoService";

function TipoContrato() {
  const [data, setData] = useState([]);
  const [nombre, setNombre] = useState("");
  const [editando, setEditando] = useState(null);

  const cargar = async () => {
    const res = await getTiposContrato();
    setData(res);
  };

  useEffect(() => {
    cargar();
  }, []);

  const handleSubmit = async () => {
    if (!nombre) return;

    if (editando) {
      await updateTipoContrato({ id: editando.id, nombre });
      setEditando(null);
    } else {
      await createTipoContrato({ nombre });
    }

    setNombre("");
    cargar();
  };

  const handleEdit = (item) => {
    setEditando(item);
    setNombre(item.nombre);
  };

  const handleDelete = async (id) => {
    await deleteTipoContrato(id);
    cargar();
  };

  return (
    <div>
      <TipoContratoForm
        nombre={nombre}
        setNombre={setNombre}
        onSubmit={handleSubmit}
      />

      <TipoContratoTable
        data={data}
        onEdit={handleEdit}
        onDelete={handleDelete}
      />
    </div>
  );
}

export default TipoContrato;