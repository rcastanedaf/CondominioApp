import { useEffect, useState } from "react";
import { getParentesco, createParentesco, deleteParentesco, updateParentesco } from "../services/parentescoService";

function Parentesco() {
    const [parentescoes, setParentescoes] = useState([]);
    const [nombre, setNombre] = useState("");
    const [showModal, setShowModal] = useState(false);
    const [ParentescoEditando, setParentescoEditando] = useState(null);

    const cargarParentescoes = async () => {
        const res = await  getParentesco();
        setParentescoes(res.data);
    };

    useEffect(() => {
        cargarParentescoes();
    }, []);

    const handleCreate = async () => {
        await createParentesco({ nombre });
        setNombre("");
        cargarParentescoes();
    };

    const handleDelete = async (id) => {
        await deleteParentesco(id);
        cargarParentescoes();
    };

    const handleEdit = (Parentesco) => {
        setParentescoEditando(Parentesco);
        setShowModal(true);
    };

    const handleUpdate = async () => {
        await updateParentesco(ParentescoEditando.id, ParentescoEditando);
        setShowModal(false);
        setParentescoEditando(null);
        cargarParentescoes();
    };

    return (
        <>
            <div className="container mt-4">
            <h2>CRUD Países</h2>

            {/* FORM */}
            <div className="mb-3">
                <input
                className="form-control mb-2"
                placeholder="Nombre"
                value={nombre}
                onChange={(e) => setNombre(e.target.value)}
                />
                <button className="btn btn-primary" onClick={handleCreate}>
                Crear
                </button>
            </div>

            {/* LISTA */}
            <table className="table">
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Acciones</th>
                </tr>
                </thead>
                <tbody>
                {parentescoes.map((p) => (
                    <tr key={p.id}>
                    <td>{p.id}</td>
                    <td>{p.nombre}</td>
                    <td>
                        <button
                        className="btn btn-warning me-2"
                        onClick={() => handleEdit(p)}
                        >
                        Editar
                        </button>
                        <button
                        className="btn btn-danger"
                        onClick={() => handleDelete(p.id)}
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
                    <h5 className="modal-title">Editar País</h5>
                    <button className="btn-close" onClick={() => setShowModal(false)}></button>
                    </div>

                    <div className="modal-body">
                    <input
                        className="form-control"
                        value={ParentescoEditando?.nombre || ""}
                        onChange={(e) =>
                        setParentescoEditando({
                            ...ParentescoEditando,
                            nombre: e.target.value,
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
                    <button className="btn btn-primary" onClick={handleUpdate}>
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

export default Parentesco;
