import { useEffect, useState } from "react";
import { getMotivos, deleteMotivo, createMotivo, updateMotivo } from "./services/motivoVisitaService";

import MotivoVisitaTable from "./components/MotivoVisitaTable";
import MotivoVisitaForm from "./components/MotivoVisitaForm";
import TipoContrato from "./components/TipoContrato";


function App() {

  const [motivos, setMotivos] = useState([]);
  const [motivoEditando, setMotivoEditando] = useState(null);

  const cargarMotivos = async () => {
    const data = await getMotivos();
    setMotivos(data.data);
  };

  useEffect(() => {
    cargarMotivos();
  }, []);

  const handleDelete = async (id) => {
    await deleteMotivo(id);
    cargarMotivos();
  };

  const handleCreate = async (motivo) => {
    await createMotivo(motivo);
    cargarMotivos();
  };

  const handleUpdate = async (motivo) => {
    await updateMotivo(motivo);
    setMotivoEditando(null);
    cargarMotivos();
  };

  const handleEdit = (motivo) => {
    setMotivoEditando(motivo);
  };

  return (
    <div style={{ padding: "40px" }}>

      <h1>Motivos de Visita</h1>

      <MotivoVisitaForm
        onCreate={handleCreate}
        onUpdate={handleUpdate}
        motivoEditando={motivoEditando}
      />

      <MotivoVisitaTable
        motivos={motivos}
        onDelete={handleDelete}
        onEdit={handleEdit}
      />
      <TipoContrato />
      
    </div>
    
  );
}

export default App;