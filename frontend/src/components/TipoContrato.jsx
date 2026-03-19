import { useEffect, useState } from "react";
import { 
  getTiposContrato, 
  createTipoContrato, 
  updateTipoContrato, 
  deleteTipoContrato 
} from "../services/tipoContratoService";

function TipoContrato() {

  const [tipos, setTipos] = useState([]);
  const [nombre, setNombre] = useState("");
  const [editando, setEditando] = useState(false);
  const [idEditando, setIdEditando] = useState(null);

  useEffect(() => {
    cargarTipos();
  }, []);

  const cargarTipos = async () => {
    const data = await getTiposContrato();
    setTipos(data);
  };

  const guardar = async () => {
    if (!nombre.trim()) return;

    if (editando) {
      await updateTipoContrato({
        id: idEditando,
        nombre: nombre
      });
    } else {
      await createTipoContrato({
        nombre: nombre
      });
    }

    setNombre("");
    setEditando(false);
    setIdEditando(null);

    cargarTipos();
  };

  const editar = (tipo) => {
    setNombre(tipo.nombre);
    setEditando(true);
    setIdEditando(tipo.id);
  };

  const eliminar = async (id) => {
    if (!confirm("¿Eliminar este tipo de contrato?")) return;

    await deleteTipoContrato(id);
    cargarTipos();
  };

  return (
    <div>
      <h1>Tipos de Contrato</h1>

        <div style={{ marginBottom: "10px" }}>
          <input
            type="text"
            placeholder="Nombre del contrato"
            value={nombre}
            onChange={(e) => setNombre(e.target.value)}
          />

          <button onClick={guardar}>
            {editando ? "Actualizar" : "Agregar"}
          </button>
        </div>

        <table border="1" cellPadding="8" style={{ width: "100%" }}>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nombre</th>
              <th>Acciones</th>
            </tr>
          </thead>

          <tbody>
            {tipos.map(t => (
              <tr key={t.id}>
                <td>{t.id}</td>
                <td>{t.nombre}</td>
                <td>
                  <button onClick={() => editar(t)}>Editar</button>
                  <button onClick={() => eliminar(t.id)}>Eliminar</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

    </div>
  );
}

export default TipoContrato;
