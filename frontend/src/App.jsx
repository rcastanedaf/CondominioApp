import { HashRouter, Routes, Route } from "react-router-dom";
import MotivoVisitaPage from "./pages/MotivoVisitaPage";
import TipoContratoPage from "./pages/TipoContratoPage";

function App() {
  return (
    <HashRouter>
      <Routes>
        <Route path="/" element={<MotivoVisitaPage />} />
        <Route path="/tipo-contrato" element={<TipoContratoPage />} />
      </Routes>
    </HashRouter>
  );
}

export default App;
