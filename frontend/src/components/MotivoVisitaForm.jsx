import { useEffect, useState } from "react";

function MotivoVisitaForm({ onCreate, onUpdate, motivoEditando }) {

  const [descripcion, setDescripcion] = useState("");

  useEffect(() => {
    if (motivoEditando) {
      setDescripcion(motivoEditando.descripcion);
    }
  }, [motivoEditando]);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!descripcion.trim()) return;

    if (motivoEditando) {
      onUpdate({
        id: motivoEditando.id,
        descripcion
      });
    } else {
      onCreate({ descripcion });
    }

    setDescripcion("");
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: "20px" }}>
      
      <input
        type="text"
        placeholder="Motivo de visita"
        value={descripcion}
        onChange={(e) => setDescripcion(e.target.value)}
      />

      <button type="submit" style={{ marginLeft: "10px" }}>
        {motivoEditando ? "Actualizar" : "Agregar"}
      </button>

    </form>
  );
}

export default MotivoVisitaForm;