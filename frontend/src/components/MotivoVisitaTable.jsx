function MotivoVisitaTable({ motivos, onDelete, onEdit }) {
  return (
    <table border="1" style={{ marginTop: "20px", width: "500px" }}>
      <thead>
        <tr>
          <th>ID</th>
          <th>Descripción</th>
          <th>Acciones</th>
        </tr>
      </thead>

      <tbody>
        {motivos.map((motivo) => (
          <tr key={motivo.id}>
            <td>{motivo.id}</td>
            <td>{motivo.descripcion}</td>
            <td>

              <button onClick={() => onEdit(motivo)}>
                Editar
              </button>

              <button 
                onClick={() => onDelete(motivo.id)}
                style={{ marginLeft: "10px" }}
              >
                Eliminar
              </button>

            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default MotivoVisitaTable;