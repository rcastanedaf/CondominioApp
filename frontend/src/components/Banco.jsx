import { act, useEffect, useState } from "react";
import { getBancos, getBancoId, getBancoNombre, createBanco, updateBanco, deleteBanco } from "../services/bancoService";

function Banco() {
    const [bancos, setBancos] = useState([]);
    const [nombre, setNombre] = useState("");
    const [activo, setActivo] = useState("");
    const [showModal, setShowModal] = useState(false);
    const [bancoEditando, setBancoEditando] = useState(null);

    const cargarBancos = async () => {
        const res = await getBancos();
        setBancos(res.data);
    };

    useEffect(() => {
        cargarBancos();
    }, []);

    const handleCreateBanco = async () => {
        await createBanco({ nombre, activo });
        setNombre("");
        setActivo("");
        cargarBancos();
    };

    const handleDeleteBanco = async (id) => {
        await deleteBanco(id);
        cargarBancos();
    };

    const handleEditBanco = (banco) => {
        setBancoEditando(banco);
        setShowModal(true);
    };

    const handleUpdateBanco = async () => {
        await updateBanco(bancoEditando.id, bancoEditando);
        setShowModal(false);
        setBancoEditando(null);
        cargarBancos();
    };

    return (
        <>
            <div className="container mt-4">
            <h2>CRUD Bancos</h2>

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
                placeholder="Avtivo"
                value={activo}
                onChange={(e) => setActivo(e.target.value)}
                />
                <button className="btn btn-primary" onClick={handleCreateBanco}>
                Crear
                </button>
            </div>

            {/* LISTA */}
            <table className="table">
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Activo</th>
                    <th>Acciones</th>
                </tr>
                </thead>
                <tbody>
                {bancos.map((b) => (
                    <tr key={b.id}>
                    <td>{b.id}</td>
                    <td>{b.nombre}</td>
                    <td>{b.activo}</td>
                    <td>
                        <button
                        className="btn btn-warning me-2"
                        onClick={() => handleEditBanco(b)}
                        >
                        Editar
                        </button>
                        <button
                        className="btn btn-danger"
                        onClick={() => handleDeleteBanco(b.id)}
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
                    <h5 className="modal-title">Editar Banco</h5>
                    <button className="btn-close" onClick={() => setShowModal(false)}></button>
                    </div>

                    <div className="modal-body">
                    <input
                        className="form-control mb-2"
                        value={bancoEditando?.nombre || ""}
                        onChange={(e) =>
                        setBancoEditando({
                            ...bancoEditando,
                            nombre: e.target.value,
                        })
                        }
                    />
                    <input
                        className="form-control"
                        value={bancoEditando?.activo || ""}
                        onChange={(e) =>
                        setBancoEditando({
                            ...bancoEditando,
                            activo: e.target.value,
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
                    <button className="btn btn-primary" onClick={handleUpdateBanco}>
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

export default Banco;