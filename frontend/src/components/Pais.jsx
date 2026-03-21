import { useEffect, useState } from "react";
import { getPaises, createPais, deletePais, updatePais } from "../services/paisService";

function Pais() {
    const [paises, setPaises] = useState([]);
    const [nombre, setNombre] = useState("");
    const [codigo, setCodigo] = useState("");
    const [showModal, setShowModal] = useState(false);
    const [paisEditando, setPaisEditando] = useState(null);

    const cargarPaises = async () => {
        const res = await getPaises();
        setPaises(res.data);
    };

    useEffect(() => {
        cargarPaises();
    }, []);

    const handleCreate = async () => {
        await createPais({ nombre, codigo });
        setNombre("");
        setCodigo("");
        cargarPaises();
    };

    const handleDelete = async (id) => {
        await deletePais(id);
        cargarPaises();
    };

    const handleEdit = (pais) => {
        setPaisEditando(pais);
        setShowModal(true);
    };

    const handleUpdate = async () => {
        await updatePais(paisEditando.id, paisEditando);
        setShowModal(false);
        setPaisEditando(null);
        cargarPaises();
    };

    return (
        <>
            <div className="container mt-4">
            <h2>CRUD Países</h2>

            {/* FORM */}
            <div className="mb-3">
                <input
                className="form-control mb-2"
                placeholder="Código"
                value={codigo}
                onChange={(e) => setCodigo(e.target.value)}
                />
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
                    <th>Código</th>
                    <th>Nombre</th>
                    <th>Acciones</th>
                </tr>
                </thead>
                <tbody>
                {paises.map((p) => (
                    <tr key={p.id}>
                    <td>{p.id}</td>
                    <td>{p.codigo}</td>
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
                        className="form-control mb-2"
                        value={paisEditando?.codigo || ""}
                        onChange={(e) =>
                        setPaisEditando({
                            ...paisEditando,
                            codigo: e.target.value,
                        })
                        }
                    />
                    <input
                        className="form-control"
                        value={paisEditando?.nombre || ""}
                        onChange={(e) =>
                        setPaisEditando({
                            ...paisEditando,
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

export default Pais;