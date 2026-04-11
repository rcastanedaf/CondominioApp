import { useEffect, useState } from "react";
import { getConceptoDescuento, getConceptoDescuentoId, getConceptoDescuentoNombre, createConceptoDescuento, updateConceptoDescuento, deleteConceptoDescuento } from "../services/conceptoDescuentoService";

function ConceptoDescuento() {
    const [conceptoDesc, setConceptoDesc] = useState([]);
    const [nombre, setNombre] = useState("");
    const [tipo, setTipo] = useState("");
    const [valor, setValor] = useState("");
    const [autorizacion, setAutorizacion] = useState("");
    const [showModal, setShowModal] = useState(false);
    const [conceptoDescEditando, setConceptoDescEditando] = useState(null);

    const cargarConceptoDescuento = async () => {
        const res = await getConceptoDescuento();
        setConceptoDesc(res.data);
    };

    useEffect(() => {
        cargarConceptoDescuento();
    }, []);

    const handleCreateConceptoDescuento = async () => {
        await createConceptoDescuento({ nombre, tipo, valor, autorizacion });
        setNombre("");
        setTipo("");
        setValor("");
        setAutorizacion("");
        cargarConceptoDescuento();
    };

    const handleDeleteConceptoDescuento = async (id) => {
        await deleteConceptoDescuento(id);
        cargarConceptoDescuento();
    };

    const handleEditConceptoDescuento = (conceptoDescuento) => {
        setConceptoDescEditando(conceptoDescuento);
        setShowModal(true);
    };

    const handleUpdateConceptoDescuento = async () => {
        await updateConceptoDescuento(conceptoDescEditando.id, conceptoDescEditando);
        setShowModal(false);
        setConceptoDescEditando(null);
        cargarConceptoDescuento();
    };

    return (
        <>
            <div className="container mt-4">
            <h2>CRUD Concepto Descuento</h2>

            {/* FORM */}
            <div className="mb-3">
                <input
                className="form-control mb-2"
                placeholder="Nombre"
                value={nombre}
                onChange={(e) => setNombre(e.target.value)}
                />
                <input
                className="form-control mb-2"
                placeholder="Tipo"
                value={tipo}
                onChange={(e) => setTipo(e.target.value)}
                />
                <input
                className="form-control mb-2"
                placeholder="Valor"
                value={valor}
                onChange={(e) => setValor(e.target.value)}
                />
                <input
                className="form-control mb-2"
                placeholder="Autorizacion"
                value={autorizacion}
                onChange={(e) => setAutorizacion(e.target.value)}
                />
                <button className="btn btn-primary" onClick={handleCreateConceptoDescuento}>
                Crear
                </button>
            </div>

            {/* LISTA */}
            <table className="table">
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Tipo</th>
                    <th>Valor</th>
                    <th>Autorizacion</th>
                    <th>Acciones</th>
                </tr>
                </thead>
                <tbody>
                {conceptoDesc.map((cd) => (
                    <tr key={cd.id}>
                    <td>{cd.id}</td>
                    <td>{cd.nombre}</td>
                    <td>{cd.tipo}</td>
                    <td>{cd.valor}</td>
                    <td>{cd.autorizacion}</td>
                    <td>
                        <button
                        className="btn btn-warning me-2"
                        onClick={() => handleEditConceptoDescuento(cd)}
                        >
                        Editar
                        </button>
                        <button
                        className="btn btn-danger"
                        onClick={() => handleDeleteConceptoDescuento(cd.id)}
                        >
                        Eliminar
                        </button>
                    </td>
                    </tr>
                ))}
                </tbody>
            </table>
            </div>
            {showModal && (
            <div className="modal show d-block" tabIndex="-1">
                <div className="modal-dialog">
                <div className="modal-content">

                    <div className="modal-header">
                    <h5 className="modal-title">Editar Concepto Descuento</h5>
                    <button className="btn-close" onClick={() => setShowModal(false)}></button>
                    </div>

                    <div className="modal-body">
                    <input
                        className="form-control mb-2"
                        value={conceptoDescEditando?.nombre || ""}
                        onChange={(e) =>
                        setConceptoDescEditando({
                            ...conceptoDescEditando,
                            nombre: e.target.value,
                        })
                        }
                    />
                    <input
                        className="form-control"
                        value={conceptoDescEditando?.tipo || ""}
                        onChange={(e) =>
                        setConceptoDescEditando({
                            ...conceptoDescEditando,
                            tipo: e.target.value,
                        })
                        }
                    />
                    <input
                        className="form-control"
                        value={conceptoDescEditando?.valor || ""}
                        onChange={(e) =>
                        setConceptoDescEditando({
                            ...conceptoDescEditando,
                            valor: e.target.value,
                        })
                        }
                    />
                    <input
                        className="form-control"
                        value={conceptoDescEditando?.autorizacion || ""}
                        onChange={(e) =>
                        setConceptoDescEditando({
                            ...conceptoDescEditando,
                            autorizacion: e.target.value,
                        })
                        }
                    />
                    </div>

                    <div className="modal-footer">
                    <button
                        className="btn btn-secondary"
                        onClick={() => setShowModal(false)}
                    >
                        Cancelar
                    </button>
                    <button className="btn btn-primary" onClick={handleUpdateConceptoDescuento}>
                        Guardar
                    </button>
                    </div>

                </div>
                </div>
            </div>
            )}

            {showModal && <div className="modal-backdrop show"></div>}
        </>
    );
}

export default ConceptoDescuento; 