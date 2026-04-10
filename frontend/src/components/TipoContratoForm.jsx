function TipoContratoForm({ nombre, setNombre, onSubmit }) {
  return (
    <div>
      <input
        type="text"
        placeholder="Nombre del contrato"
        value={nombre}
        onChange={(e) => setNombre(e.target.value)}
      />
      <button onClick={onSubmit}>Agregar</button>
    </div>
  );
}

export default TipoContratoForm;